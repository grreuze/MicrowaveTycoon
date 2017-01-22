using UnityEngine;

public enum MicrowaveType {
    Normal, Bomb, Doorless, Locked, Broken, Nuclear
}

public class MicroWave : MonoBehaviour {

    public bool isOpen, isCooking;
    public int timer;
    public float radiationPower = 1, timeToRecoverFromExplosion = 5;

    public Sprite backgroundTurnedOn, backgroundTurnedOff;

    public SpriteRenderer openDoor, closedDoor, background;
    public Plat cookingMeal;

    public MicrowaveType type;

    public bool locked, exploded, outOfOrder;

    float realTimer, timeSinceExplosion, bombTimer;
    TextMesh timerDisplay;
    SpriteRenderer cookingLED, mask;
    GameManager gameManager;
    ParticleSystem radiations, smokeClouds;

    void Awake() {
        timerDisplay = GetComponentInChildren<TextMesh>();
        cookingLED = transform.Find("CookingLED").GetComponent<SpriteRenderer>();
        openDoor = transform.Find("Door").GetComponent<SpriteRenderer>();
        closedDoor = transform.Find("ClosedDoor").GetComponent<SpriteRenderer>();
        background = transform.Find("Microwave_1").GetComponent<SpriteRenderer>();
        mask = closedDoor.transform.GetChild(0).GetComponent<SpriteRenderer>();

        backgroundTurnedOff = background.sprite;

        gameManager = GameManager.instance;
        radiations = transform.Find("Radiations").GetComponent<ParticleSystem>();
        smokeClouds = transform.Find("SmokeClouds").GetComponent<ParticleSystem>();

        if (type == MicrowaveType.Nuclear) radiationPower = 3;

        locked = type == MicrowaveType.Locked;

        if (type == MicrowaveType.Bomb) {
            cookingLED.gameObject.SetActive(false);
            timer = 599;
            realTimer = timer;
            isCooking = true;
            background.sprite = backgroundTurnedOn;
            mask.sprite = gameManager.maskDoorOn;
        }
    }

    public void StopCooking() {
        realTimer = 0;
        timer = 0;
        SetTimerDisplay();
        isCooking = false;
        background.sprite = backgroundTurnedOff;
        mask.sprite = gameManager.maskDoorOff;

        cookingLED.color = Color.white; // Temporary
    }

    void Update() {
        if (exploded) {
            timeSinceExplosion += Time.deltaTime;
            if (timeSinceExplosion > timeToRecoverFromExplosion) {
                exploded = false;
                smokeClouds.Stop();
                if (type == MicrowaveType.Bomb) {
                    isCooking = true;
                    background.sprite = backgroundTurnedOn;
                    mask.sprite = gameManager.maskDoorOn;
                    realTimer = bombTimer;
                    timer = (int)Mathf.Round(realTimer);
                }
                SetTimerDisplay();
            }
        }

        if (isCooking) {
            realTimer -= Time.deltaTime * gameManager.timeModifier * radiationPower;
            timer = (int)Mathf.Round(realTimer);
            SetTimerDisplay();

            if (timer <= 0) StopCooking();

            if (isOpen)
                gameManager.radiations += Time.deltaTime * radiationPower;

        } else if (Time.time > lastTimeScrolled + 1 && timer > 0) {
            isCooking = true;
            if (cookingMeal && cookingMeal.hasMetallicObject) {
                Explosion();
                return;
            }
            background.sprite = backgroundTurnedOn;
            mask.sprite = gameManager.maskDoorOn;

            if (isOpen) radiations.Play();
            cookingLED.color = Color.red; // Temporary

        } else if (!isOpen) {
            // let's reduce radiations a bit
            if (gameManager.radiations > 0) gameManager.radiations -= Time.deltaTime * 1/6;
        } else radiations.Stop();
    }
    
    float lastTimeScrolled;
    void OnMouseOver() {
        MyMouseOver();
    }

    public void MyMouseOver() //Pour pouvoir l'appeler depuis d'autres scripts (StopButton, MicroWaveDoor, Plat...) comme ça on peut ScrollWheel depuis les autres colliders
    {
        if (locked || exploded || outOfOrder || type == MicrowaveType.Bomb) return;

        int mouseWheel = (int)(Input.GetAxisRaw("Mouse ScrollWheel") * 10);

        if (mouseWheel != 0 && timer < 594)
        {
            timer += mouseWheel * 5;
            timer = Mathf.Max(0, timer);
            realTimer = timer;
            lastTimeScrolled = Time.time;
            SetTimerDisplay();
        }
    }

    void Explosion() {
        bombTimer = timer;
        StopCooking();
        exploded = true;
        timeSinceExplosion = 0;
        timerDisplay.text = "KO";
        smokeClouds.Play();
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (locked || exploded || outOfOrder) return;

        Plat plat = col.GetComponent<Plat>();
        if (plat && plat.isHeld && isOpen && !cookingMeal && plat.microWaveThatContainsMe != this) {
            plat.microWaveThatContainsMe = this;
        }
    }
    
    void OnTriggerStay2D(Collider2D col) {
        if (locked || exploded || outOfOrder) return;

        Plat plat = col.GetComponent<Plat>();
        if (plat && !plat.isHeld && plat.microWaveThatContainsMe == this && isOpen && !cookingMeal) {

            if (plat.hasMetallicObject && isCooking) {
                Explosion();
            } else cookingMeal = plat;
        } else if (col.GetComponent<OutOfOrderPostIt>() && !Mouse.holding) {
            outOfOrder = true;
            col.transform.parent = transform;
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        if (locked || exploded || outOfOrder) return;

        Plat plat = col.GetComponent<Plat>();
        if (plat && plat.isHeld && isOpen && !cookingMeal && plat.microWaveThatContainsMe == this) {
            plat.microWaveThatContainsMe = null;
        }
    }

    void SetTimerDisplay() {
        int minutes = timer / 60;
        int seconds = Mathf.Max(0, timer - minutes * 60);
        string zeroDigit = seconds < 10 ? "0" : "";
        timerDisplay.text = minutes + ":" + zeroDigit + seconds;
    }

    public void SetTimerFromSomewhereElse()
    {
        if (locked || exploded || outOfOrder || type == MicrowaveType.Bomb) return;

        timer += 5;
        timer = Mathf.Max(0, timer);
        realTimer = timer;
        lastTimeScrolled = Time.time;
        SetTimerDisplay();
    }
}

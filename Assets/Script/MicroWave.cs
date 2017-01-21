using UnityEngine;

public enum MicrowaveType {
    Normal, Bomb, Doorless, Locked, Broken, Nuclear
}

public class MicroWave : MonoBehaviour {

    public bool isOpen, isCooking;
    public int timer;
    float radiationPower = 1;

    public SpriteRenderer openDoor, closedDoor;
    public Plat cookingMeal;

    public MicrowaveType type;

    public bool locked, exploded, outOfOrder;

    float realTimer;
    TextMesh timerDisplay;
    SpriteRenderer cookingLED, mask;
    GameManager gameManager;
    ParticleSystem radiations;

    void Awake() {
        timerDisplay = GetComponentInChildren<TextMesh>();
        cookingLED = transform.Find("CookingLED").GetComponent<SpriteRenderer>();
        openDoor = transform.Find("Door").GetComponent<SpriteRenderer>();
        closedDoor = transform.Find("ClosedDoor").GetComponent<SpriteRenderer>();
        mask = closedDoor.transform.GetChild(0).GetComponent<SpriteRenderer>();

        gameManager = GameManager.instance;
        radiations = transform.Find("Radiations").GetComponent<ParticleSystem>();

        locked = type == MicrowaveType.Locked;
    }

    public void StopCooking() {
        realTimer = 0;
        timer = 0;
        SetTimerDisplay();
        isCooking = false;
        mask.sprite = gameManager.maskDoorOff;

        cookingLED.color = Color.white; // Temporary
    }

    void Update() {
        if (isCooking) {
            realTimer -= Time.deltaTime * gameManager.timeModifier;
            timer = (int)Mathf.Round(realTimer);
            SetTimerDisplay();

            if (timer <= 0) StopCooking();

            if (isOpen)
                gameManager.radiations += Time.deltaTime * radiationPower;

        } else if (Time.time > lastTimeScrolled + 1 && timer > 0) {
            isCooking = true;
            mask.sprite = gameManager.maskDoorOn;

            if (isOpen) radiations.Play();
            cookingLED.color = Color.cyan; // Temporary

        } else if (!isOpen) {
            // let's reduce radiations a bit
            if (gameManager.radiations > 0) gameManager.radiations -= Time.deltaTime * 1/6;
        } else radiations.Stop();
    }
    
    float lastTimeScrolled;
    void OnMouseOver() {
        if (locked || exploded || outOfOrder) return;

        int mouseWheel = (int)(Input.GetAxisRaw("Mouse ScrollWheel")*10);

        if (mouseWheel != 0) {
            timer += mouseWheel * 5;
            timer = Mathf.Max(0, timer);
            realTimer = timer;
            lastTimeScrolled = Time.time;
            SetTimerDisplay();
        }
    }

    void Explosion() {
        StopCooking();
        exploded = true;
        timerDisplay.text = "";
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (locked || exploded || outOfOrder) return;

        Plat plat = col.GetComponent<Plat>();
        if (plat && plat.isHeld && isOpen && !cookingMeal) {
            plat.microWaveThatContainsMe = this;
        }
    }
    
    void OnTriggerStay2D(Collider2D col) {
        if (locked || exploded || outOfOrder) return;

        Plat plat = col.GetComponent<Plat>();
        if (plat && !plat.isHeld && plat.microWaveThatContainsMe == this && isOpen && !cookingMeal) {
            cookingMeal = plat;
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        if (locked || exploded || outOfOrder) return;

        Plat plat = col.GetComponent<Plat>();
        if (plat && plat.isHeld && isOpen && !cookingMeal) {
            plat.microWaveThatContainsMe = null;
        }
    }

    void SetTimerDisplay() {
        int minutes = timer / 60;
        int seconds = Mathf.Max(0, timer - minutes * 60);
        string zeroDigit = seconds < 10 ? "0" : "";
        timerDisplay.text = minutes + ":" + zeroDigit + seconds;
    }
}

using UnityEngine;

public class MicroWave : MonoBehaviour {

    public bool isOpen, isCooking;
    public int timer;
    public float radiationPower = 1;

    public SpriteRenderer door;
    public Plat cookingMeal;

    float realTimer;
    TextMesh timerDisplay;
    SpriteRenderer cookingLED;
    GameManager gameManager;
    ParticleSystem radiations;

    void Awake() {
        timerDisplay = GetComponentInChildren<TextMesh>();
        cookingLED = transform.Find("CookingLED").GetComponent<SpriteRenderer>();
        door = transform.Find("Door").GetComponent<SpriteRenderer>();
        gameManager = GameManager.instance;
        radiations = transform.Find("Radiations").GetComponent<ParticleSystem>();
    }

    void Update() {
        if (isCooking) {
            realTimer -= Time.deltaTime * gameManager.timeModifier;
            timer = (int)Mathf.Round(realTimer);
            SetTimerDisplay();
            if (timer <= 0) {
                realTimer = 0;
                timer = 0;
                isCooking = false;
                cookingLED.color = Color.white; // Temporary
            }

            if (isOpen) {
                gameManager.radiations += Time.deltaTime * radiationPower;
                // Radiations here
            }

        } else if (Time.time > lastTimeScrolled + 1 && timer > 0) {
            isCooking = true;

            if (isOpen) radiations.Play();

            cookingLED.color = Color.cyan; // Temporary

        } else if (!isOpen) {
            // let's reduce radiations a bit
            if (gameManager.radiations > 0) gameManager.radiations -= Time.deltaTime * 1/6;
        }
    }
    
    float lastTimeScrolled;
    void OnMouseOver() {
        int mouseWheel = (int)(Input.GetAxisRaw("Mouse ScrollWheel")*10);

        if (mouseWheel != 0) {
            timer += mouseWheel * 5;
            timer = Mathf.Max(0, timer);
            realTimer = timer;
            lastTimeScrolled = Time.time;
            SetTimerDisplay();
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        Plat plat = col.GetComponent<Plat>();
        if (plat && plat.isHeld && isOpen && !cookingMeal) {
            plat.microWaveThatContainsMe = this;
        }
    }
    
    void OnTriggerStay2D(Collider2D col) {
        Plat plat = col.GetComponent<Plat>();
        if (plat && !plat.isHeld && plat.microWaveThatContainsMe == this && isOpen && !cookingMeal) {
            cookingMeal = plat;
        }
    }

    void OnTriggerExit2D(Collider2D col) {
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

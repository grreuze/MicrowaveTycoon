using UnityEngine;

public class MicroWave : MonoBehaviour {

    public bool isOpen, isCooking;
    public int timer;
    public SpriteRenderer door;
    public Plat cookingMeal;

    float realTimer;
    TextMesh timerDisplay;
    SpriteRenderer cookingLED;

    void Awake() {
        timerDisplay = GetComponentInChildren<TextMesh>();
        cookingLED = transform.Find("CookingLED").GetComponent<SpriteRenderer>();
        door = transform.Find("Door").GetComponent<SpriteRenderer>();
    }

    void Update() {
        if (isCooking) {
            realTimer -= Time.deltaTime * Parameters.timeModifier;
            timer = (int)Mathf.Round(realTimer);
            SetTimerDisplay();
            if (timer <= 0) {
                realTimer = 0;
                timer = 0;
                isCooking = false;
                cookingLED.color = Color.white; // Temporary
            }

            if (isOpen) {
                // Radiations here
            }

        } else if (Time.time > lastTimeScrolled + 1 && timer > 0) {
            isCooking = true;
            cookingLED.color = Color.cyan; // Temporary
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
        if (plat && isOpen && !cookingMeal) {
            cookingMeal = plat;
            plat.microWaveThatContainsMe = this;
        }
    }
    
    void SetTimerDisplay() {
        int minutes = timer / 60;
        int seconds = Mathf.Max(0, timer - minutes * 60);
        string zeroDigit = seconds < 10 ? "0" : "";
        timerDisplay.text = minutes + ":" + zeroDigit + seconds;
    }

}

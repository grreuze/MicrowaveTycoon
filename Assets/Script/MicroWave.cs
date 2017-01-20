using UnityEngine;

public class MicroWave : MonoBehaviour {

    public bool isOpen, isCooking;
    public int timer;
    float realTimer;

    TextMesh timerDisplay;
    SpriteRenderer cookingLED;

    void Start() {
        timerDisplay = GetComponentInChildren<TextMesh>();
        cookingLED = transform.Find("CookingLED").GetComponent<SpriteRenderer>();
    }

    void Update() {
        if (isCooking) {
            realTimer -= Time.deltaTime;
            timer = (int)realTimer;
            SetTimerDisplay();
            if (timer <= 0) {
                isCooking = false;
                cookingLED.color = Color.white; // Temporary
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
            realTimer = timer;
            lastTimeScrolled = Time.time;
            SetTimerDisplay();
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (isOpen) {
            print("Put the meal in the Microwave");
        }
    }
    
    void SetTimerDisplay() {
        int minutes = timer / 60;
        int seconds = Mathf.Max(0, timer - minutes * 60);
        string zeroDigit = seconds < 10 ? "0" : "";
        timerDisplay.text = minutes + ":" + zeroDigit + seconds;
    }

}

using UnityEngine;

public class Plat : MonoBehaviour {

    /// <summary>
    /// Returns whether or not the object is currently held by the player.
    /// </summary>
    public bool isHeld;

    public Rigidbody2D rb;

    float realTimer;
    public int timeToCook, timeCooked;
    public MicroWave microWaveThatContainsMe;

    public bool overCooked;

    TapisRoulant leTapisRoulant;
    GameObject leGameObjectDuTapisRoulant;

    float speed;
    Vector2 movement;

    void Start() {
        leTapisRoulant = FindObjectOfType<TapisRoulant>();
        if (!leTapisRoulant) Debug.LogError("IL N'Y A PAS DE TAPIS ROULANT");
        leGameObjectDuTapisRoulant = leTapisRoulant.gameObject;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (isHeld) MoveToMousePosition();
        if (microWaveThatContainsMe) {
            realTimer += Time.deltaTime;
            timeCooked = (int)Mathf.Round(realTimer);

            if (timeCooked > timeToCook) {
                overCooked = true;
            }
        }

        if (!Input.GetMouseButton(0)) {
            Drop();
        }
    }

    void MoveToMousePosition() {
        float screenDepth = Camera.main.WorldToScreenPoint(transform.position).z;
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenDepth));
    }

    void OnMouseOver() {
        bool canDrag = !isHeld;
        isHeld = Input.GetMouseButton(0);
        if (isHeld && canDrag) Drag();
    }
    
    void OnCollisionStay2D(Collision2D col) {
        if (col.gameObject == leGameObjectDuTapisRoulant) {
            // Bouge sur le tapis roulant
            speed = leTapisRoulant.speed;
            movement.x = -speed;
            rb.velocity = movement;
        }
    }

    void OnCollisionExit2D(Collision2D col) {
        rb.velocity = Vector2.zero;
    }

    #region Drag n Drop Functions

    void Drag() {
        transform.parent = null;
        rb.bodyType = RigidbodyType2D.Dynamic;
        microWaveThatContainsMe = null;
    }

    void Drop() {
        isHeld = false;
        if (microWaveThatContainsMe) {
            transform.parent = microWaveThatContainsMe.door.transform;
            rb.bodyType = RigidbodyType2D.Static;
            transform.localPosition = Vector2.zero;
            
            if (!overCooked) {
                if (timeCooked == timeToCook) {
                    // Perfect score
                } else if (timeCooked > timeToCook - 5) {
                    // Approximately cooked
                } else {
                    // Not cooked
                }
            }

            // Here check if cooked or not
        }
    }

    #endregion
}

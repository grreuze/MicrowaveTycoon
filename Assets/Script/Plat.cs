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
    
    public int valeur;

    public static Plat currentlyHolding;

    GameObject bol;

    TapisRoulant leTapisRoulant;
    GameObject leGameObjectDuTapisRoulant;

    float speed;
    Vector2 movement;

    void Start() {
        leTapisRoulant = FindObjectOfType<TapisRoulant>();
        if (!leTapisRoulant) Debug.LogError("IL N'Y A PAS DE TAPIS ROULANT");
        leGameObjectDuTapisRoulant = leTapisRoulant.gameObject;
        rb = GetComponent<Rigidbody2D>();
        GenererBol();
    }

    void Update() {
        if (isHeld) Drag();
        if (microWaveThatContainsMe && microWaveThatContainsMe.timer > 0) {

            // Add cooking time
            realTimer += Time.deltaTime * Parameters.timeModifier;
            timeCooked = (int)Mathf.Round(realTimer);

            if (timeCooked > timeToCook) {
                overCooked = true;
            }
        }
        if (!Input.GetMouseButton(0)) {
            Drop();
        }
    }
    
    void OnMouseOver() {
        bool canDrag = !isHeld;
        if (!currentlyHolding) {
            isHeld = Input.GetMouseButton(0);
            if (!isHeld) currentlyHolding = null;
        }
        if (isHeld && canDrag && !currentlyHolding) StartHolding();
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
        if (rb.bodyType == RigidbodyType2D.Dynamic)
            rb.velocity = Vector2.zero;
    }

    public void GenererBol() {
        bol = transform.FindChild("Bol").gameObject;
        GameObject newBolInstance = Instantiate(PrefabManager.instance.apparencesDeBols[valeur], bol.transform.position, bol.transform.rotation) as GameObject;
        newBolInstance.transform.parent = transform;
        DestroyImmediate(bol.gameObject);
        bol = newBolInstance;
        bol.name = "Bol";
    }
    
    #region Drag n Drop Functions

    void StartHolding() {
        transform.parent = null;
        rb.bodyType = RigidbodyType2D.Dynamic;
        microWaveThatContainsMe = null;
        currentlyHolding = this;
    }

    void Drag() {
        float screenDepth = Camera.main.WorldToScreenPoint(transform.position).z;
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenDepth));
    }

    void Drop() {
        isHeld = false;
        currentlyHolding = null;
        if (microWaveThatContainsMe) {
            transform.parent = microWaveThatContainsMe.door.transform;
            rb.bodyType = RigidbodyType2D.Static;
            transform.localPosition = Vector2.zero;
            microWaveThatContainsMe.cookingMeal = null;

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

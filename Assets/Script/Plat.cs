using UnityEngine;

public class Plat : MonoBehaviour {

    /// <summary>
    /// Returns whether or not the object is currently held by the player.
    /// </summary>
    public bool isHeld;

    public Rigidbody2D rb;

    float realTimer;
    public int timeToCook, timeCooked, cookingMargin;
    public MicroWave microWaveThatContainsMe;

    public bool overCooked;
    public int valeurDuBol;
    public static Plat currentlyHolding;
    public bool inStarGate;
    
    GameManager gameManager;
    GameObject bol;
    TapisRoulant leTapisRoulant;
    GameObject leGameObjectDuTapisRoulant;
    BoxCollider2D myCollider;
    SpriteRenderer bouffe;

    float speed;
    Vector2 movement;
    
    void Start() {
        gameManager = GameManager.instance;

        leTapisRoulant = FindObjectOfType<TapisRoulant>();
        if (!leTapisRoulant) Debug.LogError("IL N'Y A PAS DE TAPIS ROULANT");
        leGameObjectDuTapisRoulant = leTapisRoulant.gameObject;

        myCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        bouffe = transform.Find("Bouffe").GetComponent<SpriteRenderer>();
        GenererBol();
    }

    public void ResetValues() {
        Drop();
        realTimer = 0;
        timeCooked = 0;
        myCollider.isTrigger = false;
        overCooked = false;
        bouffe.sharedMaterial = gameManager.matDefault;
    }

    void Update() {
        if (isHeld) Drag();
        if (microWaveThatContainsMe && microWaveThatContainsMe.timer > 0) {

            // Add cooking time
            realTimer += Time.deltaTime * gameManager.timeModifier;
            timeCooked = (int)Mathf.Round(realTimer);

            if (timeCooked > timeToCook) {
                // Overcooked
                overCooked = true;
                bouffe.sharedMaterial = gameManager.matTropCuit;
                // Ajouter beaucoup de fuméee

            } else if (timeCooked > timeToCook - cookingMargin) {
                // Cooked

                bouffe.sharedMaterial = gameManager.matCuit;
                // Ajouter particles de fumée stylée

                if (timeCooked == timeToCook) {
                    // Perfect score

                    // Ajouter petites étoiles cools
                }

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
        GameObject newBolInstance = Instantiate(gameManager.apparencesDeBols[valeurDuBol], bol.transform.position, bol.transform.rotation) as GameObject;
        newBolInstance.transform.parent = transform;
        DestroyImmediate(bol.gameObject);
        bol = newBolInstance;
        bol.name = "Bol";
    }
    
    #region Drag n Drop Functions

    void StartHolding() {
        myCollider.isTrigger = false;
        transform.parent = null;
        rb.bodyType = RigidbodyType2D.Dynamic;
        if (microWaveThatContainsMe) {
            microWaveThatContainsMe.cookingMeal = null;
            microWaveThatContainsMe = null;
        }
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
            myCollider.isTrigger = true;
            transform.parent = microWaveThatContainsMe.door.transform;
            rb.bodyType = RigidbodyType2D.Static;
            transform.localPosition = Vector2.zero;
        }
    }

    #endregion
}

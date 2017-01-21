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
    
    public int valeurDuBol;
    public static Plat currentlyHolding;
    public bool inStarGate;

    public CookingState cookingState;
    public enum CookingState {
        none, good, perfect, overCooked
    }

    GameManager gameManager;
    GameObject bol;
    TapisRoulant leTapisRoulant;
    GameObject leGameObjectDuTapisRoulant;
    BoxCollider2D myCollider;
    SpriteRenderer bouffe;
    GameObject smoke;
    ParticleSystem smokeClouds, shine;

    float speed;
    Vector2 movement;
    
    void Start() {
        gameManager = GameManager.instance;

        leTapisRoulant = FindObjectOfType<TapisRoulant>();
        if (!leTapisRoulant) Debug.LogError("IL N'Y A PAS DE TAPIS ROULANT");
        leGameObjectDuTapisRoulant = leTapisRoulant.gameObject;

        smoke = transform.Find("Smoke").gameObject;
        smoke.SetActive(false);

        smokeClouds = transform.Find("SmokeClouds").GetComponent<ParticleSystem>();
        shine = transform.Find("Shine").GetComponent<ParticleSystem>();

        myCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        bouffe = transform.Find("Bouffe").GetComponent<SpriteRenderer>();
        GenererBol();
    }

    public void ResetValues() {
        Drop();
        realTimer = 0;
        timeCooked = 0;
        inStarGate = false;
        smoke.gameObject.SetActive(false);
        smokeClouds.Stop();
        shine.Stop();
        transform.rotation = Quaternion.identity;
        transform.localScale = Vector2.one;
        myCollider.isTrigger = false;
        cookingState = CookingState.none;
        bouffe.sharedMaterial = gameManager.matDefault;
    }

    void Update() {
        if (isHeld) Drag();

        DoSmoke();
        DoCooking();

        if (!Input.GetMouseButton(0))
            Drop();
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

    void DoCooking() {
        if (microWaveThatContainsMe && microWaveThatContainsMe.timer > 0) {

            // Add cooking time
            realTimer += Time.deltaTime * gameManager.timeModifier;
            timeCooked = (int)Mathf.Round(realTimer);

            if (timeCooked > timeToCook) { // Overcooked

                if (cookingState != CookingState.overCooked) {
                    cookingState = CookingState.overCooked;
                    bouffe.sharedMaterial = gameManager.matTropCuit;
                    smoke.SetActive(false);
                }

            } else if (timeCooked > timeToCook - cookingMargin) { // Cooked

                bouffe.sharedMaterial = gameManager.matCuit;
                cookingState = CookingState.good;
                if (microWaveThatContainsMe.isOpen) smoke.SetActive(true);

                if (timeCooked == timeToCook) {
                    // Perfect score
                    cookingState = CookingState.perfect;
                    if (microWaveThatContainsMe.isOpen) smoke.SetActive(true);
                    // Ajouter petites étoiles cools
                }
            }
        }
    }

    void DoSmoke() {
        if (cookingState == CookingState.overCooked &&
            (!microWaveThatContainsMe || microWaveThatContainsMe && microWaveThatContainsMe.isOpen)) {

            if (!smokeClouds.isPlaying) smokeClouds.Play();
        } else if (smokeClouds.isPlaying) smokeClouds.Stop();

        if ((cookingState == CookingState.perfect || cookingState == CookingState.good) &&
            (!microWaveThatContainsMe || microWaveThatContainsMe && microWaveThatContainsMe.isOpen)) {

            smoke.SetActive(true);
        } else smoke.SetActive(false);
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
        transform.localScale = Vector2.one;
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

            transform.parent = null;
            transform.localScale = Vector2.one * 0.7f;
            transform.parent = microWaveThatContainsMe.door.transform;
            transform.rotation = Quaternion.identity;

            rb.bodyType = RigidbodyType2D.Static;
            transform.localPosition = Vector2.zero;
        }
    }

    #endregion
}

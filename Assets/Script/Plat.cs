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
    public bool inStarGate;
    [HideInInspector]
    public bool hasMetallicObject;
    public bool keepCold, cantHaveMetallicObjects;
    public bool neverAskedForTHis, manScream;

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
    AudioSource audioSource;

    float speed;
    Vector2 movement;
    
    bool isAccessible {
        get {
            return !microWaveThatContainsMe || microWaveThatContainsMe && microWaveThatContainsMe.isOpen;
        }
    }

    void Start() {
        gameManager = GameManager.instance;

        audioSource = GetComponent<AudioSource>();
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

        if (keepCold) timeToCook = 0;
        cookingState = keepCold ? CookingState.good : CookingState.none;
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
        cookingState = keepCold ? CookingState.good : CookingState.none;
        bouffe.sharedMaterial = gameManager.matDefault;
    }

    void Update() {
        if (isHeld) Drag();

        DoFX();
        DoCooking();

        if (!Input.GetMouseButton(0))
            Drop();
    }
    
    void OnMouseOver() {
        if (!isAccessible) return;
        bool canDrag = !isHeld;
        if (!Mouse.holding) {
            isHeld = Input.GetMouseButton(0);
            if (!isHeld) Mouse.holding = null;
        }
        if (isHeld && canDrag && !Mouse.holding)
            StartHolding();

        if (microWaveThatContainsMe) microWaveThatContainsMe.MyMouseOver();
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
            realTimer += Time.deltaTime * gameManager.timeModifier * microWaveThatContainsMe.radiationPower;
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
            }
        }
    }

    void DoFX() {
        if (cookingState == CookingState.overCooked && isAccessible) {

            if (!smokeClouds.isPlaying) smokeClouds.Play();
        } else if (smokeClouds.isPlaying) smokeClouds.Stop();

        if (cookingState == CookingState.good && isAccessible) {

            if (!shine.isPlaying) shine.Play();
            if (!keepCold) smoke.SetActive(true);
        } else {
            if (shine.isPlaying) shine.Stop();
            smoke.SetActive(false);
        }
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
        rb.gravityScale = 0;
        transform.localScale = Vector2.one;
        if (microWaveThatContainsMe) {

            audioSource.clip = SoundManager.instance.retirerPlat;
            audioSource.Play();

            microWaveThatContainsMe.cookingMeal = null;
            microWaveThatContainsMe = null;
            SortLayer(transform, "PlatOut");
        }
        Mouse.holding = gameObject;
    }

    void Drag() {
        float screenDepth = Camera.main.WorldToScreenPoint(transform.position).z;
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenDepth));
    }

    void Drop() {
        isHeld = false;
        Mouse.holding = null;
        rb.gravityScale = 1;
        if (microWaveThatContainsMe) {
            myCollider.isTrigger = true;

            audioSource.clip = SoundManager.instance.placerPlat;
            audioSource.Play();

            if (microWaveThatContainsMe.isCooking) {
                if (neverAskedForTHis) {
                    audioSource.clip = SoundManager.instance.neverAsked;
                    audioSource.Play();
                } else if (manScream) {
                    audioSource.clip = SoundManager.instance.manScreaming;
                    audioSource.Play();
                }
            }
            
            transform.parent = null;
            transform.localScale = Vector2.one * 0.7f;
            transform.parent = microWaveThatContainsMe.closedDoor.transform;
            transform.rotation = Quaternion.identity;
            SortLayer(transform, "PlatIn");

            rb.bodyType = RigidbodyType2D.Static;
            transform.localPosition = Vector2.zero;

            if (hasMetallicObject) {
                Transform key = transform.Find("Key") ?? GetComponentInChildren<MetallicObject>().transform;
                key.transform.localPosition = Vector3.back;
            }
        }
    }

    void SortLayer(Transform trans, string layer)
    {
        SpriteRenderer sprite = trans.GetComponent<SpriteRenderer>();
        if (sprite) sprite.sortingLayerName = layer;
        foreach (Transform child in trans)
        {
            SortLayer(child, layer);
        }
    }

    #endregion
}

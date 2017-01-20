using UnityEngine;

public class Plat : MonoBehaviour {

    TapisRoulant leTapisRoulant;
    GameObject leGameObjectDuTapisRoulant;

    public Rigidbody2D rb;

    float speed;
    Vector2 movement;

    public int timeToCook;

    public int valeur;
    GameObject bol;

    void Start()
    {
        leTapisRoulant = FindObjectOfType<TapisRoulant>();
        if (!leTapisRoulant) Debug.LogError("IL N'Y A PAS DE TAPIS ROULANT");
        leGameObjectDuTapisRoulant = leTapisRoulant.gameObject;
        rb = GetComponent<Rigidbody2D>();
        GenererBol();
    }

    void Update()
    {

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


    void GenererBol() 
    {
        bol = transform.FindChild("Bol").gameObject;
        GameObject newBolInstance = Instantiate(PrefabManager.instance.apparencesDeBols[valeur], bol.transform.position, bol.transform.rotation) as GameObject;
        newBolInstance.transform.parent = transform;
        DestroyImmediate(bol.gameObject);
        bol = newBolInstance;
        bol.name = "Bol";
    }

    /*
    void OnValidate()
    {
        if (PrefabManager.instance == null) PrefabManager.instance = FindObjectOfType<PrefabManager>();
        GenererBol();
    }
    */
}

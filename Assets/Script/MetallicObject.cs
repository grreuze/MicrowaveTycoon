using UnityEngine;

public class MetallicObject : DraggableObject {

    Plat parent;
    
    TapisRoulant leTapisRoulant;
    GameObject leGameObjectDuTapisRoulant;

    float speed;
    Vector2 movement;
    public Rigidbody2D rb;
    public new BoxCollider2D collider;

    public virtual void Start() {
        parent = GetComponentInParent<Plat>();
        if (parent) parent.hasMetallicObject = true;
        leTapisRoulant = FindObjectOfType<TapisRoulant>();
        if (!leTapisRoulant) Debug.LogError("IL N'Y A PAS DE TAPIS ROULANT");
        leGameObjectDuTapisRoulant = leTapisRoulant.gameObject;
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
    }

    public override void MoveToMousePosition() {
        parent = GetComponentInParent<Plat>();
        if (parent) parent.hasMetallicObject = false;
        collider.isTrigger = false;
        rb.bodyType = RigidbodyType2D.Dynamic;
        base.MoveToMousePosition();
        transform.parent = null;
        rb.velocity = Vector2.zero;
    }

    void OnCollisionStay2D(Collision2D col) {
        if (col.gameObject == leGameObjectDuTapisRoulant) {
            // Bouge sur le tapis roulant
            speed = leTapisRoulant.speed;
            movement.x = -speed;
            rb.velocity = movement;
        }
    }
}

using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class BouffeDestroyer : MonoBehaviour {

    BouffeManager bouffeManager;
    Transform pool;

    public virtual void Start () {
        bouffeManager = FindObjectOfType<BouffeManager>();
        pool = bouffeManager.pool.transform;
	}

    public virtual void OnTriggerEnter2D(Collider2D col) {
        Plat plat = col.GetComponent<Plat>();
        if (plat) {
            plat.ResetValues();
            plat.gameObject.SetActive(false);
            plat.transform.position = bouffeManager.instantiatePosition;
            plat.transform.parent = pool;
            return;
        }
        Key key = col.GetComponent<Key>();
        if (key) {
            key.gameObject.SetActive(false);
            bouffeManager.needToSpawnKey = true;
        }
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        BoxCollider2D box = GetComponent<BoxCollider2D>();
        Vector2 size = new Vector2(box.size.x * transform.lossyScale.x, box.size.y * transform.lossyScale.y);
        Gizmos.DrawWireCube(transform.position, size);
    }
}

using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class BouffeDestroyer : MonoBehaviour {

    BouffeManager bouffeManager;
    Transform pool;

	void Start () {
        bouffeManager = FindObjectOfType<BouffeManager>();
        pool = bouffeManager.pool.transform;
	}

    void OnTriggerEnter2D(Collider2D col) {
        Plat plat = col.GetComponent<Plat>();
        if (plat) {
            plat.gameObject.SetActive(false);
            plat.transform.parent = pool;
        }
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, GetComponent<BoxCollider2D>().size);
    }
}

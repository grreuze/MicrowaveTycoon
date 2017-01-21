using UnityEngine;

public class TapisRoulant : MonoBehaviour {

    public float speed;
    
    void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.localPosition, GetComponent<BoxCollider2D>().size);
    }

}

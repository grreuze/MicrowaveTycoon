using UnityEngine;

public class Avatar : MonoBehaviour {

    public RotateTowardsMouse arm;

    void Start() {
        arm = GetComponentInChildren<RotateTowardsMouse>();
    }


    void OnTriggerStay2D(Collider2D col) {
        if (col.GetComponent<OutOfOrderPostIt>() && !Mouse.holding) {
            arm.block = true;
            col.transform.parent = transform;
        }
    }

}

using UnityEngine;

public class Avatar : MonoBehaviour {

    public RotateTowardsMouse arm;

    ParticleSystem waves;

    void Start() {
        arm = GetComponentInChildren<RotateTowardsMouse>();
        waves = GetComponentInChildren<ParticleSystem>();
    }

    void Update() {
        waves.gameObject.SetActive(Input.GetMouseButton(0) && !arm.block);
    }

    void OnTriggerStay2D(Collider2D col) {
        if (col.GetComponent<OutOfOrderPostIt>() && !Mouse.holding) {
            arm.block = true;
            col.transform.parent = transform;
        }
    }

}

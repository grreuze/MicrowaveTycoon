using UnityEngine;

public class MicroWaveDoorButton : MonoBehaviour {

    MicroWave microWave;
    
	void Start () {
        microWave = GetComponentInParent<MicroWave>();
        microWave.door.gameObject.SetActive(microWave.isOpen);
    }

    void OnMouseOver() {
        if (Input.GetMouseButtonDown(0)) {
            microWave.isOpen ^= true;
            microWave.door.gameObject.SetActive(microWave.isOpen); // Temporary
        }
    }
}

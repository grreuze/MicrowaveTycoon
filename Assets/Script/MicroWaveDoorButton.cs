using UnityEngine;

public class MicroWaveDoorButton : MonoBehaviour {

    MicroWave microWave;
    
	void Start () {
        microWave = GetComponentInParent<MicroWave>();
	}

    void OnMouseOver() {
        if (Input.GetMouseButtonDown(0)) {
            print("click button");
            microWave.isOpen ^= true;
        }
    }
}

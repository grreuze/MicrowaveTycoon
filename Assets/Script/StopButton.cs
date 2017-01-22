using UnityEngine;

public class StopButton : MonoBehaviour {

    MicroWave microWave;
    
    void Start() {
        microWave = GetComponentInParent<MicroWave>();
    }

    void OnMouseOver() {
        if (Input.GetMouseButtonDown(0) && microWave.isCooking)
            microWave.StopCooking();
        else if (Input.GetMouseButtonDown(0))
        {
            microWave.SetTimerFromSomewhereElse();
        }

        microWave.MyMouseOver();
    }

}

using UnityEngine;

public class MicroWaveDoorButton : MonoBehaviour {

    MicroWave microWave;
    ParticleSystem radiations;

    void Start () {
        microWave = GetComponentInParent<MicroWave>();
        microWave.door.enabled = microWave.isOpen; // Temporary
        radiations = transform.parent.Find("Radiations").GetComponent<ParticleSystem>();
    }

    void OnMouseOver() {
        if (Input.GetMouseButtonDown(0)) {
            microWave.isOpen ^= true;
            microWave.door.enabled = microWave.isOpen; // Temporary

            if (microWave.isOpen && microWave.isCooking) radiations.Play();
            else radiations.Stop();
            
            SpriteRenderer[] rends = microWave.door.GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer rend in rends) {
                rend.enabled = microWave.isOpen;
            }
            
        }
    }
}

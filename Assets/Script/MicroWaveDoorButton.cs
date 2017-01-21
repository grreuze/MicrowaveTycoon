using UnityEngine;

public class MicroWaveDoorButton : MonoBehaviour {

    MicroWave microWave;
    ParticleSystem radiations;
    SpriteRenderer mask;

    void Start () {
        microWave = GetComponentInParent<MicroWave>();
        
        microWave.openDoor.enabled = microWave.isOpen;
        mask = microWave.closedDoor.transform.GetChild(0).GetComponent<SpriteRenderer>();
        mask.enabled = microWave.closedDoor.enabled = !microWave.isOpen;
        
        radiations = transform.parent.Find("Radiations").GetComponent<ParticleSystem>();
    }

    void OnMouseOver() {
        if (Input.GetMouseButtonDown(0)) {
            microWave.isOpen ^= true;

            microWave.openDoor.enabled = microWave.isOpen;
            mask.enabled = microWave.closedDoor.enabled = !microWave.isOpen;

            if (microWave.isOpen && microWave.isCooking) radiations.Play();
            else radiations.Stop();
            
            /*SpriteRenderer[] rends = microWave.door.GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer rend in rends) {
                rend.enabled = microWave.isOpen;
            }*/
            
        }
    }
}

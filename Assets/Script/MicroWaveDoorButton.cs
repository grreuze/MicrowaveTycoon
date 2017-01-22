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

        if (microWave.type == MicrowaveType.Doorless) {

            microWave.isOpen = true;

            microWave.closedDoor.gameObject.SetActive(true);
            mask.enabled = microWave.closedDoor.enabled = false;

            microWave.openDoor.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }

    }

    void OnMouseOver() {
        if (microWave.locked || microWave.exploded || microWave.outOfOrder) return;

        if (Input.GetMouseButtonDown(0)) {
            microWave.isOpen ^= true;

            microWave.openDoor.enabled = microWave.isOpen;
            mask.enabled = microWave.closedDoor.enabled = !microWave.isOpen;

            mask.sprite = microWave.isCooking ? GameManager.instance.maskDoorOn : GameManager.instance.maskDoorOff;

            if (microWave.isOpen && microWave.isCooking) radiations.Play();
            else radiations.Stop();
        }

        microWave.MyMouseOver();
    }

    bool canPutKeyIn;

    void OnTriggerEnter2D(Collider2D col) {
        if (!microWave.locked) return;

        Key key = col.GetComponent<Key>();

        canPutKeyIn = key && Mouse.holding;
    }
    void OnTriggerExit2D(Collider2D col) {
        if (!microWave.locked) return;

        Key key = col.GetComponent<Key>();

        canPutKeyIn = !(key && !Mouse.holding);
    }

    void OnTriggerStay2D(Collider2D col) {
        if (!microWave.locked) return;

        Key key = col.GetComponent<Key>();

        if (key && !Mouse.holding && canPutKeyIn) {

            key.transform.parent = null;
            key.enabled = false;

            key.rb.bodyType = RigidbodyType2D.Kinematic;
            key.rb.velocity = Vector2.zero;
            key.rb.freezeRotation = true;
            key.collider.enabled = false;

            key.transform.localScale = new Vector2(-1, 1);
            key.transform.position = new Vector2(-0.35f, -0.1f);
            key.transform.localRotation = Quaternion.identity;

            microWave.locked = false;
        }
    }
}

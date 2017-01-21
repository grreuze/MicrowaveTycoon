
using UnityEngine;

public class StarGate : BouffeDestroyer {

    public override void OnTriggerEnter2D(Collider2D col) {

        Plat plat = col.GetComponent<Plat>();
        if (plat && plat.isHeld) plat.inStarGate = true;
    }

    void OnTriggerStay2D(Collider2D col) {
        
        Plat plat = col.GetComponent<Plat>();
        
        if (plat && !plat.isHeld && plat.inStarGate) {

            //Ajouter des points de satisfaction au gars, etc

            DestroyBouffe(col);

            // Mettre des effets de particules de téléportation cool
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        Plat plat = col.GetComponent<Plat>();
        if (plat) plat.inStarGate = false;
    }

    void DestroyBouffe(Collider2D col) {
        base.OnTriggerEnter2D(col);
    }

}


using UnityEngine;

public class StarGate : BouffeDestroyer {

    GameManager gameManager;

    public override void Start() {
        base.Start();
        gameManager = GameManager.instance;
    }

    public override void OnTriggerEnter2D(Collider2D col) {

        Plat plat = col.GetComponent<Plat>();
        if (plat && plat.isHeld) plat.inStarGate = true;
    }

    void OnTriggerStay2D(Collider2D col) {
        
        Plat plat = col.GetComponent<Plat>();
        
        if (plat && !plat.isHeld && plat.inStarGate) {

            //Ajouter des points de satisfaction au gars, etc
            float valeur = plat.valeurDuBol + 1;

            if (plat.cookingState == Plat.CookingState.good) {
                gameManager.satisfaction += gameManager.goodScore * valeur;
            } else if (plat.cookingState == Plat.CookingState.perfect) {
                gameManager.satisfaction += gameManager.perfectScore * valeur;
            } else {
                gameManager.satisfaction += gameManager.badScore * valeur;
            }

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

using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static SoundManager instance;

    void Awake() {
        instance = this;
    }

    public AudioClip bip, cuissonLoop, debutCuisson, ding, explosion, fermerPorte, finCuisson, geigerLoop, 
                    neverAsked, manScreaming, ouvrirPorte, placerPlat, retirerPlat, suicidehour, stargate;

}

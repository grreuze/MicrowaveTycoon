using UnityEngine;

public class CompteurGeiger : MonoBehaviour {

    public float minAngle = 85, maxAngle = -85;
    public float minRadiation = 0, maxRadiation = 50;
    float rot, lastRot;

    AudioSource geigerLoop;
    GameManager gameManager;
    Transform transformCache;
    public SpriteRenderer allumage;
    public Material eteint, allume;
    public Transform machine;

	void Start () {
        gameManager = GameManager.instance;
        geigerLoop = GetComponent<AudioSource>();
        transformCache = transform;
	}
	
	void Update () {
        lastRot = rot;
        gameManager.radiations = Mathf.Clamp(gameManager.radiations, minRadiation, maxRadiation);
        geigerLoop.volume = Mathf.Lerp(0, 0.5f, gameManager.radiations / maxRadiation);

        if (gameManager.radiations >= maxRadiation) {
            gameManager.EndGame();
        }

        float rad = gameManager.radiations / maxRadiation;
        rot = Mathf.Lerp(minAngle, maxAngle, rad);
        transformCache.localRotation = Quaternion.Euler(0, 0, rot);
        if (rot < lastRot) {
            if (!geigerLoop.isPlaying)
                geigerLoop.Play();
            allumage.material = allume;         //Pour allumer et éteindre la diode qui indique qu'on se prend des rads
        } else {
            if (geigerLoop.isPlaying)
                geigerLoop.Stop();
            allumage.material = eteint;
        }
    }
}

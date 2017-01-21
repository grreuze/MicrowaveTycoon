using UnityEngine;

public class CompteurGeiger : MonoBehaviour {

    public float minAngle = 60, maxAngle = -60;
    public float minRadiation = 0, maxRadiation = 50;

    GameManager gameManager;
    Transform transformCache;

	void Start () {
        gameManager = GameManager.instance;
        transformCache = transform;
	}
	
	void Update () {
        gameManager.radiations = Mathf.Clamp(gameManager.radiations, minRadiation, maxRadiation);
        float rad = gameManager.radiations / maxRadiation;
        float rot = Mathf.Lerp(minAngle, maxAngle, rad);
        transformCache.localRotation = Quaternion.Euler(0, 0, rot);
	}
}

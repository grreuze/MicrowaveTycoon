using UnityEngine;

public class BouffeManager : MonoBehaviour {

    [Header("VARIABLES")]
    /// <summary>
    /// Interval de temps entre l'arrivée de chaque plat
    /// </summary>
    public float interval = 2;
    public int difficultyLevel;
    public Vector2 instantiatePosition;
    
    [Header("LES PLATS")]
    public listeDePlats[] listesDePlatsSelonLeNiveauDeDifficulté;

    [System.Serializable]
    public struct listeDePlats {
        public GameObject[] plats;
    }

    [HideInInspector]
    public GameObject pool;

    float lastTimeInstantiated;

    void Awake() {
		pool = new GameObject();
        pool.name = "Pool";
        instantiatePosition = transform.position;
        lastTimeInstantiated = -interval; // To Spawn the first at 0 seconds
    }
    
	void Update () {
		
        if (Time.time >= lastTimeInstantiated + interval) {

            listeDePlats liste = listesDePlatsSelonLeNiveauDeDifficulté[difficultyLevel];
            SpawnBouffe(liste.plats[Random.Range(0, liste.plats.Length)]);
            lastTimeInstantiated = Time.time;
        }

	}

    void SpawnBouffe(GameObject prefab) {

        Transform transformDuPlat = pool.transform.Find(prefab.name);
        if (transformDuPlat) {
            transformDuPlat.parent = null;
            transformDuPlat.localPosition = instantiatePosition;
            transformDuPlat.gameObject.SetActive(true);
        } else {
            GameObject nouveauPlat = Instantiate(prefab, instantiatePosition, Quaternion.identity);
            nouveauPlat.name = prefab.name;
        }
    }
}

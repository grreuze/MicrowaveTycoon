using UnityEngine;

public class BouffeManager : MonoBehaviour {

    [Header("VARIABLES")]
    /// <summary>
    /// Interval de temps entre l'arrivée de chaque plat
    /// </summary>
    public float interval = 2;
    public int difficultyLevel;
    public Vector2 instantiatePosition;
    public bool needToSpawnKey = true;
    
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
            transformDuPlat = nouveauPlat.transform;
        }
        if (needToSpawnKey && Random.value > 0.7f) SpawnKey(transformDuPlat);
    }

    Key key;
    void SpawnKey(Transform transform) {

        if (!key) {
            key = FindObjectOfType<Key>();
        }
        key.transform.parent = transform;
        key.transform.localPosition = Vector2.zero;
        key.rb.bodyType = RigidbodyType2D.Kinematic;
        key.rb.velocity = Vector2.zero;
        key.rb.gravityScale = 1;
        key.collider.isTrigger = true;
        key.gameObject.SetActive(true);

        needToSpawnKey = false;
    }

}

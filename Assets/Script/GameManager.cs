using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    [Header("Stuff")]
    public GameObject[] apparencesDeBols = new GameObject[5];
    public Material matDefault, matCuit, matTropCuit;

    [Header("Variables")]
    public float timeModifier = 1;
    public float satisfaction = 50;
    public float radiations;

    public float goodScore, badScore, perfectScore;

    void Awake () {
        instance = this;
	}

    void Update() {
        satisfaction -= Time.deltaTime;
    }
}

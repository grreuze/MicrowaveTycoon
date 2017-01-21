using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    [Header("Stuff")]
    public GameObject[] apparencesDeBols = new GameObject[5];
    public Material matDefault, matCuit, matTropCuit;

    [Header("Variables")]
    public float timeModifier = 1;
    
    void Awake () {
        instance = this;
	}
}

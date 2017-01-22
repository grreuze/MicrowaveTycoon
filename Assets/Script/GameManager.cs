using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    [Header("STUFF")]
    public GameObject[] apparencesDeBols = new GameObject[5];
    public Material matDefault, matCuit, matTropCuit;
    public Slider satisfactionSlider;
    public Sprite maskDoorOn, maskDoorOff;
    public Key key;
    public MetallicObject[] metallicObjects;

    public ParticleSystem endExplosion;

    [Header("VARIABLES")]
    public float timeModifier = 1;
    public float satisfaction = 50;
    public float radiations;

    public float goodScore, badScore, perfectScore;

    Avatar avatar;

    bool isOver;

    void Awake () {
        instance = this;
        avatar = FindObjectOfType<Avatar>();
	}

    void Update() {
        satisfaction -= Time.deltaTime;
        satisfaction = Mathf.Min(satisfaction, 100);
        satisfactionSlider.value = satisfaction;
        if (satisfaction <= 0) {
            EndGame();
        }
    }

    public void EndGame() {
        if (isOver) return;
        isOver = true;

        Camera.main.GetComponent<AudioSource>().Play();
        endExplosion.Play();
        avatar.KOScreen.enabled = true;

        Invoke("GoToEndScene", endExplosion.main.duration);
    }

    public void GoToEndScene() {
        SceneManager.LoadScene(3);
    }
}

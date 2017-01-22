﻿using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    [Header("STUFF")]
    public GameObject[] apparencesDeBols = new GameObject[5];
    public Material matDefault, matCuit, matTropCuit;
    public Slider satisfactionSlider;
    public Sprite maskDoorOn, maskDoorOff;
    public Key key;
    public MetallicObject[] metallicObjects;

    [Header("VARIABLES")]
    public float timeModifier = 1;
    public float satisfaction = 50;
    public float radiations;

    public float goodScore, badScore, perfectScore;

    void Awake () {
        instance = this;
	}

    void Update() {
        satisfaction -= Time.deltaTime;
        satisfaction = Mathf.Min(satisfaction, 100);
        satisfactionSlider.value = satisfaction;
    }

}

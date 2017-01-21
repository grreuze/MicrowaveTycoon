using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour {

    public GameObject[] apparencesDeBols = new GameObject[5];
    public static PrefabManager instance;

    // Use this for initialization
    void Awake ()
    {
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

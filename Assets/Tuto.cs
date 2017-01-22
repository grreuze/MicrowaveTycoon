using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tuto : MonoBehaviour {

    public Transform camTarget;
    Vector3 reference;
    public GameObject buttonNext, buttonPlay;
    bool moveToNextScreen;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(moveToNextScreen) Camera.main.transform.position = Vector3.SmoothDamp(Camera.main.transform.position, camTarget.position, ref reference, 1);
        if(Camera.main.transform.position.x >= camTarget.position.x - 0.05f)
        {
            moveToNextScreen = false;
            buttonPlay.SetActive(true);
        }
	}

    public void ButtonNext()
    {
        moveToNextScreen = true;
        buttonNext.SetActive(false);       
    }

    public void ButtonPlay()
    {
        SceneManager.LoadScene(2);
    }
}

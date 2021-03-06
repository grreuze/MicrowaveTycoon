﻿using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour {
    
    [SerializeField]
    GameObject defaultButtonSelected;

    #region PrivateMethods

    void Start() {
        SelectDefaultButton();
    }

    void Update() {
        if (Input.GetAxis("Vertical") != 0 && !EventSystem.current.currentSelectedGameObject)
            SelectDefaultButton();
    }

    void SelectDefaultButton() {
        if (defaultButtonSelected)
            EventSystem.current.SetSelectedGameObject(defaultButtonSelected);
    }

    #endregion

    public void LoadScene(int sceneToLoad) {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void LoadScene(string sceneToLoad) {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void ExitGame() {
        Application.Quit();
    }
}

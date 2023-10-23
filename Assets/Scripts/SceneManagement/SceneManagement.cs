using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour {

    // Animator sceneloadScreen;
    // void Awake() {
        // sceneloadScreen = GameObject.FindWithTag("Sceneload_Screen").GetComponent<Animator>();
    // }

    public static void StaticChangeScene(string scene) {
        SceneManager.LoadScene(scene);
    }

    public void ChangeScene(string scene) {
        SceneManager.LoadScene(scene);
        // StartCoroutine(SceneLoadScreen(scene));
    }

    // IEnumerator SceneLoadScreen(string scene) {
    //     sceneloadScreen.SetTrigger("LoadLevel");
    //     var delay = 1;
    //     yield return new WaitForSeconds(delay);
    //     SceneManager.LoadScene(scene);
    // }
    
    public void EndGame() {
        Application.Quit();
    }
}
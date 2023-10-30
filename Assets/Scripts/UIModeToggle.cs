using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class UIModeToggle : MonoBehaviour {
    [SerializeField] GameObject detectionCanvasUI;
    [SerializeField] GameObject detectionNonCanvas;
    [SerializeField] GameObject manualCanvasUI;
    [SerializeField] GameObject manualNonCanvas;

    static UIModeToggle instance;

    void Start(){
        instance = this.GetComponent<UIModeToggle>();
        toggleManual(true);
    }

    public static void toggleManual(bool action){
        instance.manualCanvasUI.SetActive(action);
        instance.manualNonCanvas.SetActive(action);
        instance.detectionCanvasUI.SetActive(!action);
        instance.detectionNonCanvas.SetActive(!action);
        VuforiaBehaviour.Instance.enabled = !action;
    }
}

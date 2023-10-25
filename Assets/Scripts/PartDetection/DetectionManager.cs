using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;

public class DetectionManager : MonoBehaviour {
    [SerializeField] public GameObject manualFolder;
    // [SerializeField] GameObject detectionFolder;
    [SerializeField] UnityEngine.UI.Image partDetectionSignifier;
    string currentPartName;

    void Awake() {
        currentPartName = "";
    }
    
    public void SearchForPart(GameObject _inputPart){
        VuforiaBehaviour.Instance.enabled = true;
        manualFolder.SetActive(false);
        GameObject partToScan = _inputPart.GetComponentInChildren<PartButton>().partNeeded; 
        currentPartName = partToScan.name;
        Debug.Log(currentPartName);
    }

    public void PartDetected(GameObject foundPart){
        Debug.Log(foundPart.name);
        if (foundPart.name == currentPartName) {
            partDetectionSignifier.color = new Color32(0,255,0,255);
            Invoke("ForceEndSearch",2.5f);   
        }
    }

    public void PartLost(GameObject lostPart){
        if (lostPart.name == currentPartName) {
            partDetectionSignifier.color = new Color32(255,0,0,255);
        }
    }
    public void TryToEndSearch(GameObject foundPart){
        
        // if (FoundPart.name == currentPartName) {
        //     currentPartName = "";
        //     manualFolder.SetActive(true);
        //     VuforiaBehaviour.Instance.enabled = false;
        // }
    }

    public void ForceEndSearch() {
        partDetectionSignifier.color = new Color32(255,0,0,255);
        VuforiaBehaviour.Instance.enabled = false;
        currentPartName = "";
        manualFolder.SetActive(true);   
    }
}

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
    
    public void SearchForPart(GameObject partToScan){
        VuforiaBehaviour.Instance.enabled = true;
        manualFolder.SetActive(false);
        currentPartName = partToScan.name;
    }

    public void PartDetected(GameObject foundPart){
        GameObject part = foundPart.GetComponentInChildren<PartButton>().partNeeded; 
        if (part.name == currentPartName) {
            partDetectionSignifier.color = new Color32(0,255,0,100);
            Invoke("ForceEndSearch",2.5f);   
        }
    }

    public void PartLost(GameObject lostPart){
        if (lostPart.name == currentPartName) {
            partDetectionSignifier.color = new Color32(255,0,0,100);
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
        VuforiaBehaviour.Instance.enabled = false;
        currentPartName = "";
        manualFolder.SetActive(true);   
    }
}

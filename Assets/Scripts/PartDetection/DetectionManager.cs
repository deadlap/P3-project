using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DetectionManager : MonoBehaviour {
    [SerializeField] UnityEngine.UI.Image partDetectionSignifier;
    string currentPartName;

    void Awake() {
        currentPartName = "";
    }
    
    public void SearchForPart(GameObject _inputPart){
        UIModeToggle.toggleManual(false);
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

    public void ForceEndSearch() {
        partDetectionSignifier.color = new Color32(255,0,0,255);
        currentPartName = "";
        UIModeToggle.toggleManual(true);
    }
}

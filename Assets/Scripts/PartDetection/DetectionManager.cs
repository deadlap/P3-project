using TMPro;
using UnityEngine;

public class DetectionManager : MonoBehaviour {
    [SerializeField] UnityEngine.UI.Image partDetectionSignifier;
    string currentPartName;
    [SerializeField] TMP_Text partText;
    void Awake() {
        currentPartName = "";
    }
    
    public void SearchForPart(GameObject _inputPart){
        UIModeToggle.toggleManual(false);
        GameObject partToScan = _inputPart.GetComponentInChildren<PartButton>().partNeeded;
        currentPartName = partToScan.name;
        Debug.Log(currentPartName);
        partText.text = $"Scan \"{partToScan.GetComponent<PartInfo>().partName}\"";
    }

    public void PartDetected(GameObject foundPart){
        Debug.Log(foundPart.name);
        if (foundPart.name == currentPartName) {
            Invoke("ForceEndSearch",2.5f);   
        }
    }

    public void PartLost(GameObject lostPart){
        if (lostPart.name == currentPartName) {
        }
    }

    public void ForceEndSearch() {
        currentPartName = "";
        UIModeToggle.toggleManual(true);
    }
}

using System;
using TMPro;
using UnityEngine;

public class DetectionManager : MonoBehaviour {
    [SerializeField] UnityEngine.UI.Image partImage;
    [SerializeField] TMP_Text partText;

    [SerializeField] TMP_Text scanText;
    [SerializeField] UnityEngine.UI.Image scanTextBackground;

    [SerializeField] string noObjectText;
    [SerializeField] string wrongObjectText;
    [SerializeField] string correctObjectText;

    [SerializeField] Color noObjectColor;
    [SerializeField] Color wrongObjectColor;
    [SerializeField] Color correctObjectColor;

    [SerializeField] int countDownTime;
    float currentCountDown;
    bool partFound;
    string currentPartName;
    void Awake() {
        currentPartName = "";
        partFound = false;
    }

    void Update(){
        if (partFound) {
            currentCountDown -= Time.deltaTime;
            scanText.text = correctObjectText + (int)MathF.Ceiling(currentCountDown);
            if (currentCountDown < 0) {
                ForceEndSearch();
            }
        }
    }
    
    public void SearchForPart(GameObject _inputPart){
        UIModeToggle.toggleManual(false);
        
        GameObject partToScan = _inputPart.GetComponentInChildren<PartButton>().partNeeded;
        currentPartName = partToScan.name;
        
        Debug.Log(currentPartName);
        
        partText.text = $"Scan \"{partToScan.GetComponent<PartInfo>().partName}\"";
        partImage.sprite = partToScan.GetComponent<PartInfo>().partSprite;

        scanText.text = noObjectText;
        scanTextBackground.color = noObjectColor;
    }

    public void PartDetected(GameObject foundPart){
        Debug.Log(foundPart.name);
        if (foundPart.name == currentPartName) {
            // Invoke("ForceEndSearch",15f);
            partFound = true;
            currentCountDown = countDownTime;
            scanText.text = correctObjectText;
            scanTextBackground.color = correctObjectColor;
        } else {
            scanText.text = wrongObjectText;
            scanTextBackground.color = wrongObjectColor;
        }
    }

    public void PartLost(GameObject lostPart){
        scanText.text = noObjectText;
        scanTextBackground.color = noObjectColor;
        partFound = false;
    }

    public void ForceEndSearch() {
        scanText.text = noObjectText;
        scanTextBackground.color = noObjectColor;
        partFound = false;
        currentPartName = "";
        UIModeToggle.toggleManual(true);
    }
}
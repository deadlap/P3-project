using System;
using TMPro;
using UnityEngine;

public class DetectionManager : MonoBehaviour {
    [Header("GameObjects")]
    [SerializeField] UnityEngine.UI.Image partImage;
    [SerializeField] TMP_Text partText;

    [SerializeField] TMP_Text scanText;
    [SerializeField] UnityEngine.UI.Image scanningStatusImage;
    [SerializeField] UnityEngine.UI.Button scanningStatusButton;
    [Header("Strings")]
    [SerializeField] [TextArea] string noObjectText;
    [SerializeField] [TextArea] string wrongObjectText;
    [SerializeField] [TextArea] string correctObjectText;
    [Header("Colors")]
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
        scanningStatusButton.enabled = false;
        GameObject partToScan = _inputPart.GetComponentInChildren<PartButton>().partNeeded;
        currentPartName = partToScan.name;
        
        Debug.Log(currentPartName);
        
        partText.text = $"Scan \"{partToScan.GetComponent<PartInfo>().partName}\"";
        partImage.sprite = partToScan.GetComponent<PartInfo>().partSprite;

        scanText.text = noObjectText;
        scanningStatusImage.color = noObjectColor;
    }

    public void PartDetected(GameObject foundPart){
        Debug.Log(foundPart.name);
        if (foundPart.name == currentPartName) {
            Handheld.Vibrate();
            scanningStatusButton.enabled = true;
            partFound = true;
            currentCountDown = countDownTime;
            scanText.text = correctObjectText;
            scanningStatusImage.color = correctObjectColor;
        } else {
            scanText.text = wrongObjectText;
            scanningStatusImage.color = wrongObjectColor;
        }
    }

    public void PartLost(GameObject lostPart){
        scanText.text = noObjectText;
        scanningStatusImage.color = noObjectColor;
        partFound = false;
    }

    public void ForceEndSearch() {
        scanText.text = noObjectText;
        scanningStatusImage.color = noObjectColor;
        partFound = false;
        currentPartName = "";
        UIModeToggle.toggleManual(true);
    }
}
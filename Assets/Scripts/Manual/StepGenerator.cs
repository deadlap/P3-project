using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StepGenerator : MonoBehaviour {
    [SerializeField] GameObject buttonPrefab;
    [SerializeField] GameObject instructionParentObject;
    void Start() {
        var delay = 0.00001f;
        Invoke(nameof(GenerateStep), delay);
    }

    public void GenerateStep(){
        ManualStep thisStep = ManualFetcher.CurrentManualStep();
        GameObject.Instantiate(thisStep.instruction, instructionParentObject.transform);
        if (ManualFetcher.CurrentParts().Count <= 0) return;
        for (int i = 0; i < ManualFetcher.CurrentParts().Count; i++) {
            GameObject button = GameObject.Instantiate(buttonPrefab, this.transform);
            button.GetComponent<PartButton>().SetPart(
                thisStep.parts[i],
                thisStep.amounts[i],
                thisStep.parts[i].GetComponent<PartInfo>().partSprite
                );
            button.SetActive(true);
        }
    }
    public void DestroyChildren(){
        if (this.transform.childCount != 0) {
            foreach (Transform child in this.transform){
                Destroy(child.gameObject);
            }
        }
        if (instructionParentObject.transform.childCount != 0) {
            foreach (Transform child in instructionParentObject.transform){
                Destroy(child.gameObject);
            }
        }
    }

    void Update() {
        switch (transform.childCount) {
            case < 4:
                GetComponent<GridLayoutGroup>().cellSize = new Vector2(250, 250); 
                break;
            case > 3:
                GetComponent<GridLayoutGroup>().cellSize = new Vector2(190, 190);
                break;
        }
    }
}

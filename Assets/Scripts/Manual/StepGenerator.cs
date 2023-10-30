using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepGenerator : MonoBehaviour {
    [SerializeField] GameObject buttonPrefab;
    [SerializeField] GameObject instructionParentObject;
    void Start(){
        GenerateStep();
    }

    public void GenerateStep(){
        ManualStep thisStep = ManualFetcher.CurrentManualStep();
        for (int i = 0; i < ManualFetcher.CurrentParts().Count; i++) {
            GameObject button = GameObject.Instantiate(buttonPrefab, this.transform);
            button.GetComponentInChildren<PartButton>().SetPart(
                thisStep.parts[i],
                thisStep.amounts[i],
                thisStep.parts[i].GetComponent<PartSprite>().partSprite
                );
            button.SetActive(true);
        }
        GameObject.Instantiate(thisStep.instruction, instructionParentObject.transform);
    }
    public void DestroyChildren(){
        foreach (Transform child in this.transform){
            Destroy(child.gameObject);
        }
        foreach (Transform child in instructionParentObject.transform){
            Destroy(child.gameObject);
        }
    }
}

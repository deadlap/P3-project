using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepGenerator : MonoBehaviour {
    [SerializeField] GameObject buttonPrefab;
    public void GenerateStep(){
        ManualStep thisStep = ManualFetcher.CurrentManualStep();
        for (int i = 0; i < ManualFetcher.CurrentParts().Count; i++) {
            GameObject button = GameObject.Instantiate(buttonPrefab);
            button.transform.parent = this.transform;
            button.GetComponentInChildren<PartButton>().SetPart(thisStep.parts[i],thisStep.amounts[i]);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class StepNumberVisualizer : MonoBehaviour {
    
    private TextMeshProUGUI  stepText;

    // Start is called before the first frame update
    void Start() {
        stepText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update() {
        stepText.text = "Step nr. " + StepCounter.CurrentStep + " of " + StepCounter.MaxSteps;
    }
}

using UnityEngine;
using TMPro;
public class StepNumberVisualizer : MonoBehaviour {
    
    TextMeshProUGUI  stepText;

    // Start is called before the first frame update
    void Start() {
        stepText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update() {
        stepText.text = $"Step {StepCounter.CurrentStep}/{StepCounter.MaxSteps}";
    }
}

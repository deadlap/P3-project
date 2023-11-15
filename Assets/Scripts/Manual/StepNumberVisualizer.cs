using UnityEngine;
using TMPro;
public class StepNumberVisualizer : MonoBehaviour {
    
    TextMeshProUGUI  stepText;
    
    [Header("Text")] [SerializeField] [TextArea(5, 10)]
    string finishedManualPrompt;

    public static StepNumberVisualizer instance;

    void Start() {
        instance = this;
        stepText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    public static void UpdateText() {
        if (StepCounter.CurrentStep < StepCounter.MaxSteps ) {
            instance.stepText.text = $"Step {StepCounter.CurrentStep}/{StepCounter.MaxSteps}";
        } else {
            instance.stepText.text = instance.finishedManualPrompt;
        }
    }
}

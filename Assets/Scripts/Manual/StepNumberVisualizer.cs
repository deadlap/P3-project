using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class StepNumberVisualizer : MonoBehaviour {
    
    TextMeshProUGUI  stepText;
    
    [Header("Text")] [SerializeField] [TextArea(5, 10)]
    string finishedManualPrompt;

    public static StepNumberVisualizer instance;

    void Start() {
        instance = this;
        stepText = GetComponent<TextMeshProUGUI>();
    }

    void Update() {
        if (StepCounter.CurrentStep < StepCounter.MaxSteps)
            instance.stepText.text = $"Trin {StepCounter.CurrentStep}/{StepCounter.MaxSteps}";
        else
            instance.stepText.text = instance.finishedManualPrompt;
    }
}

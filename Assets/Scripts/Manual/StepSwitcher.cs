using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepSwitcher : MonoBehaviour {
    [SerializeField] StepGenerator generator;
    [SerializeField] GameObject finishManualButton;
    public void ChangeStep(int change){
        StepCounter.UpdateStepNumber(change);
        InstructionRotation.ForceResetRotation();
        generator.DestroyChildren();
        generator.GenerateStep();
        if (StepCounter.CurrentStep < StepCounter.MaxSteps ) {
            finishManualButton.SetActive(false);
        } else {
            finishManualButton.SetActive(true);
        }
    }
}

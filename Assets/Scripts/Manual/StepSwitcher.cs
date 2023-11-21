using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepSwitcher : MonoBehaviour {
    [SerializeField] StepGenerator generator;
    [SerializeField] GameObject finishManualButton;
    [SerializeField] GameObject nextStepButton;
    [SerializeField] GameObject previousStepButton;
    [SerializeField] GameObject sliderArea;

    void Start() {
        nextStepButton.SetActive(true);
        previousStepButton.SetActive(false);
        sliderArea.SetActive(true);
    }

    public void ChangeStep(int change){
        StepCounter.UpdateStepNumber(change);
        InstructionRotation.ForceResetRotation();
        generator.DestroyChildren();
        generator.GenerateStep();
        if(InstructionAnimationManipulator.instance.isPlaying == false)
            InstructionAnimationManipulator.instance.SwitchPlayState();
        if(InstructionAnimationManipulator.instance.speedMenuOpened)
            InstructionAnimationManipulator.instance.OpenSpeedMenu();
        if (StepCounter.CurrentStep == 1) {
            previousStepButton.SetActive(false);
            sliderArea.SetActive(true);
        } else if (StepCounter.CurrentStep < StepCounter.MaxSteps && StepCounter.CurrentStep != 1) {
            previousStepButton.SetActive(true);
            nextStepButton.SetActive(true);
            finishManualButton.SetActive(false);
            sliderArea.SetActive(true);
        } else {
            previousStepButton.SetActive(true);
            nextStepButton.SetActive(false);
            finishManualButton.SetActive(true);
            sliderArea.SetActive(false);
        }
    }
}

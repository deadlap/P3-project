using UnityEngine;

public class StepSwitcher : MonoBehaviour {
    [SerializeField] StepGenerator generator;
    [SerializeField] GameObject finishManual;
    [SerializeField] GameObject nextStepButton;
    [SerializeField] GameObject previousStepButton;
    [SerializeField] GameObject sliderArea;
    [SerializeField] Camera camera;

    void Start() {
        nextStepButton.SetActive(true);
        previousStepButton.SetActive(false);
        sliderArea.SetActive(true);
        finishManual.SetActive(false);
    }
    
    public void ChangeStep(int change){
        StepCounter.UpdateStepNumber(change);
        InstructionRotation.ForceResetRotation();
        generator.DestroyChildren();
        generator.GenerateStep();
        ProgressDotHandler.instance.HighlightDot(StepCounter.CurrentStep);
        camera.fieldOfView = PinchZoom.instance.defaultZoomValue;
        if(InstructionAnimationManipulator.instance.isPlaying == false)
            InstructionAnimationManipulator.instance.SwitchPlayState();
        if(InstructionAnimationManipulator.instance.speedMenuOpened)
            InstructionAnimationManipulator.instance.OpenSpeedMenu();
        if (StepCounter.CurrentStep == 1) {
            previousStepButton.SetActive(false);
            sliderArea.SetActive(true);
            finishManual.SetActive(false);
        } else if (StepCounter.CurrentStep < StepCounter.MaxSteps && StepCounter.CurrentStep != 1) {
            previousStepButton.SetActive(true);
            nextStepButton.SetActive(true);
            finishManual.SetActive(false);
            sliderArea.SetActive(true);
        } else {
            previousStepButton.SetActive(true);
            nextStepButton.SetActive(false);
            finishManual.SetActive(true);
            sliderArea.SetActive(false);
        }
    }
}

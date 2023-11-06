using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepSwitcher : MonoBehaviour {
    [SerializeField] StepGenerator generator;
    public void ChangeStep(int change){
        StepCounter.ChangeStep(change);
        InstructionRotation.ForceResetCamera();
        generator.DestroyChildren();
        generator.GenerateStep();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepSwitcher : MonoBehaviour {
    [SerializeField] StepGenerator generator;
    public void ChangeStep(int change){
        if (change < 0) {
            if (StepCounter.PreviousStep()){
                generator.DestroyChildren();
                generator.GenerateStep();
            }
        } else {
            if (StepCounter.NextStep()){
                generator.DestroyChildren();
                generator.GenerateStep();
            }
        }
    }
}

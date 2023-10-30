using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepSwitcher : MonoBehaviour {
    [SerializeField] StepGenerator generator;
    public void ChangeStep(int change){
        StepCounter.ChangeStep(change);
        generator.DestroyChildren();
        generator.GenerateStep();
    }
}

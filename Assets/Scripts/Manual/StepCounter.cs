using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepCounter : MonoBehaviour {
    public static int CurrentStep {get; private set;} //Step/page the user is currently on
    public static int ReachedStep {get; private set;} //Last step the user has completed
    public static int MaxSteps {get; private set;}
    void Start(){
        CurrentStep = 1;
        ReachedStep = 1;
        MaxSteps = ManualFetcher.GetManual().steps.Count;
    }
    public static bool NextStep(){
        CurrentStep += 1;
        if (CurrentStep > ReachedStep) {
            ReachedStep = CurrentStep;
        }
        if (CurrentStep >= MaxSteps) {
            CurrentStep = MaxSteps;
            ReachedStep = MaxSteps;
            return false;
        }
        return true;
    }
    public static bool PreviousStep(){
        if (CurrentStep > 1){
            CurrentStep -= 1;
            return true;
        } else {
            CurrentStep = 1;
            return false;
        }
    }
}

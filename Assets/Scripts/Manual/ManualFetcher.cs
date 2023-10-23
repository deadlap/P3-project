using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ManualFetcher : MonoBehaviour {
    public static Manual CurrentManual;
    void Start() {
        CurrentManual = this.GetComponent<Manual>();
    }

    public static ManualStep CurrentManualStep(){
        return CurrentManual.steps[StepCounter.CurrentStep-1];
    }
    public static List<GameObject> CurrentParts(){
        return CurrentManual.steps[StepCounter.CurrentStep-1].parts;
    }
    public static List<int> CurrentAmounts(){
        return CurrentManual.steps[StepCounter.CurrentStep-1].amounts;
    }
    public static Manual GetManual(){
        return CurrentManual;
    }
}

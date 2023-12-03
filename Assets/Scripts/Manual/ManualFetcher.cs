using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualFetcher : MonoBehaviour {
    public static Manual CurrentManual;
    static int indexCorrection = 1;
    void Awake() {
        CurrentManual = this.GetComponent<Manual>();
    }

    public static ManualStep CurrentManualStep() {
        return CurrentManual.steps[StepCounter.CurrentStep-indexCorrection];
    }
    public static List<GameObject> CurrentParts(){
        return CurrentManual.steps[StepCounter.CurrentStep-indexCorrection].parts;
    }
    public static List<int> CurrentAmounts(){
        return CurrentManual.steps[StepCounter.CurrentStep-indexCorrection].amounts;
    }
    public static Manual GetManual(){
        return CurrentManual;
    }
}

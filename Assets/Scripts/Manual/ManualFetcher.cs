using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ManualFetcher {
    public static ManualStep CurrentManualStep(){
        return StepSwitcher.CurrentManual.steps[StepCounter.CurrentStep];
    }
    public static List<GameObject> CurrentParts(){
        return StepSwitcher.CurrentManual.steps[StepCounter.CurrentStep].parts;
    }
    public static List<int> CurrentAmounts(){
        return StepSwitcher.CurrentManual.steps[StepCounter.CurrentStep].amounts;
    }
}

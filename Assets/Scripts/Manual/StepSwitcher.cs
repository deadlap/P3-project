using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepSwitcher : MonoBehaviour {
    // Start is called before the first frame update
    public static Manual CurrentManual;
    [SerializeField] StepGenerator generator;
    void Start() {
        CurrentManual = Resources.Load<Manual>("ScriptableObjectManuals/MachineVise");
        generator.GenerateStep();
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void ChangeStep(int change){
        if (change < 0) {
            if (StepCounter.PreviousStep()){
                generator.GenerateStep();
            }
        } else {
            if (StepCounter.NextStep()){
                generator.GenerateStep();
            }

        }
    }
}

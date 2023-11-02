using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instruction : MonoBehaviour {
    [SerializeField] bool isInstruction;
    public static GameObject INSTANCEGAMEOBJECT {get; private set;}
    // Start is called before the first frame update
    void Start() {
        if(isInstruction){
            INSTANCEGAMEOBJECT = this.transform.gameObject;
        }
    }
    // public static void ResetRotation(){
    //     if (INSTANCEGAMEOBJECT) {
    //         INSTANCEGAMEOBJECT.transform.eulerAngles = new Vector3(0,0,0);
    //     }
    // }
}

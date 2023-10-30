using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionRotation : MonoBehaviour {
    Vector3 previousPosition;
    Vector3 positionDelta;
    void Start(){
        previousPosition = Vector3.zero;
        positionDelta = Vector3.zero;
    }

    void Update() {
        if(Input.GetMouseButton(0)){
            positionDelta = Input.mousePosition - previousPosition;
            transform.Rotate(transform.up, -Vector3.Dot(positionDelta, Camera.main.transform.right), Space.World);
            transform.Rotate(Camera.main.transform.right, Vector3.Dot(positionDelta, Camera.main.transform.up), Space.World);
        }
        previousPosition = Input.mousePosition;
    }
}

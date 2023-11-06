using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionRotation : MonoBehaviour {
    GameObject rotateAround;
    float speed = 20f;
    bool resetToDefault;
    static InstructionRotation instance;
    float resetSpeed = 200f;
    float resetThreshold = 80f;
    void Start(){
        rotateAround = transform.gameObject;
        instance = this;
        resetToDefault = false;
    }

    public static void ResetCamera(){
        instance.resetToDefault = true;
    }
    public static void ForceResetCamera(){
        instance.resetToDefault = false;
        Camera.main.transform.position = Vector3.zero;
        Camera.main.transform.rotation = Quaternion.Euler(0,0,0);
    }

    void Update() {
        if (resetToDefault){
            Camera.main.transform.RotateAround(
                rotateAround.transform.position,
                Camera.main.transform.position.x > 0 ? Vector3.up : Vector3.down,
                Time.deltaTime*resetSpeed
            );
            if (Vector3.Distance(Vector3.zero, Camera.main.transform.position) < resetThreshold) {
                Camera.main.transform.position = Vector3.zero;
                Camera.main.transform.rotation = Quaternion.Euler(0,0,0);
                resetToDefault = false;
            }
        }
        RotateCamera();
    }

    void RotateCamera() {
        if (Input.GetMouseButton(0)){
            resetToDefault = false;
            Camera.main.transform.RotateAround(
                rotateAround.transform.position,
                Vector3.up,
                Input.GetAxis("Mouse X") * speed);
            // Camera.main.transform.RotateAround(
            //     rotateAround.transform.position,
            //     Vector3.right,
            //     -Input.GetAxis("Mouse Y") * speed);
        }
    }
}

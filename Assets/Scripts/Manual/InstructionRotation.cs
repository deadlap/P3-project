using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionRotation : MonoBehaviour {
    GameObject rotateAround;
    float speed = 20f;
    void Start(){
        rotateAround = transform.gameObject;
    }

    public static void ResetCamera(){
        Camera.main.transform.position = Vector3.zero;
        Camera.main.transform.rotation = Quaternion.Euler(0,0,0);
    }

    void Update() {
        RotateCamera();
    }
    void RotateCamera() {
        if (Input.GetMouseButton(0)){
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

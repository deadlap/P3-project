using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InstructionRotation : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    [SerializeField] Image dragArea;
    [SerializeField] GameObject targetToOrbit;
    [SerializeField] GameObject arrow3d;
    [SerializeField] float rotationSpeed;
    [SerializeField] new Camera camera;
    //Vector3 localUp;
    //Vector3 localRight;
    bool resetToDefault;
    static InstructionRotation instance;
    float resetSpeed = 200f;
    float resetThreshold = 80f;

    void Awake()
    {
        instance = this;
    }

    void Start(){
        //targetToOrbit = transform.gameObject;
        //resetToDefault = false;
    }

    public void ResetCamera(){
        instance.resetToDefault = true;
    }
    public static void ForceResetCamera(){
        instance.resetToDefault = false;
        instance.camera.transform.position = Vector3.zero;
        instance.camera.transform.rotation = Quaternion.Euler(0,0,0);
    }

    void Update() {
        if (resetToDefault){
            camera.transform.RotateAround(
                targetToOrbit.transform.position,
                camera.transform.position.x > 0 ? Vector3.up : Vector3.down,
                Time.deltaTime*resetSpeed
            );
            if (Vector3.Distance(Vector3.zero, camera.transform.position) < resetThreshold) {
                camera.transform.position = Vector3.zero;
                camera.transform.rotation = Quaternion.Euler(0,0,0);
                resetToDefault = false;
            }
        }
        //RotateCamera();
    }

    void RotateCamera() {
        //if (!Input.GetMouseButton(0)) return;
        print("dragging");
        resetToDefault = false;
        camera.transform.RotateAround(
            targetToOrbit.transform.position, 
            Vector3.up, 
            Input.GetAxis("Mouse X") * rotationSpeed);
            // Camera.main.transform.RotateAround(
            //     targetToOrbit.transform.position,
            //     Vector3.right,
            //     -Input.GetAxis("Mouse Y") * speed);
    }

    public void OnDrag(PointerEventData eventData)
    {
        var target = targetToOrbit.transform.position;
        targetToOrbit.transform.Rotate(Vector3.down, eventData.delta.x * rotationSpeed);
        //camera.transform.RotateAround(target, Vector3.right, eventData.delta.x * rotationSpeed);
        //camera.transform.RotateAround(target, localRight, -eventData.delta.y * rotationSpeed);
        //^^^^Det er stadig vildt funky^^^^
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        arrow3d.SetActive(true);
        //localUp = targetToOrbit.transform.TransformDirection(Vector3.up);
        //localRight = targetToOrbit.transform.TransformDirection(Vector3.right);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        arrow3d.SetActive(false);
        //localUp = targetToOrbit.transform.TransformDirection(Vector3.up);
        //localRight = targetToOrbit.transform.TransformDirection(Vector3.right);
    }
}

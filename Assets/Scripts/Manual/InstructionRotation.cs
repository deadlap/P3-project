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
    bool resetToDefault;
    static InstructionRotation instance;
    [SerializeField] float resetSpeed;
    [SerializeField] float resetThreshold;

    void Awake()
    {
        instance = this;
    }

    void Start(){
        resetToDefault = false;
    }

    public void ResetRotation(){
        instance.resetToDefault = true;
    }

    public static void ForceResetRotation(){
        instance.resetToDefault = false;
        instance.targetToOrbit.transform.rotation = Quaternion.Euler(0,0,0);
    }

    void Update() {
        if (resetToDefault){
            Vector3 cur_rotation = targetToOrbit.transform.eulerAngles;
            targetToOrbit.transform.Rotate(
                0,
                cur_rotation.y < 180 ? -Time.deltaTime*resetSpeed : Time.deltaTime*resetSpeed,
                0
            );
            Debug.Log(Mathf.Abs(targetToOrbit.transform.rotation.y));
            if (Mathf.Abs(targetToOrbit.transform.eulerAngles.y) < resetThreshold) {
                ForceResetRotation();
            }
        }
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

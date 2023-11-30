using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PinchZoom : MonoBehaviour
{
    public static PinchZoom instance; 
    Vector2 firstFingerPos;
    Vector2 secondFingerPos;
    [SerializeField] Camera camera;
    [SerializeField] float zoomSpeed;
    float magnitude;
    float prevMagnitude;
    [HideInInspector] public bool isPinching;
    TouchDetection touchDetection;
    [HideInInspector] public float defaultZoomValue;

    void Awake()
    {
        instance = this;
        touchDetection = new TouchDetection();
        defaultZoomValue = camera.fieldOfView;
    }

    void OnEnable()
    {
        touchDetection.Enable();
    }

    void OnDisable()
    {
        touchDetection.Disable();
    }

    void Update()
    {
        PinchDetection();
    }

    void OnFirstFingerPosition(InputValue value)
    {
        firstFingerPos = value.Get<Vector2>();
    }

    void OnSecondFingerPosition(InputValue value)
    {
        secondFingerPos = value.Get<Vector2>();
    }

    void PinchDetection()
    {
        print($"Using two finger is {isPinching}");
        touchDetection.Zoom.SecondFingerContact.performed += _ => isPinching = true;
        touchDetection.Zoom.SecondFingerContact.canceled += _ => isPinching = false;
        if (!isPinching)
        {
            magnitude = 0;
            prevMagnitude = 0;
            return;
        }
        magnitude = (firstFingerPos - secondFingerPos).magnitude;
        if (prevMagnitude == 0)
            prevMagnitude = magnitude;
        var difference = magnitude - prevMagnitude;
        prevMagnitude = magnitude;
        Zoom(-difference * zoomSpeed);
    }

    void Zoom(float zoomValue)
    {
        camera.fieldOfView = Mathf.Clamp(camera.fieldOfView + zoomValue, 20, 80);
    }
}

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InstructionRotation : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    [SerializeField] Image dragArea;
    [SerializeField] GameObject targetToOrbit;
    [SerializeField] GameObject resetButton;
    static readonly float xRotation = -12f;
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
        resetButton.SetActive(false);
    }

    public void ResetRotation(){
        instance.resetToDefault = true;
    }

    public static void ForceResetRotation(){
        instance.resetToDefault = false;
        instance.targetToOrbit.transform.rotation = Quaternion.Euler(xRotation,0f,0f);
    }

    void FixedUpdate() { //for at undgå spasmer
        if (resetToDefault){
            Vector3 cur_rotation = targetToOrbit.transform.eulerAngles;
            targetToOrbit.transform.Rotate(
                0,
                cur_rotation.y < 180 ? -Time.deltaTime*resetSpeed : Time.deltaTime*resetSpeed,
                0
            );
            //Debug.Log(Mathf.Abs(targetToOrbit.transform.rotation.y));
            if (Mathf.Abs(targetToOrbit.transform.eulerAngles.y) < resetThreshold) {
                ForceResetRotation();
                resetButton.SetActive(false);
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (PinchZoom.instance.isPinching) return;
        var target = targetToOrbit.transform.position;
        targetToOrbit.transform.Rotate(Vector3.down, eventData.delta.x * rotationSpeed);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        resetButton.SetActive(true);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        resetButton.SetActive(false);
    }
}

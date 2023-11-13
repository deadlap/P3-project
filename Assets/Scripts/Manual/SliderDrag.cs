using UnityEngine;
using UnityEngine.EventSystems;

public class SliderDrag : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static SliderDrag Instance;
    public bool isDragging;
    void Awake() {
        Instance = this;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
    }
}

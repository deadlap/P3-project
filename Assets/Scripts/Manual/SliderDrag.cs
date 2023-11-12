using UnityEngine;
using UnityEngine.EventSystems;

public class SliderDrag : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    public static SliderDrag instance;
    public bool isDragging;
    // Start is called before the first frame update
    void Awake() {
        instance = this;
    }

    public void OnBeginDrag(PointerEventData eventData) {
        isDragging = true;
    }

    public void OnEndDrag(PointerEventData eventData) {
        isDragging = false;
    }
}

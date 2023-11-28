using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RatingScale : MonoBehaviour
{
    Color selectedColor = new(1, 1, 1, 1);
    Color notSelectedColor = new(1, 1, 1, .2f);
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<Image>().color = notSelectedColor;
        }
    }

    public void SelectRating(int index)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<Image>().color = notSelectedColor;
        }
        transform.GetChild(index).GetComponent<Image>().color = selectedColor;
    }
}

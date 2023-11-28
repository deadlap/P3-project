using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressDotHandler : MonoBehaviour
{
    public static ProgressDotHandler instance;
    int stepCount;
    [SerializeField] GameObject dotPrefab;
    List<GameObject> generatedDots = new();
    Color selectedColor = new (1, 1, 1, 1);
    Color notSelectedColor = new (1, 1, 1, .5f);
    Vector3 selectedSize = new Vector3(1.5f, 1.5f, 1.5f);
    Vector3 notSelectedSize = new Vector3(.9f, .9f, .9f);

    void Awake()
    {
        instance = this;
        GenerateProgressDots();
        HighlightDot(1);
    }

    void GenerateProgressDots()
    {
        stepCount = ManualFetcher.GetManual().steps.Count;
        for (int i = 0; i < stepCount; i++)
        {
            GameObject newDot = Instantiate(dotPrefab, transform.position, Quaternion.identity, gameObject.transform);
            generatedDots.Add(newDot);
        }
    }

    public void HighlightDot(int currentStep)
    {
        for (int i = 0; i < generatedDots.Count; i++)
        {
            generatedDots[i].gameObject.transform.localScale = notSelectedSize;
            generatedDots[i].GetComponent<Image>().color = notSelectedColor;
        }
        var indexCorrection = 1; //1 to get the correct index in the list
        generatedDots[currentStep-indexCorrection].GetComponent<Image>().color = selectedColor;
        generatedDots[currentStep-indexCorrection].gameObject.transform.localScale = selectedSize;
    }
}

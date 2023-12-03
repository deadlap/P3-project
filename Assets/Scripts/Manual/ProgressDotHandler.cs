using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressDotHandler : MonoBehaviour
{
    public static ProgressDotHandler instance;
    //int stepCount;
    [SerializeField] GameObject dotPrefab;
    List<GameObject> generatedDots = new();
    Color selectedColor = new (1, 1, 1, 1);
    Color notSelectedColor = new (1, 1, 1, .5f);
    Vector3 selectedSize = new Vector3(1.5f, 1.5f, 1.5f);
    Vector3 notSelectedSize = new Vector3(.9f, .9f, .9f);

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        print("currentstep" + StepCounter.CurrentStep);
        var delay = 0.001f;
        Invoke(nameof(GenerateProgressDots), delay);
    }

    void GenerateProgressDots()
    {
        for (int i = 0; i < StepCounter.MaxSteps; i++)
        {
            GameObject newDot = Instantiate(dotPrefab, transform.position, Quaternion.identity, gameObject.transform);
            generatedDots.Add(newDot);
        }
        HighlightDot(1);
    }

    public void HighlightDot(int currentStep)
    {
        print($"highlight dot: {StepCounter.CurrentStep}");
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

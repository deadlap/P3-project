using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HelpButton : MonoBehaviour
{
    [SerializeField] bool isHelpButton;
    [Header("Text")] [SerializeField] [TextArea(5, 10)]
    string helpTextPrompt;

    [SerializeField] TMP_Text helpText;

    [Header("Images")]
    [SerializeField] Image helpButton;
    [SerializeField] Sprite helpIcon;
    [SerializeField] Sprite exitIcon;
    Color[] colors = {new (1,1,1,255), new (0,0,0,0)};

    [Header("GameObjects")]
    [SerializeField] GameObject helpPanel;
    [SerializeField] GameObject nyttigeTips;
    [SerializeField] GameObject manualObject;
    [SerializeField] GameObject manualButton;
    [SerializeField] GameObject otherButton;
    bool helpPressed;
    int menusClosed;

    void Start()
    {
        helpButton.sprite = helpIcon;
        helpText.text = helpTextPrompt;
        var delay = 0.01f;
        Invoke(nameof(HelpPressed), delay);
        Invoke(nameof(StartSetActive), delay);
    }

    public void HelpPressed()
    {
        menusClosed++;
        helpPressed = !helpPressed;
        helpPanel.SetActive(helpPressed);
        if(nyttigeTips)
            nyttigeTips.SetActive(helpPressed);
        if(manualObject && menusClosed > 2)
            manualObject.SetActive(!helpPressed);
        if(manualObject && menusClosed == 2 && !helpPressed && isHelpButton)
            manualObject.SetActive(true);
        if(manualButton && menusClosed == 2) 
            manualButton.SetActive(false);
        if (otherButton)
            otherButton.SetActive(!helpPressed);
        switch (helpPressed)
        {
            case false:
                helpButton.color = colors[0];
                helpButton.sprite = helpIcon;
                break;
            case true:
                helpButton.color = colors[1];
                helpButton.sprite = exitIcon;
                break;
        }
    }

    void StartSetActive()
    {
        manualButton.SetActive(true);
        manualObject.SetActive(false);
    }
}

using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HelpButton : MonoBehaviour
{
    [Header("Text")] [SerializeField] [TextArea(5, 10)]
    string helpTextPrompt;

    [SerializeField] TMP_Text helpText;

    [Header("Images")]
    [SerializeField] Image helpButton;
    [SerializeField] Sprite helpIcon;
    [SerializeField] Sprite exitIcon;

    [Header("GameObjects")] 
    [SerializeField] GameObject helpPanel;
    [SerializeField] GameObject manualObject;
    [SerializeField] GameObject textAndButtons;
    bool helpPressed;
    void Start()
    {
        helpButton.sprite = helpIcon;
        helpText.text = helpTextPrompt;
    }

    public void HelpPressed()
    {
        helpPressed = !helpPressed;
        helpPanel.SetActive(helpPressed);
        if(manualObject)
            manualObject.SetActive(!helpPressed);
        if(textAndButtons)
            textAndButtons.SetActive(!helpPressed);
        switch (helpPressed)
        {
            case true:
                helpButton.sprite = exitIcon;
                break;
            case false:
                helpButton.sprite = helpIcon;
                break;
        }
    }
}

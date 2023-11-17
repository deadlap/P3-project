using TMPro;
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
    Color[] colors = {new (255,255,255,255), new (0,0,0,255)};

    [Header("GameObjects")]
    [SerializeField] GameObject helpPanel;
    [SerializeField] GameObject manualObject;
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
}

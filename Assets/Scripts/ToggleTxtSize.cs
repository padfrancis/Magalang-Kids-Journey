using UnityEngine;
using UnityEngine.UI;

public class ToggleTxtSize : MonoBehaviour
{
    public Text displayText;
    public Button leftButton, rightButton;

    private int textSizeOption = 0;

    private void Start()
    {
        UpdateText();

        leftButton.onClick.AddListener(PreviousOption);
        rightButton.onClick.AddListener(NextOption);

        Data.OnLanguageChanged.AddListener(UpdateText);
    }

    void PreviousOption()
    {
        textSizeOption = (textSizeOption + 2) % 3;
        UpdateText();
    }

    void NextOption()
    {
        textSizeOption = (textSizeOption + 1) % 3;
        UpdateText();
    }

    void UpdateText()
    {
        string key = textSizeOption switch 
        {
            0 => "slow_text",
            1 => "normal_text",
            2 => "fast_text",
            _ => "normal_text"
        };
        displayText.text = Data.GetLocalizedText(key);
    }
}

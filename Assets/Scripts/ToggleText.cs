using UnityEngine;
using UnityEngine.UI;

public class ToggleText : MonoBehaviour
{
    public Text displayText;
    public Button leftButton, rightButton;

    private bool isEnabled = true;

    private void Start()
    {
        UpdateText();

        leftButton.onClick.AddListener(PreviousOption);
        rightButton.onClick.AddListener(NextOption);

        Data.OnLanguageChanged.AddListener(UpdateText);
    }

    void PreviousOption()
    {
        isEnabled = !isEnabled;
        UpdateText();
    }

    void NextOption()
    {
        isEnabled = !isEnabled;
        UpdateText();
    }

    void UpdateText()
    {
        string key = isEnabled ? "enable_text" : "disable_text";
        displayText.text = Data.GetLocalizedText(key);
    }
}

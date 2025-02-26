using UnityEngine;
using UnityEngine.UI;

public class ArrowScript : MonoBehaviour
{
    public Text displayText; // The UI Text showing the selected language
    public Button leftButton, rightButton; // Left and Right arrow buttons
    public string[] textArray = { "English", "Filipino", "Ilocano" }; // Language options

    private int currentIndex = 0;

    private void Start()
    {
        // Load saved language (if exists)
        string savedLanguage = PlayerPrefs.GetString("SavedLanguage", "en");
        currentIndex = System.Array.IndexOf(Data.LANGUAGES, savedLanguage);
        if (currentIndex == -1) currentIndex = 0; // Default to first language

        UpdateText();

        leftButton.onClick.AddListener(PreviousLanguage);
        rightButton.onClick.AddListener(NextLanguage);
    }

    void PreviousLanguage()
    {
        currentIndex = (currentIndex - 1 + textArray.Length) % textArray.Length;
        UpdateText();
    }

    void NextLanguage()
    {
        currentIndex = (currentIndex + 1) % textArray.Length;
        UpdateText();
    }

    void UpdateText()
    {
        displayText.text = textArray[currentIndex];

        // Set the current language in Data.cs
        Data.CURRENT_LANGUAGE = Data.LANGUAGES[currentIndex];
        Data.OnLanguageChanged.Invoke(); // Notify all listeners

        // Save the selected language
        PlayerPrefs.SetString("SavedLanguage", Data.CURRENT_LANGUAGE);
        PlayerPrefs.Save();
    }
}

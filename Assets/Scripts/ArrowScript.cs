using UnityEngine;
using UnityEngine.UI;

public class ArrowScript : MonoBehaviour
{
    public Text displayText;
    public Button leftButton, rightButton;
    public string[] textArray = { "English", "Filipino", "Ilocano" };

    private int currentIndex = 0;

    private void Start()
    {
        string savedLanguage = PlayerPrefs.GetString("SavedLanguage", Data.CURRENT_LANGUAGE);
        currentIndex = System.Array.IndexOf(Data.LANGUAGES, savedLanguage);
        if (currentIndex == -1) currentIndex = 0;

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

        Data.CURRENT_LANGUAGE = Data.LANGUAGES[currentIndex];
        Data.OnLanguageChanged.Invoke();

        PlayerPrefs.SetString("SavedLanguage", Data.CURRENT_LANGUAGE);
        PlayerPrefs.Save();
    }
}

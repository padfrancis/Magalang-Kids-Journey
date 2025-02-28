using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextTranslator : MonoBehaviour
{
    Text _text;
    string _key;

    private void Awake()
    {
        Data.CURRENT_LANGUAGE = PlayerPrefs.GetString("SavedLanguage", Data.CURRENT_LANGUAGE);
        _text = GetComponent<Text>();
        _key = string.Copy(_text.text);

        _SetText();
        Data.OnLanguageChanged.AddListener(_SetText);

    }

    private void _SetText()
    {
        if (Data.LOCALIZATION.ContainsKey(_key))
        {
            _text.text = Data.LOCALIZATION[_key][Data.CURRENT_LANGUAGE];
        }
    }
}

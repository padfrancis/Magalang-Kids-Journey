using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextTranslator : MonoBehaviour
{
    private Text _text;
    private string _key;

    private void Awake()
    {
        _text = GetComponent<Text>();
        _key = _text.text.Trim();

        if (Data.LOCALIZATION.ContainsKey(_key))
        {
            _SetText();
            Data.OnLanguageChanged.AddListener(_SetText);
        }
        else
        {
            Debug.LogWarning($"Localization key '{_key}' not found.");
        }
    }

    private void _SetText()
    {
        if (Data.LOCALIZATION.ContainsKey(_key))
        {
            _text.text = Data.LOCALIZATION[_key][Data.CURRENT_LANGUAGE];
        }
    }

    private void OnDestroy()
    {
        Data.OnLanguageChanged.RemoveListener(_SetText);
    }
}

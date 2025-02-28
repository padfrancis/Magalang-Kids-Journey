using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

public static class Data
{
    private static string[] _LANGUAGES;
    public static string[] LANGUAGES
    {
        get
        {
            if (_LANGUAGES == null) _LoadLocalizationData();
            return _LANGUAGES;
        }
    }

    private static Dictionary<string, Dictionary<string, string>> _LOCALIZATION;
    public static Dictionary<string, Dictionary<string, string>> LOCALIZATION
    {
        get
        {
            if (_LOCALIZATION == null) _LoadLocalizationData();
            return _LOCALIZATION;
        }
    }
    public static string CURRENT_LANGUAGE = "en";

    private static UnityEvent _OnLanguageChanged;
    public static UnityEvent OnLanguageChanged
    {
        get
        {
            if (_OnLanguageChanged == null)
                _OnLanguageChanged = new UnityEvent();
            return _OnLanguageChanged;
        }
    }

    private static string _ReadFromFile(string path)
    {
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                return reader.ReadToEnd();
            }
        }
        else
        {
            Debug.LogWarning($"File not found: {path}");
        }
        return "{}";
    }
    public static void _LoadLocalizationData()
    {
        _LOCALIZATION = new Dictionary<string, Dictionary<string, string>>();
        string json = _ReadFromFile(Path.Combine(
            Application.dataPath, "Resources", "localization.json"));

        LocalizationLoader d = JsonUtility.FromJson<LocalizationLoader>(json);
        _LANGUAGES = d.languages;

        foreach (LocalizationMapping map in d.table)
        {
            _LOCALIZATION[map.key] = new Dictionary<string, string>();
            foreach (LocalizationValue val in map.values)
            {
                _LOCALIZATION[map.key].Add(val.lang, val.value);
            }
        }
    }
    public static string GetLocalizedText(string key)
    {
        if (LOCALIZATION.ContainsKey(key) && LOCALIZATION[key].ContainsKey(CURRENT_LANGUAGE))
        {
            return LOCALIZATION[key][CURRENT_LANGUAGE];
        }

        Debug.LogWarning($"Missing translation for key: {key} in language: {CURRENT_LANGUAGE}");
        return key;
    }

}

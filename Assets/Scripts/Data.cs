using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.Networking;

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
        Debug.Log("Loading JSON from: " + Application.streamingAssetsPath);
#if UNITY_ANDROID && !UNITY_EDITOR
        if (path.Contains("://") || path.Contains(":///"))
        {
            UnityWebRequest request = UnityWebRequest.Get(path);
            request.SendWebRequest();
            while (!request.isDone) { }

            if (request.result == UnityWebRequest.Result.Success)
            {
                return request.downloadHandler.text;
            }
            else
            {
                Debug.LogWarning($"Failed to load file: {path}, Error: {request.error}");
                return "{}";
            }
        }
#endif

        if (File.Exists(path))
        {
            return File.ReadAllText(path);
        }
        else
        {
            Debug.LogWarning($"File not found: {path}");
            return "{}";
        }
    }
    public static void _LoadLocalizationData()
    {
        _LOCALIZATION = new Dictionary<string, Dictionary<string, string>>();
        string path = Path.Combine(Application.streamingAssetsPath, "localization.json");

        string json = _ReadFromFile(path);

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

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class Data
{
    public static string CURRENT_LANGUAGE = "en";

    public static Dictionary<string, Dictionary<string, string>> LOCALIZATION =
        new Dictionary<string, Dictionary<string, string>>()
        {
            { "play_key", new Dictionary<string, string>() { {"en", "PLAY"}, {"tl", "LARO"}, {"ilo", "AGAY-AYAM"} } },
            { "settings_key", new Dictionary<string, string>() { {"en", "SETTINGS"}, {"tl", "MGA SETTING"}, {"ilo", "SETTINGS"} } },
            { "back_key", new Dictionary<string, string>() { {"en", "BACK"}, {"tl", "LIKOD"}, {"ilo", "RUMWAR"} } },
            { "lang_key", new Dictionary<string, string>() { {"en", "LANGUAGE"}, {"tl", "WIKA"}, {"ilo", "LENGGUAHE"} } },
            { "audio_key", new Dictionary<string, string>() { {"en", "SOUND"}, {"tl", "TUNOG"}, {"ilo", "UNI"} } },
            { "cred_key", new Dictionary<string, string>() { {"en", "CREDITS"}, {"tl", "MGA KREDITO"}, {"ilo", "DAGITI KREDITO"} } },
            { "sub_key", new Dictionary<string, string>() { {"en", "SUBTITLES"}, {"tl", "SUBTITLE"}, {"ilo", "SUBTITULO"} } },
            { "sizetxt_key", new Dictionary<string, string>() { {"en", "TEXT"}, {"tl", "TEKSTO"}, {"ilo", "TEKSTO"} } }
        };

    public static string[] LANGUAGES = new string[] { "en", "tl", "ilo" };

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

    public static void SetLanguage(string lang)
    {
        if (lang == CURRENT_LANGUAGE || !LOCALIZATION.ContainsKey("play_key"))
            return;

        CURRENT_LANGUAGE = lang;
        PlayerPrefs.SetString("Language", lang);
        PlayerPrefs.Save();

        OnLanguageChanged.Invoke();
    }

    public static void LoadLanguage()
    {
        CURRENT_LANGUAGE = PlayerPrefs.GetString("Language", "en");
    }
}

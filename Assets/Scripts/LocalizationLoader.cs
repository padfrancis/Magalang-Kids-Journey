using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class LocalizationValue
{
    public string lang;
    public string value;
}
[System.Serializable]
public class LocalizationMapping
{
    public string key;
    public LocalizationValue[] values;
}
[System.Serializable]
public class LocalizationLoader
{
    public string[] languages;
    public LocalizationMapping[] table;
}

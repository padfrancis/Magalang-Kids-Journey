using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Xml.Serialization;
using System.IO;

public class VolumeControl : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider musicSlider;
    public Slider sfxSlider;
    public Slider masterSlider;
    public Slider voiceOverSlider;

    private string filePath;

    private void Start()
    {
        filePath = Application.persistentDataPath + "/VolumeSettings.xml";
        LoadVolume();
    }

    public void UpdateMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
    }

    public void UpdateSoundVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", volume);
    }
    public void UpdateMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);
    }

    public void UpdateVoiceOverVolume(float volume)
    {
        audioMixer.SetFloat("VoiceOverVolume", volume);
    }

    public void SaveVolume()
    {
        VolumeSettings settings = new VolumeSettings();

        audioMixer.GetFloat("MusicVolume", out settings.MusicVolume);
        audioMixer.GetFloat("SFXVolume", out settings.SFXVolume);
        audioMixer.GetFloat("MasterVolume", out settings.MasterVolume);
        audioMixer.GetFloat("VoiceOverVolume", out settings.VoiceOverVolume);

        XmlSerializer serializer = new XmlSerializer(typeof(VolumeSettings));
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            serializer.Serialize(writer, settings);
        }

        Debug.Log("Volume settings saved to: " + filePath);
    }

    public void LoadVolume()
    {
        if (File.Exists(filePath))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(VolumeSettings));
            using (StreamReader reader = new StreamReader(filePath))
            {
                VolumeSettings settings = (VolumeSettings)serializer.Deserialize(reader);

                musicSlider.value = settings.MusicVolume;
                sfxSlider.value = settings.SFXVolume;
                masterSlider.value = settings.MasterVolume;
                voiceOverSlider.value = settings.VoiceOverVolume;

                audioMixer.SetFloat("MusicVolume", settings.MusicVolume);
                audioMixer.SetFloat("SFXVolume", settings.SFXVolume);
                audioMixer.SetFloat("MasterVolume", settings.MasterVolume);
                audioMixer.SetFloat("VoiceOverVolume", settings.VoiceOverVolume);
            }

            Debug.Log("Volume settings loaded from: " + filePath);
        }
        else
        {
            Debug.Log("No volume settings file found, using default values.");
        }
    }
}

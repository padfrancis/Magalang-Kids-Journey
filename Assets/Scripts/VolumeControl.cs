using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class VolumeControl : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider musicSlider;
    public Slider sfxSlider;
    public void Start()
    {
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
    public void SaveVolume()
    {
        audioMixer.GetFloat("MusicVolume", out float musicVolume);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        
        audioMixer.GetFloat("SFXVolume", out float sfxVolume);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
    }
    public void LoadVolume()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            float musicVolume = PlayerPrefs.GetFloat("MusicVolume");
            musicSlider.value = musicVolume;
            audioMixer.SetFloat("MusicVolume", musicVolume);
        }
        if (PlayerPrefs.HasKey("SFXVolume"))
        {
            float sfxVolume = PlayerPrefs.GetFloat("SFXVolume");
            sfxSlider.value = sfxVolume;
            audioMixer.SetFloat("SFXVolume", sfxVolume);
        }
    }
}

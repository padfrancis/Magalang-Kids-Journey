using UnityEngine;

public class MusicControl : MonoBehaviour
{
    [SerializeField]
    private string defaultMusicTrackName;

    public void OnEnable()
    {
        PlayMusic(defaultMusicTrackName);
    }

    public void OnDisable()
    {
        if (MusicManager.instance != null)
        {
            MusicManager.instance.StopMusic();
            MusicManager.instance.SetShouldPlayLobbyMusic(true);
        }
        else
        {
            Debug.LogWarning("MusicManager instance not found!");
        }
    }

    public void PlayMusic(string trackName)
    {
        if (MusicManager.instance != null)
        {
            MusicManager.instance.PlayMusic(trackName);
        }
        else
        {
            Debug.LogWarning("MusicManager instance not found!");
        }
    }
}






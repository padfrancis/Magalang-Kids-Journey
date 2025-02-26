using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    [SerializeField]
    private AudioSource musicSource;

    [SerializeField]
    private MusicLibrary musicLibrary;

    [SerializeField]
    private string lobbyMusicTrackName = "Lobby Music";

    private bool shouldPlayLobbyMusic = false;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        if (musicSource != null)
        {
            musicSource.playOnAwake = false;
        }
    }

    public void PlayMusic(string trackName)
    {
        AudioClip clip = musicLibrary.GetClipFromName(trackName);
        if (clip != null)
        {
            musicSource.clip = clip;
            musicSource.Play();
            Debug.Log($"Playing music: {trackName}");
        }
        else
        {
            Debug.LogWarning($"Music track '{trackName}' not found!");
        }
    }

    public void PauseMusic()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Pause();
            Debug.Log("Music paused.");
        }
    }

    public void ResumeMusic()
    {
        if (!musicSource.isPlaying && musicSource.clip != null)
        {
            musicSource.UnPause();
            Debug.Log("Music resumed.");
        }
    }

    public void StopMusic()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Stop();
            Debug.Log("Music stopped.");
        }
    }

    public void PlayLobbyMusic()
    {
        Debug.Log("Stopping current music and playing lobby music.");
        StopMusic();
        PlayMusic(lobbyMusicTrackName);
    }

    public void SetShouldPlayLobbyMusic(bool value)
    {
        shouldPlayLobbyMusic = value;
    }

    private void Update()
    {
        if (shouldPlayLobbyMusic)
        {
            PlayLobbyMusic();
            shouldPlayLobbyMusic = false;
        }
    }
}





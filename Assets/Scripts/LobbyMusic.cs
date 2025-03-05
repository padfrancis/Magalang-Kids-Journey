using UnityEngine;

public class LobbyMusic : MonoBehaviour
{
    [SerializeField] private string musicName;

    private void Start()
    {
        if (MusicManager.instance != null)
        {
            if (!MusicManager.instance.IsMusicPlaying(musicName))
            {
                MusicManager.instance.PlayMusic(musicName);
            }
        }
        else
        {
            Debug.LogWarning("MusicManager instance is not set.");
        }
    }

    public void Play()
    {
        if (MusicManager.instance != null)
        {
            if (!MusicManager.instance.IsMusicPlaying(musicName))
            {
                MusicManager.instance.PlayMusic(musicName);
            }
        }
        else
        {
            Debug.LogWarning("MusicManager instance is not set.");
        }
    }
}

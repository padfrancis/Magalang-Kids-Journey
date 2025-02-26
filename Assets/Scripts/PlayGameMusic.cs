using UnityEngine;

public class PlayGameMusic : MonoBehaviour
{
    [SerializeField] private string trackName;

    private void Start()
    {
        if (MusicManager.instance != null)
        {
            MusicManager.instance.PlayMusic(trackName);
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
            MusicManager.instance.PlayMusic(trackName);
        }
        else
        {
            Debug.LogWarning("MusicManager instance is not set.");
        }
    }
}


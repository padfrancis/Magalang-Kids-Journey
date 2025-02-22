using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    [SerializeField]
    private MusicLibrary musicLibrary;
    [SerializeField]
    private AudioSource musicSource;
    [SerializeField]
    private string[] gameplayScenes; // List of scenes where music should not play

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to the sceneLoaded event
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Unsubscribe from the sceneLoaded event
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (IsGameplayScene(scene.name))
        {
            musicSource.Stop();
        }
        else if (!musicSource.isPlaying)
        {
            musicSource.Play();
        }
    }

    private bool IsGameplayScene(string sceneName)
    {
        foreach (string gameplayScene in gameplayScenes)
        {
            if (sceneName == gameplayScene)
            {
                return true;
            }
        }
        return false;
    }

    public void PlayMusic(string trackName, float fadeDuration = 0f)
    {
        StartCoroutine(AnimateMusicCrossfade(musicLibrary.GetClipFromName(trackName), fadeDuration));
    }

    IEnumerator AnimateMusicCrossfade(AudioClip nextTrack, float fadeDuration = 0f)
    {
        float percent = 0;
        while (percent < 1)
        {
            percent += Time.deltaTime * 1 / fadeDuration;
            musicSource.volume = Mathf.Lerp(1f, 0, percent);
            yield return null;
        }

        musicSource.clip = nextTrack;
        musicSource.Play();

        percent = 0;
        while (percent < 1)
        {
            percent += Time.deltaTime * 1 / fadeDuration;
            musicSource.volume = Mathf.Lerp(0, 1f, percent);
            yield return null;
        }
    }
}

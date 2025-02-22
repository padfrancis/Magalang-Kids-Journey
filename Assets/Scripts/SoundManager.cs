using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField]
    private SoundLibrary sfxLibrary;
    [SerializeField]
    private AudioSource sfx2DSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        // Ensure the AudioSource is assigned
        if (sfx2DSource == null)
        {
            sfx2DSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void PlaySound(AudioClip clip, Vector3 position)
    {
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, position);
        }
    }

    public void PlaySound(string soundName, Vector3 position)
    {
        PlaySound(sfxLibrary.GetClipFromName(soundName), position);
    }

    public void PlaySound2D(string soundName)
    {
        AudioClip clip = sfxLibrary.GetClipFromName(soundName);
        if (clip != null)
        {
            if (sfx2DSource == null)
            {
                sfx2DSource = gameObject.AddComponent<AudioSource>();
            }
            sfx2DSource.PlayOneShot(clip);
        }
        else
        {
            Debug.LogWarning("AudioClip or AudioSource is null.");
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    [SerializeField] private string soundName;

    public void PlaySound()
    {
        if (SoundManager.instance != null)
        {
            SoundManager.instance.PlaySound2D(soundName);
        }
        else
        {
            Debug.LogWarning("SoundManager instance is not set.");
        }
    }
}

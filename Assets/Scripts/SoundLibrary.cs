using UnityEngine;

[System.Serializable]
public struct SoundEffect
{
    public string groupID;
    public AudioClip[] clips;
}
public class SoundLibrary : MonoBehaviour
{
    public SoundEffect[] SoundEffect;
    public AudioClip GetClipFromName(string name)
    {
        foreach (SoundEffect soundEffect in SoundEffect)
        {
            if (soundEffect.groupID == name)
            {
                return soundEffect.clips[Random.Range(0, soundEffect.clips.Length)];
            }
        }
        Debug.LogWarning("SoundEffect " + name + " not found!");
        return null;
    }
}

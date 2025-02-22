using UnityEngine;

[System.Serializable]
public struct MusicTrack
{
    public string name;
    public AudioClip clip;
}
public class MusicLibrary : MonoBehaviour
{
    public MusicTrack[] tracks;
    public AudioClip GetClipFromName(string name)
    {
        foreach (MusicTrack track in tracks)
        {
            if (track.name == name)
            {
                return track.clip;
            }
        }
        Debug.LogWarning("Music track with name " + name + " not found!");
        return null;
    }
}

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
            if (track.name.Equals(name, System.StringComparison.OrdinalIgnoreCase))
            {
                return track.clip;
            }
        }
        return null;
    }
}

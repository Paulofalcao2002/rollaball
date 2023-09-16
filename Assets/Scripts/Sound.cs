using UnityEngine.Audio;
using UnityEngine;

// This class was based on the tutorial "Introduction to AUDIO in Unity"
// by Brackeys (https://www.youtube.com/watch?v=6OT43pvUyfY)
[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;

    [Range(0.1f, 3f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}

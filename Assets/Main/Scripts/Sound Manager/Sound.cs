using UnityEngine;

[CreateAssetMenu(fileName = "Sound", menuName = "Sound", order = 1)]
public class Sound : ScriptableObject
{
    public AudioClip audio;

    [Range(0f, 1f)] public float volume = 1f;
    public bool loop = false;
    public float delay = 0f;
}

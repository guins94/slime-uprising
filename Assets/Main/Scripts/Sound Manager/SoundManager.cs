using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sound Manager plyas all sounds using Coroutines.
/// </summary>
public class SoundManager : MonoBehaviour
{
    [Header("Sound References")]
    [SerializeField] List<Sound> soundList = null;

    [Header("Audio Source References")]
    [SerializeField] List<AudioSource> audioSourceReferences = new List<AudioSource>();

    // Timers For The Sounds
    readonly Dictionary<Sound, float> soundTimerDictionary = new Dictionary<Sound, float>();

    // Keeps the audio sorce that played the sound
    readonly Dictionary<Sound, int> soundAudioSourceDictionary = new Dictionary<Sound, int>();

    private int nextAudioSorceId = 0;


    // A vector to store the coroutines of sounds still playing
    List<Coroutine> soundCoroutinesList = new List<Coroutine>();
    Coroutine newSoundCoroutine = null;

    /// <summary>
    /// Play Sound Depending On the Index Guiven
    /// </summary>
    public void Play(int index)
    {
        if (index > soundList.Count - 1) return;
        Play(soundList[index]);
    }

    /// <summary>
    /// Generic Function that plays a sound if it's not playing already.
    /// </summary>
    public void Play(Sound sound)
    {
        if (audioSourceReferences[nextAudioSorceId] == null) return; 
        if (CanPlay(sound))
        {
            newSoundCoroutine = StartCoroutine(PlayCoroutine(sound));
        } 
    }

    /// <summary>
    /// Plays a random sound from a list of sounds.
    /// </summary>
    public void PlayRandomSound(Sound[] sounds)
    {
        if (sounds == null) return;
        Sound s = null;
        int index = UnityEngine.Random.Range(0, sounds.Length - 1);
        s = sounds[index];
        if (s == null)
        {
            Debug.LogWarning("Sound: Not in the list!");
            return;
        }
        Play(s);
    }

    /// <summary>
    /// Plays the sound and add the coroutine to the list. When the sound is done playing it will remove the coroutine from the list.
    /// </summary>
    IEnumerator PlayCoroutine(Sound sound)
    {
        Coroutine coroutine = newSoundCoroutine;
        audioSourceReferences[nextAudioSorceId].loop = sound.loop;
        audioSourceReferences[nextAudioSorceId].PlayOneShot(sound.audio, sound.volume);
        soundCoroutinesList.Add(coroutine);
        soundAudioSourceDictionary.TryAdd(sound, nextAudioSorceId);
        nextAudioSorceId++;
        if (nextAudioSorceId >= audioSourceReferences.Count) nextAudioSorceId = 0;
        yield return new WaitForSeconds(sound.audio.length);
        for (int i = 0; i < soundCoroutinesList.Count ; i++)
        {
            if (soundCoroutinesList[i] == coroutine)
            {
                soundCoroutinesList[i] = null;
                soundCoroutinesList.RemoveAt(i);
            }
        }
        soundAudioSourceDictionary.Remove(sound);
    }

    /// <summary>
    /// Checks in the dictionary if the sound is already playing.
    /// </summary>
    public bool CanPlay(Sound sound)
    {
        // If the sound delay is 0, it can be played
        if (!soundTimerDictionary.ContainsKey(sound)) 
        {
            if (sound.delay <= 0f) return true;
            else soundTimerDictionary.Add(sound, 0f);
        }
        float lastTimePlayed = soundTimerDictionary[sound];

        if (lastTimePlayed + sound.delay < Time.time)
        {
            soundTimerDictionary[sound] = Time.time;
            return true;
        }
        else return false;
    }

    /// <summary>
    /// Stops a spcecified sound.
    /// </summary>
    public void StopSound(Sound sound)
    {
        if (soundAudioSourceDictionary.ContainsKey(sound)) audioSourceReferences[soundAudioSourceDictionary[sound]].Stop();
        // TODO: Stop the specific sound from the coroutine.
    }
}

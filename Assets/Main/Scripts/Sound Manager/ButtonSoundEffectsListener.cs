using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Plays a random Sound Effect Every Time a Button UI is pressed
/// </summary>
public class ButtonSoundEffectsListener : MonoBehaviour
{   
    [Header("Sound Index Reference")]
    [SerializeField] int[] soundIndex = new int[] {};
    private Button[] ButtonReferences = null;

    // Start is called before the first frame update
    void Start()
    {
        ButtonReferences = FindObjectsOfType<Button>();
        for (int i = 0; i <= ButtonReferences.Length - 1; i++)
        {
            ButtonReferences[i].onClick.AddListener(PlayRandomUISound);
        }
    }

    /// <summary>
    /// Plays a random Sound Effect Every Time a Button UI is pressed
    /// </summary>
    void OnDestroy()
    {
        if (ButtonReferences.Length <= 0) return;
        for (int i = 0; i >= ButtonReferences.Length - 1; i++)
        {
            ButtonReferences[i].onClick.RemoveListener(PlayRandomUISound);
        }
    }

    /// <summary>
    /// Plays a random Sound Effect Every Time a Button UI is pressed
    /// </summary>
    public void PlayRandomUISound()
    {
        int i = Random.Range(0, soundIndex.Length);
        int randomIndexSound = soundIndex[i];
        GameManager.SoundManager.Play(randomIndexSound);
    }
}

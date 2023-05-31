using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundConfigurationUI : MonoBehaviour
{
    [Header("Mixer References")]
    [SerializeField] AudioMixer masterMixer;

    [Header("Slider References")]
    [SerializeField] Slider masterVolumeSlider;

    [Header("Button References")]
    [SerializeField] Button backButtonReferences;

    // Start is called before the first frame update
    void Start()
    {
        backButtonReferences.onClick.AddListener(DisableConfigGameObject);
    }

    void OnDelete()
    {
        backButtonReferences.onClick.RemoveListener(DisableConfigGameObject);
    }

    /// <summary>
    /// Changes the MasterVolume AudioMixer volume.
    /// </summary>
    public void SetMasterVolume()
    {
        masterMixer.SetFloat("MasterVolume", masterVolumeSlider.value);
    }

    private void DisableConfigGameObject()
    {
        this.gameObject.SetActive(false);
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Pauses/unpauses the game.
/// </summary>
public class Pauser : MonoBehaviour
{
    [Header("Canvas References")]
    [SerializeField] Canvas pausedCanvas = null;
    [SerializeField] Canvas configCanvas = null;
    
    [Header("Button References")]
    [SerializeField] Button pauseButton = null;
    [SerializeField] Button playButton = null;
    [SerializeField] Button configButton = null;
    [SerializeField] Button quitButton = null;

    /// <summary>
    /// Is the game currently paused?
    /// </summary>
    /// <returns></returns>
    public static bool gamePaused => Time.timeScale == 0f;
    float TimeScale
    {
        set
        {
            Time.timeScale = value;
            UpdateUI();
        }
    }

    // Event Listener Additions
    void Awake()
    {
        pauseButton.onClick.AddListener(PauseGame);
        playButton.onClick.AddListener(ResumeGame);
        quitButton.onClick.AddListener(QuitGame);
        configButton.onClick.AddListener(HandleConfigButtonClick);
    }
    void OnDestroy()
    {
        quitButton.onClick.RemoveListener(QuitGame);
        pauseButton.onClick.RemoveListener(ResumeGame);
        playButton.onClick.RemoveListener(PauseGame);
        configButton.onClick.RemoveListener(HandleConfigButtonClick);
    }

    /// <summary>
    /// Pauses the game.
    /// </summary>
    void PauseGame()
    {
        TimeScale = 0f;
    } 
    
    /// <summary>
    /// Resumes the game.
    /// </summary>
    void ResumeGame() => TimeScale = 1f;
    
    /// <summary>
    /// Updates the UI to reflect the current state of the game.
    /// </summary>
    void UpdateUI() => pausedCanvas.enabled = gamePaused;

    /// <summary>
    /// Resumes the game after a delay.
    /// </summary>
    /// <returns></returns>
    void QuitGame() => SceneManager.LoadSceneAsync(1);

    /// <summary>
    /// Handles the config button click.
    /// </summary>
    void HandleConfigButtonClick()
    {
        if(configCanvas) configCanvas.enabled = true;
    }
}

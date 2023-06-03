using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenuIntroUI : MonoBehaviour
{
    [Header("Main Canvas References")]
    [SerializeField] Canvas StartUpMenuCanvas;

    [Header("Config GameObject References")]
    [SerializeField] GameObject ConfigCanvas;

    [Header("Grid References")]
    [SerializeField] GameObject GameGrid;
    [SerializeField] GameObject HolderCanvasGameObject;

    [Header("Button References")]
    [SerializeField] Button PlayGameButton;
    [SerializeField] Button ConfigGameButton;
    [SerializeField] Button QuitGameButton;

    void Start()
    {
        // Activate Grid and Holder Using Timeline Activate 
        GameGrid.SetActive(true);
        HolderCanvasGameObject.SetActive(true);

        // Starts Listenning to Button Clicks
        PlayGameButton.onClick.AddListener(SceneLoading);
        ConfigGameButton.onClick.AddListener(ActivateConfigGameCanvas);
        QuitGameButton.onClick.AddListener(QuitGame);
    }

    private void SceneLoading()
    {
        SceneManager.LoadSceneAsync(2);
    }

    private void ActivateConfigGameCanvas()
    {
        ConfigCanvas.SetActive(true);
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}

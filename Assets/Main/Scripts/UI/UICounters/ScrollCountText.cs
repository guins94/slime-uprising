using System;
using UnityEngine;
using UnityEngine.UI;

public class ScrollCountText : MonoBehaviour
{
    private int scrollCount = 0;

    [SerializeField] private Text scrollText = null;

    // Start is called before the first frame update
    void Start()
    {
        GameEventsManager.ScrollCollected += ScrollCollected;
        GameEventsManager.ScrollWasted += ScrollWasted;
        GameManager.GameManagerInstance.FileLoaded += FileLoaded;
    }

    void OnDelete()
    {
        GameEventsManager.ScrollCollected -= ScrollCollected;
        GameEventsManager.ScrollWasted -= ScrollWasted;
        GameManager.GameManagerInstance.FileLoaded -= FileLoaded;
    }

    private void ScrollCollected()
    {
        scrollCount++;
        GameManager.GameManagerInstance.scroll = scrollCount;
        Debug.Log(GameManager.GameManagerInstance.scroll);
        UpdateTextHolder();
    }

    private void ScrollWasted(int scrollToWaste)
    {
        scrollCount = scrollCount - scrollToWaste;
        GameManager.GameManagerInstance.scroll = scrollCount;
        UpdateTextHolder();
    }

    private void UpdateTextHolder()
    {
        scrollText.text = "" + scrollCount;
    }

    private void FileLoaded()
    {
        scrollCount = GameManager.GameManagerInstance.scroll;
        UpdateTextHolder();
    }
}

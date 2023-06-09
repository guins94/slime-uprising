using System;
using System.Collections;
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
        if (GameManager.GameManagerInstance == null) GameManager.GameManagerInstance.FileLoaded += FileLoaded;
        else StartCoroutine(LateFileLoaded());

        IEnumerator LateFileLoaded()
        {
            yield return new WaitForSeconds(1.2f);
            FileLoaded();
        }
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

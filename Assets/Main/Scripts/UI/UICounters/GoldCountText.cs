using System;
using UnityEngine;
using UnityEngine.UI;

public class GoldCountText : MonoBehaviour
{
    private int goldCount = 0;

    [SerializeField] private Text goldText = null;

    // Start is called before the first frame update
    void Awake()
    {
        GameEventsManager.GoldCoinCollected += GoldCoinCollected;
        GameEventsManager.GoldCoinWasted += GoldCoinWasted;
        if (GameManager.GameManagerInstance != null) GameManager.GameManagerInstance.FileLoaded += FileLoaded;
    }

    void Start()
    {
        GameManager.GameManagerInstance.FileLoaded += FileLoaded;
    }

    void OnDelete()
    {
        GameEventsManager.GoldCoinCollected -= GoldCoinCollected;
        GameEventsManager.GoldCoinWasted -= GoldCoinWasted;
        GameManager.GameManagerInstance.FileLoaded -= FileLoaded;
    }

    private void GoldCoinCollected()
    {
        goldCount++;
        GameManager.GameManagerInstance.gold = goldCount;
        UpdateTextHolder();
    }

    private void GoldCoinWasted(int goldToWaste)
    {
        goldCount = goldCount - goldToWaste;
        GameManager.GameManagerInstance.gold = goldCount;
        UpdateTextHolder();
    }

    private void UpdateTextHolder()
    {
        goldText.text = "" + goldCount;
    }

    private void FileLoaded()
    {
        goldCount = GameManager.GameManagerInstance.gold;
        UpdateTextHolder();
    }

    /*
    // ISaveManager needed functions
    public void LoadData(GameData data)
    {
        this.goldCount = data.gold;
    }

    public void SaveData(ref GameData data)
    {
        data.gold = this.goldCount;
    }
    */
}

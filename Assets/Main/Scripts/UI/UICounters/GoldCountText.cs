using System;
using UnityEngine;
using UnityEngine.UI;

public class GoldCountText : MonoBehaviour
{
    private int goldCount = 0;

    [SerializeField] private Text goldText = null;

    // Start is called before the first frame update
    void Start()
    {
        GameEventsManager.GoldCoinCollected += GoldCoinCollected;
        GameEventsManager.GoldCoinWasted += GoldCoinWasted;
        goldCount = GameManager.GameManagerInstance.gold;
        UpdateTextHolder();
    }

    void OnDelete()
    {
        GameEventsManager.GoldCoinCollected -= GoldCoinCollected;
        GameEventsManager.GoldCoinWasted -= GoldCoinWasted;
    }

    private void GoldCoinCollected()
    {
        goldCount++;
        GameManager.GameManagerInstance.gold = goldCount;
        UpdateTextHolder();
    }

    private void GoldCoinWasted(int goldToWaste)
    {
        Debug.Log("coin Waste " + goldToWaste);
        goldCount = goldCount - goldToWaste;
        GameManager.GameManagerInstance.gold = goldCount;
        UpdateTextHolder();
    }

    private void UpdateTextHolder()
    {
        goldText.text = "" + goldCount;
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

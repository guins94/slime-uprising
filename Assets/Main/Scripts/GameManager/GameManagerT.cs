using System;
using UnityEngine;

public abstract class GameManagerT : MonoBehaviour, ISaveData
{
    public static GameManagerT GameManagerInstance { get; protected set; } = null;

    public static PlayerSlime Player { get; protected set; } = null;

    public static DamageUIMessager DamageUIMessager { get; protected set; } = null;

    public static ItemCanvaController ItemCanvaController { get; protected set; } = null;

    public static EnemySpawn EnemySpawn { get; protected set; } = null;

    // Public Actions
    public Action FileLoaded;

    //Save Dependent References
    public int gold = 0;
    public int scroll = 0;

    public int[] MainShopIndexVector = new int[] {0, 0, 0, 0};
    public bool[] ScrollShopIndexVector = new bool[] {false, false, false, false};

    // ISaveManager needed functions
    public void LoadData(GameData data)
    {
        this.gold = data.gold;
        this.scroll = data.scroll;
        this.MainShopIndexVector = data.mainShopIndexVector;
        this.ScrollShopIndexVector = data.ScrollShopIndexVector;
        FileLoaded?.Invoke();
    }

    public void SaveData(ref GameData data)
    {
        data.gold = this.gold;
        data.scroll = this.scroll;
        data.mainShopIndexVector = this.MainShopIndexVector;
        data.ScrollShopIndexVector = this.ScrollShopIndexVector;
    }
}

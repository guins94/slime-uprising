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

    // ISaveManager needed functions
    public void LoadData(GameData data)
    {
        this.gold = data.gold;
        this.MainShopIndexVector = data.mainShopIndexVector;
        FileLoaded?.Invoke();
    }

    public void SaveData(ref GameData data)
    {
        data.gold = this.gold;
        data.mainShopIndexVector = this.MainShopIndexVector;
    }
}

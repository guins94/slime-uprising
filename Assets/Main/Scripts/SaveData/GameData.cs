using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int gold;
    public int scroll;

    public int[] mainShopIndexVector = null;
    public bool[] ScrollShopIndexVector = null;

    // Public Method to Set in Game amounts.
    public GameData()
    {
        this.gold = 0;
        this.scroll = 0;
        this.mainShopIndexVector = new int[] {0, 0, 0, 0};
        this.ScrollShopIndexVector = new bool[] {false, false, false, false};
    }
}

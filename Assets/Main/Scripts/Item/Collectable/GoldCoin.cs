using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoin : Item
{
    public override IEnumerator ItemEffect()
    {
        GameEventsManager.GoldCoinCollected?.Invoke();
        yield return null;
    }
}

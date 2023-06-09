using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoin : Item
{
    public override IEnumerator ItemEffect()
    {
        GameManager.SoundManager.Play(10);
        GameEventsManager.GoldCoinCollected?.Invoke();
        yield return null;
    }
}

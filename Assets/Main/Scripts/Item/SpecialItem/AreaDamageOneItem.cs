using System.Collections;
using UnityEngine;

public class AreaDamageOneItem : Item
{
    public override IEnumerator ItemEffect()
    {
        DamageOneEnemyArea playerDamageArea = FindObjectOfType<DamageOneEnemyArea>();
        if (playerDamageArea != null) playerDamageArea.ActivateDamageArea(); 
        yield return null;
    }
}

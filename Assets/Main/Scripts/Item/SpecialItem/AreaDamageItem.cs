using System.Collections;
using UnityEngine;

public class AreaDamageItem : Item
{
    public override IEnumerator ItemEffect()
    {
        DamageAllEnemyArea playerDamageArea = FindObjectOfType<DamageAllEnemyArea>();
        if (playerDamageArea != null) playerDamageArea.ActivateDamageArea(); 
        yield return null;
    }
}

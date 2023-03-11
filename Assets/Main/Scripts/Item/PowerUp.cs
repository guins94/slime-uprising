using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : Item
{
    [SerializeField] int armorGained = 1;

    [SerializeField] DamageType armorDamageType = DamageType.Physic;

    public override IEnumerator ItemEffect()
    {
        if (gameManager.GameManagerInstance.Player != null)
        {
            gameManager.GameManagerInstance.Player.CreatureArmor.RaiseArmor(armorDamageType, armorGained);
        }
        yield return null;
    }
}

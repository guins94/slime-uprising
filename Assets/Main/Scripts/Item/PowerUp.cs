using System.Collections;
using UnityEngine;

public class PowerUp : Item
{
    [SerializeField] int armorGained = 1;

    [SerializeField] DamageType armorDamageType = DamageType.Physic;

    public override IEnumerator ItemEffect()
    {
        if (GameManager.Player != null)
        {
            GameManager.Player.CreatureArmor.RaiseArmor(armorDamageType, armorGained);
        }
        yield return null;
    }
}

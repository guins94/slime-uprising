using UnityEngine;

public class ArmorSystem : MonoBehaviour
{
    [SerializeField] float physicArmor = 1;

    [SerializeField] float magicArmor = 1;

    //Public References
    public float PhysicArmor => physicArmor;
    public float MagicArmor => magicArmor;

    public float CalculatedDamage(DamageType damageType, float damage)
    {
        if (damageType == DamageType.TrueDamage) return damage;
        if (damageType == DamageType.Physic) 
        {
            Debug.Log("Damage p " + PhysicDamageTaken(damage));
            return PhysicDamageTaken(damage);
        } 
        if (damageType == DamageType.Magic) return MagicDamageTaken(damage);
        return 0;
    }

    private float PhysicDamageTaken(float damage)
    {
        return damage/(1 + (physicArmor/100));
    }

    private float MagicDamageTaken(float damage)
    {
        return damage/(1 + (magicArmor/100));
    }

    public void RaiseArmor(DamageType armorDamageType, int armorGained)
    {
        if (armorDamageType == DamageType.Physic) physicArmor = physicArmor + armorGained;
        if (armorDamageType == DamageType.Magic) magicArmor = magicArmor + armorGained;
    }
}

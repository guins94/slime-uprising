using UnityEngine;
using System.Collections.Generic;

public class ShooterSystem : MonoBehaviour
{
    [SerializeField] List<ShooterType> ShooterList = new List<ShooterType>();
    [SerializeField] ShooterBolt shooterBolt = null;
    [SerializeField] ShooterBook shooterBook = null;


    public void ShooterLevelUp(ShooterType shooterDamage, BulletType bulletType)
    {
        if (ShooterList.Count - 1 >= 4) return;
        if (shooterDamage == ShooterType.Bolt) shooterBolt.LevelUp(shooterDamage, bulletType);
        if (shooterDamage == ShooterType.Book) shooterBook.LevelUp(shooterDamage, bulletType);
    }
}

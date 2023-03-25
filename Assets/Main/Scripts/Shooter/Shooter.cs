using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shooter : MonoBehaviour
{
    [SerializeField] int shooterLevel = 0;
    [SerializeField] int maxShooterLevel = 4;
    public BulletType initialType = BulletType.CompleteCircleBook;

    public int ShooterLevel => shooterLevel;
    public int MaxShooterLevel => maxShooterLevel;

    public bool checkMaxLevel => MaxShooterLevel > ShooterLevel;

    //Cached Components
    public float fireRate = 4f;

    public void LevelUp()
    {
        if (checkMaxLevel) shooterLevel = shooterLevel + 1;
    }

    public abstract void LevelUp(ShooterType shooterType, BulletType bulletType);
}

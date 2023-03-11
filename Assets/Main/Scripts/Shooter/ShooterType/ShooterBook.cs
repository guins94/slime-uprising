using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterBook : Shooter
{
    [SerializeField] List<Bullet> BulletList = new List<Bullet>();
    [SerializeField] Bullet CompleteCircleBook = null;
    [SerializeField] Bullet CrossBook = null;
    [SerializeField] Bullet XBook = null;
    [SerializeField] Bullet FowardBook = null;
    public override void LevelUp(ShooterType shooterType, BulletType bulletType)
    {
        if (checkMaxLevel)
        {
            LevelUp();
            ReleaseBullet(bulletType);
        }
        
    }

    private void ReleaseBullet(BulletType bulletType)
    {
        Bullet newBullet = null;
        if (bulletType == BulletType.CompleteCircleBook) newBullet = CompleteCircleBook;
        if (bulletType == BulletType.CrossBook) newBullet = CrossBook;
        if (bulletType == BulletType.XBook) newBullet = XBook;
        if (bulletType == BulletType.FowardBook) newBullet = FowardBook;
        if (newBullet != null)
        {
            newBullet = Instantiate(newBullet, Vector3.zero, Quaternion.identity);
            newBullet.offsetFrequencie = newBullet.offsetFrequencie + (ShooterLevel * .75f);
            BulletList.Add(newBullet);
        } 
    }
}

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

    // Cached Components
    private Coroutine ReleaseTimedBullet = null;
    public bool canReleaseBullet = false;
    public override void LevelUp(ShooterType shooterType, BulletType bulletType)
    {
        if (checkMaxLevel)
        {
            if (ShooterLevel == 0) initialType = bulletType;
            ReleaseBullet(bulletType);
            LevelUp();
        }
        if (ReleaseTimedBullet == null) ReleaseTimedBullet = StartCoroutine(ReleaseTimed());
    }

    private void ReleaseBullet(BulletType bulletType)
    {
        Bullet Bullet = null;
        if (bulletType == BulletType.CompleteCircleBook) Bullet = CompleteCircleBook;
        if (bulletType == BulletType.CrossBook) Bullet = CrossBook;
        if (bulletType == BulletType.XBook) Bullet = XBook;
        if (bulletType == BulletType.FowardBook) Bullet = FowardBook;
        if (Bullet != null)
        {
            Bullet = Instantiate(Bullet, Vector3.zero, Quaternion.identity);
            if (initialType == BulletType.CompleteCircleBook) Bullet.bulletMovement = Bullet.gameObject.AddComponent<BulletCompleteCircleBook>();
            if (initialType == BulletType.CrossBook) Bullet.bulletMovement = Bullet.gameObject.AddComponent<BulletCrossBook>();
            if (initialType == BulletType.XBook) Bullet.bulletMovement = Bullet.gameObject.AddComponent<BulletXBook>();
            if (initialType == BulletType.FowardBook) Bullet.bulletMovement = Bullet.gameObject.AddComponent<BulletFowardBook>();
            Bullet.bulletMovement.ChangeMovement(ShooterLevel);
            Bullet.BulletLevel = ShooterLevel;
            Bullet.gameObject.SetActive(false);
            BulletList.Add(Bullet);
            canReleaseBullet = false;
            StartCoroutine(ActivateAllBullets());
        } 
    }

    public IEnumerator ActivateAllBullets()
    {
        yield return new WaitUntil(() => canReleaseBullet);
        for (int i = 0; i <= BulletList.Count-1; i++)
        {
            BulletList[i].gameObject.SetActive(true);
        }
    }

    public IEnumerator ReleaseTimed()
    {   
        yield return new WaitForSeconds(fireRate);
        canReleaseBullet = true;
        ReleaseTimedBullet = StartCoroutine(ReleaseTimed());
    }
}

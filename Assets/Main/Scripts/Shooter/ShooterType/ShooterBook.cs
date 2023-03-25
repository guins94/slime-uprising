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
        Bullet newBullet = null;
        if (bulletType == BulletType.CompleteCircleBook) newBullet = CompleteCircleBook;
        if (bulletType == BulletType.CrossBook) newBullet = CrossBook;
        if (bulletType == BulletType.XBook) newBullet = XBook;
        if (bulletType == BulletType.FowardBook) newBullet = FowardBook;
        if (newBullet != null)
        {
            newBullet = Instantiate(newBullet, Vector3.zero, Quaternion.identity);
            if (initialType == BulletType.CompleteCircleBook) newBullet.bulletMovement = newBullet.gameObject.AddComponent<BulletCompleteCircleBook>();
            if (initialType == BulletType.CrossBook) newBullet.bulletMovement = newBullet.gameObject.AddComponent<BulletCrossBook>();
            if (initialType == BulletType.XBook) newBullet.bulletMovement = newBullet.gameObject.AddComponent<BulletXBook>();
            if (initialType == BulletType.FowardBook) newBullet.bulletMovement = newBullet.gameObject.AddComponent<BulletFowardBook>();
            newBullet.bulletMovement.ChangeMovement(ShooterLevel);
            newBullet.BulletLevel = ShooterLevel;
            newBullet.gameObject.SetActive(false);
            BulletList.Add(newBullet);
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

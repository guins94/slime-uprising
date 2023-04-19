using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterItem : Item
{
    [SerializeField] ShooterType shooterType =  ShooterType.Bolt;
    [SerializeField] BulletType bulletType = BulletType.CompleteCircleBook;
    public override IEnumerator ItemEffect()
    {
        GameManager.Player.ShooterSystem.ShooterLevelUp(shooterType, bulletType);
        GameManager.ItemCanvaController.GetItemImage(GetComponent<SpriteRenderer>().sprite);
        yield return null;
    }
    public IEnumerator SetInitialItem()
    {
        GameManager.Player.ShooterSystem.ShooterLevelUp(shooterType, bulletType);
        GameManager.ItemCanvaController.FixedItemImage(GetComponent<SpriteRenderer>().sprite);
        yield return null;
    }
}

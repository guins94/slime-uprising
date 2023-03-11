using UnityEngine;

public class ShooterBolt : Shooter
{
    public override void LevelUp(ShooterType shooterType, BulletType bulletType)
    {
        LevelUp();
        
    }
}

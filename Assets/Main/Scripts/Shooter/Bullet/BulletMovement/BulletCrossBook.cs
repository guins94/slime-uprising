using UnityEngine;

public class BulletCrossBook : BulletMovement
{
    void Update() => AppearAndMove();

    void AppearAndMove()
    {
        
        Vector2 origin = new Vector2 (GameManager.Player.transform.position.x, GameManager.Player.transform.position.y);
        Vector2 target = new Vector2 (origin.x + (RadiusLength * CompassVectorDirection.x), origin.y + (RadiusLength * CompassVectorDirection.y));
        MoveOriginTarget(origin, target, FireRate);
        AppearIdle(.2f);
        transform.position = new Vector2(targetPositionX, targetPositionY);
    }

    public override void ChangeMovement(int level)
    {
        if ( level == 0 )
        {
            compassDirection = CompassDirection.South;
            CompassVectorDirection = Vector2.down;
            return;
        } 
        if ( level == 1 ) 
        {
            compassDirection = CompassDirection.West;
            CompassVectorDirection = Vector2.left;
            return;
        } 
        if ( level == 2 )
        {
            compassDirection = CompassDirection.East;
            CompassVectorDirection = Vector2.right;
            return;
        } 
        if ( level == 3 ) 
        {
            compassDirection = CompassDirection.North;
            CompassVectorDirection = Vector2.up;
            return;
        }
        if ( level == 4 ) 
        {
            compassDirection = CompassDirection.South;
            CompassVectorDirection = new Vector2(1, -1);
            return;
        }
    }
}

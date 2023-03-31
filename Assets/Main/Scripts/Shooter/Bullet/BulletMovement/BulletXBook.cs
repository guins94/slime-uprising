using UnityEngine;

public class BulletXBook : BulletMovement
{
    [SerializeField] CompassDirection roundDirection = CompassDirection.North;
    public float offsetFrequencie = 0;
    void Update()
    {
        Vector2 origin = new Vector2 (GameManager.Player.transform.position.x + (RadiusLength * CompassVectorDirection.x), GameManager.Player.transform.position.y + (RadiusLength * CompassVectorDirection.y));
        Vector2 target = new Vector2 (GameManager.Player.transform.position.x - (RadiusLength * CompassVectorDirection.x), GameManager.Player.transform.position.y - (RadiusLength * CompassVectorDirection.y));
        MoveOriginTarget(origin, target, FireRate);
        AppearIdle(.2f);
        transform.position = new Vector2(targetPositionX, targetPositionY);
    }

    public override void ChangeMovement(int level)
    {
        if ( level == 0 )
        {
            compassDirection = CompassDirection.South;
            CompassVectorDirection = new Vector2(-1, -1);
            return;
        } 
        if ( level == 1 ) 
        {
            compassDirection = CompassDirection.West;
            CompassVectorDirection = new Vector2(-1, 1);
            return;
        } 
        if ( level == 2 )
        {
            compassDirection = CompassDirection.East;
            CompassVectorDirection = new Vector2(1, -1);
            return;
        } 
        if ( level == 3 ) 
        {
            compassDirection = CompassDirection.North;
            CompassVectorDirection = new Vector2(1, 1);
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

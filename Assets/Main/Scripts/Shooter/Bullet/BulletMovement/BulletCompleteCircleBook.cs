using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCompleteCircleBook : BulletMovement
{
    public float offsetFrequencie = 0;
    void Update()
    {
        targetPositionX = GameManager.Player.transform.position.x + (RadiusLength + offsetRadius)*Mathf.Sin((Time.time + offsetFrequencie) * BaseFrequencie);
        targetPositionY = GameManager.Player.transform.position.y + (RadiusLength + offsetRadius)*Mathf.Cos((Time.time + offsetFrequencie) * BaseFrequencie);
        transform.position = new Vector2(targetPositionX, targetPositionY);
    }

    public override void ChangeMovement(int level)
    {
        offsetFrequencie = offsetFrequencie + (level * .65f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBook : Bullet
{
    [SerializeField] CompassDirection compassDirection = CompassDirection.North;

    //
    public float offsetFrequencie => (BulletLevel) * .65f;

    public float offsetRadius = 0f;


}

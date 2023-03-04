using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Creature
{
    public override void Move()
    {
        Debug.Log("slime move");
        //animator.SetFloat("Speed", Mathf.Abs(movementSpeed));
    }
}

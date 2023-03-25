using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D BulletBody = null;
    [SerializeField] BulletType bulletType = BulletType.CompleteCircleBook;
    [SerializeField] DamageType damageType = DamageType.Physic;

    // 
    public BulletMovement bulletMovement = null;

    public int BulletLevel = 0;
    public float BulletDamage = 0;

    public bool slow = false;
    public bool explosion = false;
    public bool burn = false;
    public bool push = false;

    public DamageType DamageType => damageType;

    public BulletType BulletType => bulletType;

    public GameManager gameManager = null;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        //if (damageType = )

        //if (bulletType == BulletType.CompleteCircleBook);
    }
}

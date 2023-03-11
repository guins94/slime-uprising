using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creature : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Animator animator = null;
    [SerializeField] SpriteRenderer spriteRenderer = null;
    [SerializeField] HealthSystem creatureHealth = null;
    [SerializeField] Rigidbody2D creatureBody = null;
    [SerializeField] ArmorSystem creatureArmor = null;

    [Header("Explosion Animation")]
    [SerializeField] GameObject explosion = null;

    // Public References
    public Animator Animator => animator;
    public SpriteRenderer SpriteRenderer => spriteRenderer;
    public Rigidbody2D CreatureBody => creatureBody;
    public HealthSystem CreatureHealth => creatureHealth;
    public ArmorSystem CreatureArmor => creatureArmor;
    public DamageType CreatureDamageType = DamageType.TrueDamage;

    // Cached Variables
    public float CreatureHitDamage = 1;
    public float movementSpeed = 0;
    public float pushForce = 200;

    public GameManager gameManager = null;

    void Start()
    {
        creatureHealth.OnDeath += OnDeath;
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnDestroy()
    {
        creatureHealth.OnDeath -= OnDeath;
    }

    /// <summary>
    /// Slows the creature when hitted
    /// </summary>
    public void SlowEffect()
    {
        movementSpeed = movementSpeed / 2;
    }

    /// <summary>
    /// Causes an explosion on the creature that may husrt other creatures
    /// </summary>
    public void ExplosionEffect(Vector2 explosionPosition)
    {
        GameObject newExplosion = Instantiate(explosion, explosionPosition, Quaternion.identity);
    }

    /// <summary>
    /// A Effect that causes damage that lasts for a while
    /// </summary>
    public void BurnEffect()
    {
        StartCoroutine(BurnEffect());

        IEnumerator BurnEffect()
        {
            for (int i = 0; i >= 3; i++)
            {
                creatureHealth.TakeDamage(3);
                gameManager.DamageUIMessager.ShowDamageUI("3", this.transform.position);
                yield return new WaitForSeconds(1f);
            }
        }
    }

    /// <summary>
    /// Pushes the creature a bit further.
    /// </summary>
    public void PushEffect(Vector3 originDirection, Vector3 oppositeDirection, float push)
    {
        // Moves the enemy
        float distance = Vector2.Distance(originDirection, oppositeDirection);
        Vector2 direction =  oppositeDirection - originDirection;
        CreatureBody.AddForce(direction * push);
    }

    // Update is called once per frame
    void Update() => Move();

    protected abstract void Move();

    protected abstract void OnDeath();
}

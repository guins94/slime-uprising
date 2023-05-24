using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSlime : Creature
{
    [Header("Player Slime References")]
    [SerializeField] HealthBar healthBar = null;
    [SerializeField] ShooterSystem shooterSystem = null;
    [SerializeField] ExperienceSystem experienceSystem = null;

    [Header("Player Initial Item")]
    [SerializeField] ShooterItem initialShooterItem = null;
    [SerializeField] bool hasInitialItem = true;

    // Public References
    public ExperienceSystem ExperienceSystem => experienceSystem;
    public ShooterSystem ShooterSystem => shooterSystem;
    private Vector2 playerMovement = Vector2.zero;

    // Player Collision Cooldown Control
    private Coroutine PlayerHurtCoolDown = null;

    public void Start()
    {
        if (hasInitialItem) StartCoroutine(initialShooterItem.SetInitialItem());
    }

    protected override void OnDeath()
    {

    }

    protected override void Move()
    {
        CreatureBody.AddForce(playerMovement * movementSpeed);
        Animator.SetFloat("Speed", Mathf.Abs(playerMovement.magnitude));
    }

    private void MovePlayer(InputAction.CallbackContext context)
    {
        //Debug.Log("Player move " + context.ReadValue<Vector2>().y);
        playerMovement = new Vector2(context.ReadValue<Vector2>().x * movementSpeed, context.ReadValue<Vector2>().y * movementSpeed);

        if (context.ReadValue<Vector2>().x <=0 ) SpriteRenderer.flipX = true;
        else SpriteRenderer.flipX = false;
        
    }

    private void StopPlayer(InputAction.CallbackContext context)
    {
        playerMovement = new Vector2(0, 0);
    }

    /// <summary>
    /// Enable the input system
    /// </summary>
    void Awake()
    {
        PlayerControls moveAction = new PlayerControls();
        moveAction.Player.Enable();
        moveAction.Player.Walk.performed += MovePlayer;
        moveAction.Player.Walk.canceled += MovePlayer;

        healthBar.PlayeFollow(this);
        healthBar.SetHealth(CreatureHealth.Health, CreatureHealth.MaxHealth);

        experienceSystem.ExperienceBarFollow(this);
    }

    /// <summary>
    /// Stops to listen for input system
    /// </summary>
    void OnDisable()
    {
        //moveAction.Disable();
    }

    /// <summary>
    /// Hitting a Enemy damanges the player
    /// </summary>
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            PushEffect(transform.position, collision.transform.position, -pushForce);
        }
    }

    /// <summary>
    /// Hitting a Enemy damanges the player
    /// </summary>
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // Hurts the Player
            PlayerHurtCoolDown = StartCoroutine(HurtPlayerAfterCooldown());
        }

        IEnumerator HurtPlayerAfterCooldown()
        {
            Animator.SetBool("Damage", true);
            yield return new WaitForSeconds(.1f);
            Creature enemy = collision.gameObject.GetComponent<Creature>();
            int damageTaken = (int) CreatureArmor.CalculatedDamage(enemy.CreatureDamageType, enemy.CreatureHitDamage);
            CreatureHealth.TakeDamage(damageTaken);
            GameManager.DamageUIMessager.ShowDamageUI(damageTaken.ToString(), this.transform.position);
            healthBar.SetHealth(CreatureHealth.Health, CreatureHealth.MaxHealth);
            PlayerHurtCoolDown = null;
            Animator.SetBool("Damage", false);
        }
    }
}

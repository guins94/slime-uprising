using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Creature
{
    [SerializeField] Collider2D enemyCollider = null;
    [SerializeField] Collider2D enemyColliderPusher = null;
    [SerializeField] float enemyCoolDownTimer = 3f;

    public bool TakingAreaDamage = false;
    bool disableMovement = false;
    Coroutine MoveEnemyCoroutine = null;
    Coroutine BulletHitCoroutine = null;
    Coroutine EnemyHurtCoolDown = null;

    protected override void Move()
    {
        Animator.SetFloat("Speed", Mathf.Abs(CreatureBody.velocity.magnitude));

        if (CreatureBody.velocity.x <= 0 ) SpriteRenderer.flipX = true;
        else SpriteRenderer.flipX = false;

        if (GameManager.Player != null && MoveEnemyCoroutine == null && !disableMovement)
        {
            MoveEnemyCoroutine = StartCoroutine(EnemyMovement());
        }
    }

    protected override void OnDeath()
    {
        disableMovement = true;
        Animator.SetBool("Death", true);
        GameManager.EnemySpawn.EnemyDefeated(transform.position);
        enemyCollider.enabled = false;
        enemyColliderPusher.enabled = false;
        StartCoroutine(DestroyEnemy());

        IEnumerator DestroyEnemy()
        {
            yield return new WaitForSeconds(enemyCoolDownTimer);
            Destroy(this.gameObject);
        }
    }

    private IEnumerator EnemyMovement()
    {
        yield return new WaitForSeconds(.2f);
        float distance = Vector2.Distance(transform.position, GameManager.Player.transform.position);
        Vector2 direction = GameManager.Player.transform.position - this.transform.position;
        CreatureBody.AddForce(direction.normalized * movementSpeed);
        MoveEnemyCoroutine = null;
    }

    /// <summary>
    /// Damage Dealt to an Enemy when enterring a damage area
    /// </summary>
    public IEnumerator ActivateAreaHit(float areaDamage, float explosionOffSetY, float coolDownDamageArea, GameObject explosionEffect)
    {
        int damageTaken = (int) CreatureArmor.CalculatedDamage(DamageType.Magic, areaDamage);
        CreatureHealth.TakeDamage(damageTaken);
        GameManager.DamageUIMessager.ShowDamageUI(damageTaken.ToString(), transform.position);
        Vector2 explosionPosition = new Vector2(transform.position.x, transform.position.y - explosionOffSetY);
        Instantiate(explosionEffect, explosionPosition, Quaternion.identity);
        yield return new WaitForSeconds(coolDownDamageArea);
        if (TakingAreaDamage) StartCoroutine(ActivateAreaHit(areaDamage, explosionOffSetY, coolDownDamageArea, explosionEffect));
    }

    /// <summary>
    /// Hitting a Bullet pushes the Enemy
    /// </summary>
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet") && BulletHitCoroutine == null)
        {
            BulletHitCoroutine = StartCoroutine(BulletHit());
            Bullet EnemyBullet = collision.gameObject.GetComponent<Bullet>();
            if (EnemyBullet.slow == true) SlowEffect();
            if (EnemyBullet.explosion == true) ExplosionEffect(collision.transform.position);
            if (EnemyBullet.burn == true) BurnEffect();
            if (EnemyBullet.push == true) PushEffect(GameManager.Player.transform.position, transform.position, pushForce);
        }

        IEnumerator BulletHit()
        {
            PushEffect(GameManager.Player.transform.position, transform.position, pushForce/2);
            yield return new WaitForSeconds(.8f);
            BulletHitCoroutine = null;
        }
    }

    /// <summary>
    /// Hitting a Enemy damanges the player
    /// </summary>
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            // Hurts the Player
            EnemyHurtCoolDown = StartCoroutine(HurtEnemyAfterCooldown());
        }

        if (collision.CompareTag("Explosion"))
        {
            // Hurts the Player
            EnemyHurtCoolDown = StartCoroutine(HurtEnemyAfterCooldown());
        }
        

        IEnumerator HurtEnemyAfterCooldown()
        {
            Animator.SetTrigger("Damage");
            yield return new WaitForSeconds(.1f);
            int damageTaken = (int) CreatureArmor.CalculatedDamage(GameManager.Player.CreatureDamageType, GameManager.Player.CreatureHitDamage);
            CreatureHealth.TakeDamage(damageTaken);
            GameManager.DamageUIMessager.ShowDamageUI(damageTaken.ToString(), this.transform.position);
            EnemyHurtCoolDown = null;
        }
    }

    /// <summary>
    /// Getting off the Damge Area is 
    /// </summary>
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("DamageArea"))
        {
            // Turns On Damage Area on the enemy
            TakingAreaDamage = false;
        }
    }
}



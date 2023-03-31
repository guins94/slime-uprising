using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Creature
{
    Coroutine MoveEnemy = null;
    Coroutine BulletHitCoroutine = null;
    Coroutine EnemyHurtCoolDown = null;
    protected override void Move()
    {
        Animator.SetFloat("Speed", Mathf.Abs(CreatureBody.velocity.magnitude));

        if (CreatureBody.velocity.x <= 0 ) SpriteRenderer.flipX = true;
        else SpriteRenderer.flipX = false;

        if (GameManager.Player != null && MoveEnemy == null)
        {
            MoveEnemy = StartCoroutine(EnemyMovement());
        }
    }

    protected override void OnDeath()
    {

    }

    private IEnumerator EnemyMovement()
    {
        yield return new WaitForSeconds(.2f);
        float distance = Vector2.Distance(transform.position, GameManager.Player.transform.position);
        Vector2 direction = GameManager.Player.transform.position - this.transform.position;
        CreatureBody.AddForce(direction.normalized * movementSpeed);
        MoveEnemy = null;
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
            EnemyHurtCoolDown = StartCoroutine(HurtPlayerAfterCooldown());
        }

        IEnumerator HurtPlayerAfterCooldown()
        {
            Animator.SetBool("Damage", true);
            yield return new WaitForSeconds(.1f);
            int damageTaken = (int) CreatureArmor.CalculatedDamage(GameManager.Player.CreatureDamageType, GameManager.Player.CreatureHitDamage);
            CreatureHealth.TakeDamage(damageTaken);
            GameManager.DamageUIMessager.ShowDamageUI(damageTaken.ToString(), this.transform.position);
            EnemyHurtCoolDown = null;
            Animator.SetBool("Damage", false);
        }
    }
}



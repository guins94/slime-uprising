using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Creature
{
    Coroutine MoveEnemy = null;
    Coroutine BulletHitCoroutine = null;
    protected override void Move()
    {
        Animator.SetFloat("Speed", Mathf.Abs(CreatureBody.velocity.magnitude));

        if (CreatureBody.velocity.x <= 0 ) SpriteRenderer.flipX = true;
        else SpriteRenderer.flipX = false;

        if (gameManager.GameManagerInstance.Player != null && MoveEnemy == null)
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
        float distance = Vector2.Distance(transform.position, gameManager.GameManagerInstance.Player.transform.position);
        Vector2 direction = gameManager.GameManagerInstance.Player.transform.position - this.transform.position;
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
            if (EnemyBullet.push == true) PushEffect(gameManager.GameManagerInstance.Player.transform.position, transform.position, pushForce);
        }

        IEnumerator BulletHit()
        {
            PushEffect(gameManager.GameManagerInstance.Player.transform.position, transform.position, pushForce/2);
            yield return new WaitForSeconds(.8f);
            BulletHitCoroutine = null;
        }
    }
}



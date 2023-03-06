using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Creature
{
    GameManager gameManager = null;

    Coroutine MoveEnemy = null;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    protected override void Move()
    {
        Animator.SetFloat("Speed", Mathf.Abs(CreatureBody.velocity.x));

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
        CreatureBody.AddForce(direction * 10);
        MoveEnemy = null;

    }

}



using System.Collections;
using UnityEngine;

public class ExperienceItem : Item
{
    [SerializeField] Rigidbody2D itemRigidbody = null;

    //Public References
    public Rigidbody2D ItemRigidbody => itemRigidbody;

    // Cached Components
    bool goToPlayer = false;
    Coroutine MoveEnemyCoroutine = null;
    
    public int experienceGained = 1;

    public void Start()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null) goToPlayer = gameManager.experienceGoToPlayer;
    }

    public override IEnumerator ItemEffect()
    {
        if (GameManager.Player != null)
        {
            GameManager.Player.ExperienceSystem.AddExperience(experienceGained);
            GameManager.EnemySpawn.ExperienceItemCollected();
            StartCoroutine(ItemDelete());
        }
        yield return null;
    }

    private void Update()
    {
        if (GameManager.Player != null && MoveEnemyCoroutine == null && goToPlayer)
        {
            MoveEnemyCoroutine = StartCoroutine(EnemyMovement());
        }

        IEnumerator EnemyMovement()
        {
            yield return new WaitForSeconds(.1f);
            float distance = Vector2.Distance(transform.position, GameManager.Player.transform.position);
            Vector2 direction = GameManager.Player.transform.position - this.transform.position;
            itemRigidbody.AddForce(direction.normalized * 20);
            MoveEnemyCoroutine = null;
        }
    }

    public void SetGoToPlayer()
    {
        goToPlayer = true;
    }
}

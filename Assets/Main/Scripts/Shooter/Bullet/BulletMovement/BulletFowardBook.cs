using System.Collections;
using UnityEngine;

public class BulletFowardBook : BulletMovement
{
    [SerializeField] CompassDirection roundDirection = CompassDirection.North;
    private Rigidbody2D bulletRigidbody2D = null;
    public float offsetFrequencie = 0;
    private Coroutine ShootDelayCoroutine = null;
    private float extraDelay = 0.2f;
    private bool OneTimeDelay = false;

    public new void Start()
    {
        base.Start();
        bulletRigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        AppearIdle(.2f);
        if (ShootDelayCoroutine == null) ShootDelayCoroutine = StartCoroutine(ShootDelay());
        if (GameManager.Player.CreatureBody.velocity.normalized == Vector2.zero)
        {
            CompassVectorDirection = new Vector2(Random.Range(50,-50), Random.Range(50,-50)).normalized;
        }
        else
        {
            CompassVectorDirection = Vector2.zero;
        }
    }

    public IEnumerator ShootDelay()
    {
        transform.position = new Vector2 (GameManager.Player.transform.position.x , GameManager.Player.transform.position.y);
        Vector2 target = new Vector2 (GameManager.Player.CreatureBody.velocity.normalized.x + CompassVectorDirection.x, 
        GameManager.Player.CreatureBody.velocity.normalized.y + CompassVectorDirection.y);

        if (bulletRigidbody2D != null)
        {
            bulletRigidbody2D.AddForce(target * 1400f);
        }
        yield return new WaitForSeconds(FireRate);
        if (!OneTimeDelay) 
        {
            yield return new WaitForSeconds(extraDelay);
            OneTimeDelay = true;
        }
        ShootDelayCoroutine = null;
    }

    public override void ChangeMovement(int level)
    {
        extraDelay = extraDelay * level;
    }
}

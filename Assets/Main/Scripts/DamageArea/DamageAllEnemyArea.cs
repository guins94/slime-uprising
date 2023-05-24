using System.Collections;
using UnityEngine;

public class DamageAllEnemyArea : DamageArea
{
    [SerializeField] GameObject fadingSmudge = null;
    //Coroutine References
    Coroutine coolDownCoroutine = null;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (!enemy.TakingAreaDamage)
            {
                StartCoroutine(enemy.ActivateAreaHit(areaDamage, explosionOffSetY, coolDownDamageArea, ExplosionEffect));
                enemy.TakingAreaDamage = true;
            }
        }
    }

    public void ActivateDamageArea()
    {
        AreaCollider.enabled = true;
        StartCoroutine(CreateSmudge());

        IEnumerator CreateSmudge()
        {
            Vector3 lastPosition = transform.position;
            yield return new WaitForSeconds(.4f);
            StartCoroutine(CreateSmudge());
            yield return new WaitForSeconds(1f);
            Instantiate(fadingSmudge, transform.position, Quaternion.identity);
            
        }
    }
}

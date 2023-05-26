using System.Collections;
using UnityEngine;

public abstract class DamageAllEnemyArea : DamageArea
{
    [SerializeField] bool ActivateBurnEffect = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (!enemy.TakingAreaDamage)
            {
                StartCoroutine(enemy.ActivateAreaHit(areaDamage, explosionOffSetY, coolDownDamageArea, ExplosionEffect));
                enemy.TakingAreaDamage = true;
                if (ActivateBurnEffect) enemy.BurnEffect();
            }
        }
    }

    public abstract void ActivateDamageArea();
}

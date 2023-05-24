using System.Collections;
using UnityEngine;

public class DamageOneEnemyArea : DamageArea
{
    [SerializeField] SpriteRenderer areaSprite = null; 

    //Coroutine References
    Coroutine coolDownCoroutine = null;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && (coolDownCoroutine == null))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            coolDownCoroutine = StartCoroutine(AreaHitCoolDown(enemy));
        }
    }

    private IEnumerator AreaHitCoolDown(Enemy enemy)
    {
        int damageTaken = (int) enemy.CreatureArmor.CalculatedDamage(DamageType.Magic, areaDamage);
        enemy.CreatureHealth.TakeDamage(damageTaken);
        GameManager.DamageUIMessager.ShowDamageUI(damageTaken.ToString(), enemy.transform.position);
        Vector2 explosionPosition = new Vector2(enemy.transform.position.x, enemy.transform.position.y - explosionOffSetY);
        Instantiate(ExplosionEffect, explosionPosition, Quaternion.identity);
        yield return new WaitForSeconds(coolDownDamageArea);
        coolDownCoroutine = null;
    }

    public void ActivateDamageArea()
    {
        AreaCollider.enabled = true;
        areaSprite.enabled = true;
    }
}

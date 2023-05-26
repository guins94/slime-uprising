using System.Collections;
using UnityEngine;

public class DragonBreathDamageArea : DamageAllEnemyArea
{
    [SerializeField] GameObject dragonBreath = null;
    [SerializeField] float breathInitialRadius = 2f;
    public override void ActivateDamageArea()
    {
        AreaCollider.enabled = true;
        StartCoroutine(DragonsBreath());

        IEnumerator DragonsBreath()
        {
            yield return new WaitForSeconds(1.5f);
            StartCoroutine(DragonsBreath());
            // Calculdates the breath Rotation
            Vector2 aimRotation = new Vector2(GameManager.Player.CreatureBody.velocity.normalized.x, GameManager.Player.CreatureBody.velocity.normalized.y);
            Quaternion breathQuaternion = new Quaternion(0, 0 , Mathf.Atan2(aimRotation.y, aimRotation.x), 1);
            // Calcultates the Initial Position of the Breath
            Vector2 breathPosition = new Vector2(transform.position.x + GameManager.Player.CreatureBody.velocity.normalized.x * breathInitialRadius, transform.position.y + GameManager.Player.CreatureBody.velocity.normalized.y * breathInitialRadius);
            GameObject DragonBreath = Instantiate(dragonBreath, breathPosition, breathQuaternion);
        }
    }
}

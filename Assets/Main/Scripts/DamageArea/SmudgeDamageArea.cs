using System.Collections;
using UnityEngine;

public class SmudgeDamageArea : DamageAllEnemyArea
{
    [SerializeField] GameObject fadingSmudge = null;
    public override void ActivateDamageArea()
    {
        AreaCollider.enabled = true;
        StartCoroutine(CreateSmudge());

        IEnumerator CreateSmudge()
        {
            Vector3 lastPosition = transform.position;
            yield return new WaitForSeconds(.4f);
            StartCoroutine(CreateSmudge());
            yield return new WaitForSeconds(.3f);
            Instantiate(fadingSmudge, lastPosition, Quaternion.identity);
            
        }
    }
}

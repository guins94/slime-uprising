using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMessage : MonoBehaviour
{
    [SerializeField] Rigidbody2D messageBody = null;
    [SerializeField] TextMesh damageText = null;
    // Start is called before the first frame update
    void Start()
    {
        messageBody.AddForce(new Vector2(Random.Range(-2f, 2f), 10));
        StartCoroutine(DestroyAfterSeconds());
    }

    private IEnumerator DestroyAfterSeconds()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }

    public void ChangeText(string text)
    {
        damageText.text = text;
    }

}

using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CircleCollider2D))]
public abstract class Item : MonoBehaviour
{
    [Header("Item References")]
    [SerializeField] SpriteRenderer itemSpriteRenderer = null;
    [SerializeField] Collider2D itemCollider2D = null;

    //Public References
    public SpriteRenderer ItemSpriteRenderer => itemSpriteRenderer;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            itemCollider2D.enabled = false;
            ItemSpriteRenderer.enabled = false;
            StartCoroutine(ItemEffect());
        }
    }

    public abstract IEnumerator ItemEffect();
}

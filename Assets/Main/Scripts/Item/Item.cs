using System.Collections;
using System.Collections.Generic;
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

    public GameManager gameManager = null;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

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

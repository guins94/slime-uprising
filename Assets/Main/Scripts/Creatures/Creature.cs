using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creature : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Animator animator = null;
    [SerializeField] SpriteRenderer spriteRenderer = null;
    [SerializeField] HealthSystem creatureHealth = null;
    [SerializeField] Rigidbody2D creatureBody = null;

    // Public References
    public Animator Animator => animator;
    public SpriteRenderer SpriteRenderer => spriteRenderer;
    public Rigidbody2D CreatureBody => creatureBody;

    // Cached Variables
    public float movementSpeed = 0;
    public float Speed = 0;

    void Start()
    {
        creatureHealth.OnDeath += OnDeath;
    }

    void OnDestroy()
    {
        creatureHealth.OnDeath -= OnDeath;
    }

    // Update is called once per frame
    void Update() => Move();

    protected abstract void Move();

    protected abstract void OnDeath();
}

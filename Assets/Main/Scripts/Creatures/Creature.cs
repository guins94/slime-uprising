using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creature : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Animator animator = null;
    [SerializeField] SpriteRenderer spriteRenderer = null;
    [SerializeField] HealthSystem creatureHealth = null;

    // Public References
    public Animator Animator => animator;
    public SpriteRenderer SpriteRenderer => spriteRenderer;

    // Cached Variables
    public float movementSpeed = 0;
    public float Speed = 0;

    void Start()
    {
    }

    // Update is called once per frame
    void Update() => Move();

    public abstract void Move();
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [Header("Creatures Health System")]
    [SerializeField] float health = 1000;
    [SerializeField] float maxHealth = 1000;

    // Public References
    public float Health => health;
    public float MaxHealth => maxHealth;

    // Cached Components
    public Action OnDeath;

    public void TakeDamage(float reducedHealth)
    {
        if (reducedHealth <= 0 || health <= 0) return;
        if ((health - reducedHealth) < 1)
        {
            health = 0;
            OnDeath?.Invoke();
        } 
        else health = Mathf.Ceil(health - reducedHealth);
    }

    public void Heal(float gainedHealth)
    {
        if (gainedHealth >= 0 || health <= maxHealth) return;
        if (health + gainedHealth < maxHealth) health = maxHealth;
        else health = Mathf.Ceil(health + gainedHealth);
    }

    public void AddMaxHealth(float extraMaxHealth)
    {
        maxHealth = maxHealth + extraMaxHealth;
    }
}

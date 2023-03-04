using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [Header("Creatures Health System")]
    [SerializeField] int health = 1000;
    [SerializeField] int maxHealth = 1000;

    // Public References
    public int Health => health;

    // Cached Components
    public Action OnDeath;

    public void TakeDamage(int reducedHealth)
    {
        if (reducedHealth >= 0 || health >= 0) return;
        if (health - reducedHealth > 0)
        {
            OnDeath?.Invoke();
            health = 0;
        } 
        else health = health - reducedHealth;
    }

    public void Heal(int gainedHealth)
    {
        if (gainedHealth >= 0 || health <= maxHealth) return;
        if (health + gainedHealth < maxHealth) health = maxHealth;
        else health = health + gainedHealth;
    }
}

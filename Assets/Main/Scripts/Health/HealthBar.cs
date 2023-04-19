using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Updates the bar that show the player health
/// </summary>
public class HealthBar : Bar
{

    public void SetHealth(float health, float maxHealth)
    {
        value = health;
        maxValue = maxHealth;
    }
}

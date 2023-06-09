using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Updates the experience collected by the player
/// </summary>
public class ExperienceSystem : MonoBehaviour
{
    [SerializeField] HealthBar ExperienceBar = null;
    public Action OnLevelUp;
    public Action OnMaxLevel;
    int[] ExperienceLevel = new int[] {20, 50, 130, 250, 543};

    private int totalExperience = 0;
    private int currentExperience = 0;
    private int index = 0;
    bool maxLevelReached => ExperienceLevel.Length <= index; 

    private void Awake()
    {
        ExperienceBar.SetHealth(0, ExperienceLevel[index]);
    }

    private void Update()
    {
        if (!maxLevelReached)
        {
            if (currentExperience != totalExperience)
            {
                currentExperience = currentExperience + 1;
                if (ExperienceBar.value >= ExperienceLevel[index])
                {
                    OnLevelUp?.Invoke();
                    ExperienceBar.SetHealth(0, ExperienceLevel[index]);
                    index = index + 1;
                }
                else
                {
                    OnMaxLevel?.Invoke();
                    ExperienceBar.SetHealth(ExperienceBar.value + 1, ExperienceLevel[index]);
                }
            }
        }
    }

    public void ExperienceBarFollow(Creature follow)
    {
        ExperienceBar.PlayeFollow(follow);
    }

    public void AddExperience(int experience)
    {
        totalExperience = totalExperience + experience;
    }
}

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
    int[] ExperienceLevel = new int[] {20, 25, 50, 80, 120};

    private int totalExperience = 0;
    private int currentExperience = 0;
    private int index = 0;
    bool maxLevelReached => (ExperienceLevel.Length - 1) <= index; 

    // Variables Used to Level Up on Max Level
    private int maxExperienceReachedIndex = 0;

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
                    ExperienceBar.SetHealth(ExperienceBar.value + 1, ExperienceLevel[index]);
                }
            }
        }
        else
        {
            if (currentExperience != totalExperience)
            {
                currentExperience = currentExperience + 1;
                maxExperienceReachedIndex++;
                if (maxExperienceReachedIndex >= 50)
                {
                    OnMaxLevel?.Invoke();
                    maxExperienceReachedIndex = 0;
                    ExperienceBar.SetHealth(0, 50);
                    index = index + 1;
                }
                else
                {
                    ExperienceBar.SetHealth(ExperienceBar.value + 1, 50);
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

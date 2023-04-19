using System.Collections;
using UnityEngine;

public class ExperienceItem : Item
{
    private int experienceGained = 1;

    public override IEnumerator ItemEffect()
    {
        if (GameManager.Player != null)
        {
            GameManager.Player.ExperienceSystem.AddExperience(experienceGained);
        }
        yield return null;
    }
}

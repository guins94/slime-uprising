using System.Collections;
using UnityEngine;

public class ExperienceItem : Item
{
    public int experienceGained = 1;

    public override IEnumerator ItemEffect()
    {
        if (GameManager.Player != null)
        {
            GameManager.Player.ExperienceSystem.AddExperience(experienceGained);
            GameManager.EnemySpawn.ExperienceItemCollected();
            StartCoroutine(ItemDelete());
        }
        yield return null;
    }
}

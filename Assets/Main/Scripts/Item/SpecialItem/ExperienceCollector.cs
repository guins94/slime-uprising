using System.Collections;
using UnityEngine;

public class ExperienceCollector : Item
{
    public bool setExperienceGoToPlayer = false;
    public override IEnumerator ItemEffect()
    {
        if (setExperienceGoToPlayer)
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null) gameManager.experienceGoToPlayer = true;
        }
        StartCoroutine(CollectExperience());
        yield return null;
    }

    public IEnumerator CollectExperience()
    {
        ExperienceItem[] experienceItem = FindObjectsOfType<ExperienceItem>();
        yield return new WaitForSeconds(2f);
        for (int i = 0; i <= (experienceItem.Length - 1); i++)
        {
            experienceItem[i].SetGoToPlayer();
        }
    } 
}

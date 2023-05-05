using System.Collections;
using UnityEngine;

public class ExperienceCollector : Item
{
    public override IEnumerator ItemEffect()
    {
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
            Debug.Log(i);
        }
    } 
}

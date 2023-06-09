using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] Enemy[] enemyToSpawn = null;
    [SerializeField] ExperienceItem experienceItem = null;
    [SerializeField] MaxExperienceItem maxExperienceItemPrefab = null;
    [SerializeField] GameObject[] spawnPosition = null;

    private MaxExperienceItem maxExperienceItem = null;
    int indexSpawn = 0;
    public int maxNumberOfEnemys = 50;
    public int numberOfEnemysOnScreen = 0;
    public bool enemysReachedMax => numberOfEnemysOnScreen >= maxNumberOfEnemys;

    public int maxNumberOfExperienceItem = 200;
    public int numberOfExperienceItem = 0;
    public bool experienceItemReachedMax => numberOfExperienceItem >= maxNumberOfExperienceItem;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private void UpdateIndex()
    {
        if (indexSpawn >= spawnPosition.Length - 1)
        {
            indexSpawn = 0;
        }
        else
        {
            indexSpawn = indexSpawn + 1;
        }
    }

    public void SpawnAtRandomPlace()
    {
        if (!enemysReachedMax && maxExperienceItem == null)
        {
            numberOfEnemysOnScreen = numberOfEnemysOnScreen + 1;
            UpdateIndex();
            Enemy newEnemy = Instantiate(enemyToSpawn[0], spawnPosition[indexSpawn].transform.position, Quaternion.identity);
        }
    }

    public void SpawnAtRandomPlace(Enemy enemy)
    {
        if (!enemysReachedMax && maxExperienceItem == null)
        {
            numberOfEnemysOnScreen = numberOfEnemysOnScreen + 1;
            UpdateIndex();
            Enemy newEnemy = Instantiate(enemy, spawnPosition[indexSpawn].transform.position, Quaternion.identity);
        }
    }

    public void EnemyDefeated(Vector3 enemyPosition)
    {
        numberOfEnemysOnScreen = numberOfEnemysOnScreen - 1;
        if (experienceItemReachedMax)
        {
            if (maxExperienceItem == null)
                maxExperienceItem = Instantiate(maxExperienceItemPrefab, enemyPosition, Quaternion.identity);
            else
                maxExperienceItem.AddExperience();
        }
        else
        {
            Instantiate(experienceItem, enemyPosition, Quaternion.identity);
            numberOfExperienceItem = numberOfExperienceItem + 1;
        }
    }

    public void ExperienceItemCollected()
    {
        numberOfExperienceItem = numberOfExperienceItem - 1;
    }

    public void EnemyOutOfScreen(Vector3 enemyPosition)
    {

        numberOfEnemysOnScreen = numberOfEnemysOnScreen - 1;
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(1f);
        SpawnAtRandomPlace();
        StartCoroutine(SpawnEnemy());
    }
}

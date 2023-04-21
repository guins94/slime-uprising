using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] Enemy[] enemyToSpawn = null;
    [SerializeField] ExperienceItem experienceItem = null;
    
    [SerializeField] GameObject[] spawnPosition = null;
    int indexSpawn = 0;

    public int maxNumberOfEnemys = 30;
    public int numberOfEnemysOnScreen = 0;
    public bool enemysReachedMax => numberOfEnemysOnScreen >= maxNumberOfEnemys;

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
        UpdateIndex();
        Enemy newEnemy = Instantiate(enemyToSpawn[0], spawnPosition[indexSpawn].transform.position, Quaternion.identity);
        EnemyDefeated(newEnemy.transform.position);
    }

    public void EnemyDefeated(Vector3 enemyPosition)
    {
        if (numberOfEnemysOnScreen < maxNumberOfEnemys)
        {
            Instantiate(experienceItem, enemyPosition, Quaternion.identity);
            numberOfEnemysOnScreen = numberOfEnemysOnScreen - 1;
        }
    }

    public bool CanCreateEnemy()
    {
        if (numberOfEnemysOnScreen >= maxNumberOfEnemys)
        {
            return false;
        }
        return true;
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(1f);
        SpawnAtRandomPlace();
        StartCoroutine(SpawnEnemy());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    [SerializeField] Item[] itemToSpawn = null;
    [SerializeField] Item coinItem = null;

    
    [SerializeField] GameObject[] spawnPosition = null;

    int indexSpawn = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(SpawnItem());
        GameEventsManager.GoldCoinCollected += GoldCoinCollected;
        SpawnInitialItem();
    }

    void OnDestroy()
    {
        GameEventsManager.GoldCoinCollected -= GoldCoinCollected;
    }

    private void SpawnInitialItem()
    {
        List<Item> possibleSpawn = new List<Item>();
        if (GameManager.GameManagerInstance.ScrollShopIndexVector != null)
        {
            if (GameManager.GameManagerInstance.ScrollShopIndexVector[0] == true)
                possibleSpawn.Add(itemToSpawn[0]);
            if (GameManager.GameManagerInstance.ScrollShopIndexVector[1] == true)
                possibleSpawn.Add(itemToSpawn[1]);
            if (GameManager.GameManagerInstance.ScrollShopIndexVector[2] == true)
                possibleSpawn.Add(itemToSpawn[2]);
        }
        if (possibleSpawn == new List<Item>()) return;
        else
        {
            int i = Random.Range(0, possibleSpawn.Count);
            Debug.Log("teste" + i);
            Instantiate(itemToSpawn[i], Vector3.zero, Quaternion.identity);
        } 
    }

    void GoldCoinCollected() => StartCoroutine(SpawnGoldCoin());

    public void SpawnAtRandomPlace()
    {
        UpdateIndex();
        Item newItem = Instantiate(itemToSpawn[0], spawnPosition[indexSpawn].transform.position, Quaternion.identity);
    }

    IEnumerator SpawnGoldCoin()
    {
        yield return new WaitForSeconds(1f);
        UpdateIndex();
        Item newItem = Instantiate(coinItem, spawnPosition[indexSpawn].transform.position, Quaternion.identity);
    }

    IEnumerator SpawnItem()
    {
        yield return new WaitForSeconds(1f);
        SpawnAtRandomPlace();
        StartCoroutine(SpawnItem());
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
}

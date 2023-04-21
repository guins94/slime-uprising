using UnityEngine;

public class GameManager : GameManagerT
{
    

    // Start is called before the first frame update
    void Start()
    {
        GameManagerInstance = this;
        Debug.Log(GameManagerInstance);
        Player = FindObjectOfType<PlayerSlime>();
        DamageUIMessager = FindObjectOfType<DamageUIMessager>();
        ItemCanvaController = FindObjectOfType<ItemCanvaController>();
        EnemySpawn = FindObjectOfType<EnemySpawn>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}

using UnityEngine;

public class GameManager : GameManagerT
{
    public int maxNumberOfEnemys = 30;
    public int numberOfEnemysOnScreen = 0;
    public bool enemysReachedMax => numberOfEnemysOnScreen >= maxNumberOfEnemys;

    // Start is called before the first frame update
    void Start()
    {
        GameManagerInstance = this;
        Debug.Log(GameManagerInstance);
        Player = FindObjectOfType<PlayerSlime>();
        DamageUIMessager = FindObjectOfType<DamageUIMessager>();
        ItemCanvaController = FindObjectOfType<ItemCanvaController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using UnityEngine;

public class MenuGameManager : GameManagerT
{
    // Start is called before the first frame update
    void Awake()
    {
        GameManagerInstance = this;
        Player = FindObjectOfType<PlayerSlime>();
    }
}

using System.Collections;
using System.Collections.Generic;
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

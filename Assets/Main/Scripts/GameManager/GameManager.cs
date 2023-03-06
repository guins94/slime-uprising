using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameManager GameManagerInstance { get; protected set; } = null;

    public PlayerSlime Player { get; protected set; } = null;
    // Start is called before the first frame update
    void Start()
    {
        GameManagerInstance = this;
        Debug.Log(GameManagerInstance);
        Player = FindObjectOfType<PlayerSlime>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

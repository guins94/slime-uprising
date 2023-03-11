using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D BulletBody = null;
    [SerializeField] float baseFrequencie = 2f;
    [SerializeField] float radiusLength = 4f;

    public bool slow = false;
    public bool explosion = false;
    public bool burn = false;
    public bool push = false;

    public float offsetFrequencie = 0f;

    public float offsetRadius = 0f;

    GameManager gameManager = null;

    Coroutine BulletCoroutine = null;

    Vector3 TargetPosition = Vector2.zero;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        float targetPositionX = gameManager.GameManagerInstance.Player.transform.position.x + (radiusLength + offsetRadius)*Mathf.Sin((Time.time + offsetFrequencie) * baseFrequencie);
        float targetPositionY = gameManager.GameManagerInstance.Player.transform.position.y + (radiusLength + offsetRadius)*Mathf.Cos((Time.time + offsetFrequencie) * baseFrequencie);
        transform.position = new Vector2(targetPositionX, targetPositionY);
    }
}

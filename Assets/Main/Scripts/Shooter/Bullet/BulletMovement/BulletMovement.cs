using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletMovement : MonoBehaviour
{
    
    [SerializeField] float baseFrequencie = 2f;
    [SerializeField] float radiusLength = 4f;
    [SerializeField] float fireRate = 2f;

    // Public References
    public float BaseFrequencie => baseFrequencie;
    public float RadiusLength =>  radiusLength;
    public float FireRate => fireRate;

    //
    public CompassDirection compassDirection = CompassDirection.North;
    public float offsetRadius = 0f;
    public float targetPositionX = 0;
    public float targetPositionY = 0;
    private float timePosition = 0;
    private float timeScale = 0;
    Vector3 StartScale = Vector3.one;
    public Vector2 CompassVectorDirection = Vector2.zero;


    public void Start()
    {
        Vector3 StartScale = transform.localScale;
    }

    public void MoveOriginTarget(Vector2 originPosition, Vector2 targetPosition, float duration)
    {
        
        timePosition += Time.deltaTime / duration;
        Vector2 newPosition = Vector2.Lerp(originPosition, targetPosition, timePosition);
        targetPositionX = newPosition.x;
        targetPositionY = newPosition.y;
        if (timePosition > 1) 
        {
            timePosition = 0;
            timeScale = 0;
            transform.position = originPosition;
            transform.localScale = Vector3.zero;
        }
    }

    public void AppearIdle(float duration)
    {
        timeScale += Time.deltaTime / duration;
        
        Vector3 newScale = Vector3.Lerp(Vector3.zero, StartScale, timeScale);
        transform.localScale = newScale;
    }

    public abstract void ChangeMovement(int level);

    IEnumerator DisappearingShoot()
    {
        Vector3 StartScale = transform.localScale;
        transform.localScale = Vector3.zero;
        float appearingTime = fireRate * (1 / 10);
        for (float t = 0; t > 1; t += Time.deltaTime / appearingTime)
        {
            Vector3 newScale = Vector3.Lerp(Vector3.zero, StartScale, t);
            transform.localScale = newScale;
        }

        yield return new WaitForSeconds(2f);
    }
}
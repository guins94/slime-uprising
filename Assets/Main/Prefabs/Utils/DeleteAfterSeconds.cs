using System.Collections;
using UnityEngine;

public class DeleteAfterSeconds : MonoBehaviour
{
    public float secondsToDestroy = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyGameObjectAfterSeconds());
    }

    IEnumerator DestroyGameObjectAfterSeconds()
    {
        yield return new WaitForSeconds(secondsToDestroy);
        Destroy(this.gameObject);
    }
}

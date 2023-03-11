using UnityEngine;

public class CircleFunction : MonoBehaviour
{
    [SerializeField] float radius = 1f;
    [SerializeField] float frequencie = 1f;
    public Vector2 circlePosition = new Vector2(0,1);

    void Start()
    {

    }

    void Update()
    {
        Debug.Log(Mathf.Sin(Time.time * 5));
    }
}

using UnityEngine;

/// <summary>
/// Class responsible for updating the health bar
/// It always follows a Creature
/// </summary>
public class Bar : MonoBehaviour
{
    [Header("Game Object to be followed")]
    [SerializeField] GameObject fill = null;

    // Cached Components
    private Creature playeFollow = null;
    public float maxValue = 10;
    public float value = 2;

    // Vectors to Control the Health Bar Position and Scale
    public Vector3 scaleChange = new Vector3(0.26f, 0.1573f, 1);
    public Vector3 Offset = new Vector3(0, 1, 0);

    /// <summary>
    /// Class used by other instances to Update the Creature that the bar must follow.
    /// </summary>
    public void PlayeFollow(Creature follow)
    {
        playeFollow = follow;
    }

    /// <summary>
    /// Class responsible for updating the health bar
    /// </summary>
    private void Update()
    {
        UpdateScale();
        UpdatePosition();
    }

    /// <summary>
    /// Class responsible for updating the health bar scale
    /// </summary>
    private void UpdateScale()
    {
        float aux = value/maxValue;
        Vector3 updateScale = new Vector3(aux * scaleChange.x, scaleChange.y, scaleChange.z);
        if (fill != null) fill.transform.localScale = updateScale;
    }

    /// <summary>
    /// Class responsible for updating the health bar position
    /// Destroys the health bar if it does not have a Creature to follow
    /// </summary>
    private void UpdatePosition()
    {
        if (playeFollow != null)
            transform.position = new Vector3(playeFollow.transform.position.x + Offset.x, playeFollow.transform.position.y + Offset.y,
        playeFollow.transform.position.z + Offset.z);
        else
            Destroy(gameObject);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;


public class Teleport : MonoBehaviour
{
    [SerializeField] Collider2D areaTeleport = null;

    public void LoadScene(int scene)
    {
        SceneManager.LoadSceneAsync(scene);
    }

    /// <summary>
    /// Enterring the area Starts a the game at a level
    /// </summary>
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LoadScene(1);
        }
    }
}



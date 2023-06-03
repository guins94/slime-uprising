using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AnimationButtonClick : MonoBehaviour
{
    [Header("Enemy Activate")]
    [SerializeField] float TimeToFade = 1;
    [SerializeField] GameObject enemy1 = null;
    [SerializeField] GameObject enemy2 = null;
    [SerializeField] GameObject enemy3 = null;

    [Header("Other References")]
    [SerializeField] SpriteRenderer SlimeSprite = null;

    [Header("Fade Out Canva")]
    [SerializeField] CanvasGroup FadeOutCanva = null;

    //Cached Componentes
    bool fadeOut = false;

    public void OnMouseDown()
    {
        SlimeSprite.enabled = false;

        enemy1.SetActive(true);
        enemy1.GetComponent<Rigidbody2D>().AddForce(Vector2.up*22);

        enemy2.SetActive(true);
        enemy2.GetComponent<Rigidbody2D>().AddForce(Vector2.up*22);

        enemy3.SetActive(true);
        enemy3.GetComponent<Rigidbody2D>().AddForce(Vector2.up*23);

        StartCoroutine(WaitForFadeOut());
    }

    IEnumerator WaitForFadeOut()
    {
        yield return new WaitForSeconds(3f);
        fadeOut = true;
    }

    void Update()
    {
        if (fadeOut)
        {
            if (FadeOutCanva.alpha < 1)
            {
                Debug.Log("update");
                FadeOutCanva.alpha += Time.deltaTime * TimeToFade;
                if (FadeOutCanva.alpha >= 1)
                {
                    fadeOut = false;
                    SceneManager.LoadSceneAsync(1);
                } 
            }
        }
    }
}

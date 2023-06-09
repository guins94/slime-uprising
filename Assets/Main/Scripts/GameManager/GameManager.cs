using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : GameManagerT
{
    [SerializeField] Canvas BookCanvas = null;
    [SerializeField] Canvas MaxLevelCanvas = null;

    [Header("Enemy Reference")]
    [SerializeField] Enemy bigEnemy = null;
    
    public bool experienceGoToPlayer = false;

    public int floorLevel = 0;

    // Start is called before the first frame update
    void Awake()
    {
        GameManagerInstance = this;
        Player = FindObjectOfType<PlayerSlime>();
        DamageUIMessager = FindObjectOfType<DamageUIMessager>();
        ItemCanvaController = FindObjectOfType<ItemCanvaController>();
        EnemySpawn = FindObjectOfType<EnemySpawn>();
        SoundManager = FindObjectOfType<SoundManager>();

        // Starts to Hear Player Actions
        Player.ExperienceSystem.OnLevelUp += OnLevelUp;
        Player.ExperienceSystem.OnMaxLevel += OnMaxLevel;
        Player.CreatureHealth.OnDeath += GameOver;

        // Main Game Loop
        StartCoroutine(StartGameLoop());
    }

    /// <summary>
    /// Game Over Happens when the player dies.
    /// </summary>
    IEnumerator StartGameLoop()
    {
        while (gameObject.activeInHierarchy)
        {
            // Run Game Next Step And Wait Until It Is Done
            yield return StartCoroutine(FloorNextLevel());
            yield return null;
        }
    }

    IEnumerator FloorNextLevel()
    {
        bool shouldBreak = false;
        int defeatedEnemys = 0;
        GameEventsManager.EnemyDefeated += EnemyDefeated;

        yield return new WaitUntil(() => shouldBreak);

        void EnemyDefeated()
        {
            defeatedEnemys++;
            if (defeatedEnemys == 10)
            {
                floorLevel++;
                defeatedEnemys = 0;
                Debug.Log("Level " + floorLevel);
                if (floorLevel == 5)
                {
                    if (EnemySpawn != null) EnemySpawn.SpawnAtRandomPlace(bigEnemy);
                }
                    

            }
        }
    }

    // On Destroy is Called when game manager is detroyed
    void OnDestroy()
    {
        // Stops Hearing Player Actions
        Player.ExperienceSystem.OnLevelUp -= OnLevelUp;
        Player.ExperienceSystem.OnLevelUp -= OnMaxLevel;
        Player.CreatureHealth.OnDeath -= GameOver;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Game Over Happens when the player dies.
    /// </summary>
    void GameOver()
    {
        GameManager.SoundManager.Play(3);
        StartCoroutine(PauseLateActivate());

        IEnumerator PauseLateActivate()
        {
            yield return new WaitForSeconds(3f);
            SceneManager.LoadSceneAsync(2);
        }
    }

    /// <summary>
    /// Level Up Handler
    /// </summary>
    void OnLevelUp()
    {
        GameManager.SoundManager.Play(4);
        if (BookCanvas != null)
        {
            Time.timeScale = 0f;
            BookCanvas.enabled = true;
        } 
    }

    /// <summary>
    /// Max Level Reached
    /// </summary>
    void OnMaxLevel()
    {
        GameManager.SoundManager.Play(4);
        if (BookCanvas != null)
        {
            Time.timeScale = 0f;
            MaxLevelCanvas.enabled = true;
        } 
    }
}

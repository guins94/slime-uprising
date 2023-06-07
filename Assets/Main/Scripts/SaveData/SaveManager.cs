using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SaveManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    //Cached Components

    private GameData gameData;
    private List<ISaveData> saveDataObjects;
    private FileDataHandler FileDataHandler;
    public static SaveManager instance { get; private set; }

    private void Start()
    {
        this.FileDataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.saveDataObjects = FindAllDataSaveDataObjects();
        LoadGame();
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Data Persistance Manager");
        }
        instance = this;
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        // load ane saved data from a file using data handler
        this.gameData = FileDataHandler.Load();

        // if the file is null creates a new game data
        if (this.gameData == null)
        {
            Debug.Log("No data was found. Initializing data to defaults");
            NewGame();
        }

        foreach (ISaveData saveDataObject in saveDataObjects)
        {
            saveDataObject.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        foreach (ISaveData saveDataObject in saveDataObjects)
        {
            saveDataObject.SaveData(ref gameData);
        }

        // save that data to a file using the data handler
        FileDataHandler.Save(gameData);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    // Called to get all ISaveManager 
    private List<ISaveData> FindAllDataSaveDataObjects()
    {
        IEnumerable<ISaveData> saveDataObjects = FindObjectsOfType<MonoBehaviour>().OfType<ISaveData>();

        return new List<ISaveData>(saveDataObjects);
    }
}

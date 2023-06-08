using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileDataHandler : MonoBehaviour
{
    private string dataDirPath = "";
    private string dataFileName = "";

    public FileDataHandler(string dataDirPath, string dataFileName)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }

    public GameData Load()
    {
        // Use Path.Combine to accoutn for different OS
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        GameData loadedData = null;
        if (File.Exists(fullPath))
        {
            try
            {
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                        Debug.Log(dataToLoad);
                    }
                }

                // desearileze from Json
                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
            }
            catch (Exception e)
            {
                Debug.LogError("Error occured when tring to load data from file: "+ fullPath + "\n" + e);
            }
        }
        return loadedData;
    }

    public void Save(GameData data)
    {
        // Use Path.Combine to accoutn for different OS
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        try
        {
            // create the directory the file will be written to if does not exist
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            // serialize the C# GAME DATA OBJECT INTO jSON
            string dataToStore = JsonUtility.ToJson(data, true);

            //write the serialized data to the file
            using (FileStream stream  = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error occured when trying to save data to file: " + fullPath + "\n" + e);
        }
    }
}

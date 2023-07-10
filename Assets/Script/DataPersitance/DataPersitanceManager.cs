using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class DataPersitanceManager : MonoBehaviour
{

    [Header("File storage config")]
    [SerializeField] private string fileName;

    public static DataPersitanceManager Instance { get; private set; }
    public GameData gameData;

    private static List<IDataPersitance> dataPersitanceObject;

    private FileDataHandler fileDataHandler;

    private void Awake()
    {
        if (Instance != null) Debug.LogError("This only one data persitance");
        Instance = this;
        this.fileDataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        dataPersitanceObject = FindAllDataPersitanceObject();
        LoadGame();
    }

    private List<IDataPersitance> FindAllDataPersitanceObject()
    {
        IEnumerable<IDataPersitance> dataPersitanceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersitance>();
        return new List<IDataPersitance>( dataPersitanceObjects);
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        this.gameData = fileDataHandler.Load();
        // load moi data tu file su dung data handler
        if (this.gameData == null)
        {
            Debug.Log("No data game was found");
            NewGame();
        }
        else Debug.Log("chay qua day roi");

        foreach(IDataPersitance dataPersitanceObj in dataPersitanceObject)
        {
            dataPersitanceObj.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        foreach (IDataPersitance dataPersitanceObj in dataPersitanceObject)
        {
            dataPersitanceObj.SaveData(ref gameData);
        }
        fileDataHandler.Save(gameData);
    }
    private void OnApplicationQuit()
    {
        SaveGame();
    }
}

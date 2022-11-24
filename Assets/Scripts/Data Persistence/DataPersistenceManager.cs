using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using LootLocker.Requests;
using System.IO;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] public string fileName;

    private GameData gameData;

    private List<IDataPersistence> dataPersistenceObjects;

    private FileDataHandler dataHandler;

    public static DataPersistenceManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Data Persistance Manager in the scene!");
        }
        instance = this;
    }

    private void Start()
    {
        this.dataHandler = new FileDataHandler("Assets/SavedGames/", fileName);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        LoadFromLootLocker();
        this.gameData = dataHandler.Load();

        if (this.gameData == null)
        {
            Debug.Log("No data found. Initializing to defaults");
            NewGame();
        }

        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(gameData);
        }

        dataHandler.Save(gameData);
        SaveToLootLocker();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>(true).OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }

    public void SaveToLootLocker()
    {
        LootLockerSDKManager.UploadPlayerFile("Assets/SavedGames/savedata.json", "save_game", response =>
        {
            if (response.success)
            {
                Debug.Log("Successfully uploaded player file, url: " + response.url);
            }
            else
            {
                Debug.Log("Error uploading player file");
            }
        });
    }

    public void LoadFromLootLocker()
    {      
        LootLockerSDKManager.GetAllPlayerFiles((response) =>
        {            
            if (response.success)
            {                
                Debug.Log("Successfully retrieved player files: " + response.items.Length);
            }
            else
            {
                Debug.Log("Error retrieving player storage");
            }
        });
    }
}

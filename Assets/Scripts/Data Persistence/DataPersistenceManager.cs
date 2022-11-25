using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using LootLocker.Requests;
using System.IO;
using UnityEngine.Networking;
using Newtonsoft.Json.Linq;

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
        //LoadFromLootLocker();
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
        int playerFileId = 177366;
        LootLockerSDKManager.UploadPlayerFile("Assets/SavedGames/savedata.json", "save_game1", response =>
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
        int id = 177366;
        LootLockerSDKManager.GetPlayerFile(id, (response) =>
        {
            if (response.success)
            {                
                StartCoroutine(LoadRoutine(response.url));
            }
        });
    }

    IEnumerator LoadRoutine(string url)
    {
        string content = "";
        bool gotData = false;
        yield return Download(url, (data) =>
        {
            content = data;
            gotData = true;
        });
        yield return new WaitWhile(() => gotData == false);        
    }

    IEnumerator Download(string url, System.Action<string> fileContent)
    {
        UnityWebRequest www = new UnityWebRequest(url);
        www.downloadHandler = new DownloadHandlerBuffer();
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            Debug.Log(www.downloadHandler.text);
            fileContent(www.downloadHandler.text);

            string savePath = string.Format("Assets/SavedGames/savedata.json");
            System.IO.File.WriteAllText(savePath, www.downloadHandler.text);
        }
    }
}

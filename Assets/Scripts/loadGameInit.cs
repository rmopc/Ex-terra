using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;


public class loadGameInit : MonoBehaviour
{
    public DataPersistenceManager DPM;
    public bool hasLoaded = false;

    void Start()
    {
        LoadGame();
    }

    private async void LoadGame()
    {
        await Wait();
        if (!hasLoaded)
        {
            DPM.LoadFromLootLocker();
            hasLoaded = true;
        }
    }

    private Task Wait()
    {
        return Task.Delay(1000);
    }
}

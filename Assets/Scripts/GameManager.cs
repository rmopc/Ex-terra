using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;

public class GameManager : MonoBehaviour
{

    public bool sessionStarted;
    void Start()
    {

        sessionStarted = false;
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (!response.success)
            {                
                Debug.Log("error starting LootLocker session");

                return;
            }
            Debug.Log("successfully started LootLocker session" + response.Error);
            sessionStarted = true;
        });
    }
}
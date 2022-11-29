using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public Vector3 playerPos;
    public SerializableDictionary<string, bool> lockedState;

    public GameData()
    {
        playerPos = Vector3.zero;
        lockedState = new SerializableDictionary<string, bool>();
    }
}

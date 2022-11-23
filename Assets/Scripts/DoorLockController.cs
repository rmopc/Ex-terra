using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class DoorLockController : MonoBehaviour, IDataPersistence
{
    [Tooltip("Right-click this component to generate ID")]
    [SerializeField] private string id;

    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    public bool isLocked;
    private bool happenedOnce;

    void Start()
    {
        isLocked = true;
        happenedOnce = false;
    }

    void Update()
    {
        if (!isLocked && !happenedOnce)
        {
            Debug.Log("Door is unlocked!");
            GetComponent<DoorDoubleSlide>().enabled = true;
            GetComponent<AudioSource>().enabled = true;
            happenedOnce=true;
        }
    }

    public void LoadData(GameData data)
    {
        data.lockedState.TryGetValue(id, out isLocked);
        if (isLocked)
        {
            isLocked = true;
        }
    }

    public void SaveData(GameData data)
    {
        if (data.lockedState.ContainsKey(id))
        {
            data.lockedState.Remove(id);
        }
        data.lockedState.Add(id, isLocked);
    }
}

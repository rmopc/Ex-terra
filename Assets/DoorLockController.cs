using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLockController : MonoBehaviour
{
    public bool isLocked;

    void Start()
    {
        isLocked = true;
    }


    void Update()
    {
        if (!isLocked)
        {
            Debug.Log("Door is unlocked!");
            GetComponent<DoorDoubleSlide>().enabled = true;
            GetComponent<AudioSource>().enabled = true;
        }
    }
}

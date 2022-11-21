using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastSimpleSwitch : MonoBehaviour
{
    public bool isToggled;
    public bool isUsable;
    public AudioSource audioSource;

    void Start()
    {
        isToggled = true;
        isUsable = false;
    }

    public void UseSwitch()
    {
        isToggled = false;
    }
}

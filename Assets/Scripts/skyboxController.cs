using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyboxController : MonoBehaviour
{
    public Material skybox;

    public void DisableSkybox()
    {
        RenderSettings.skybox = null;
    }
    public void EnableSkybox()
    {
        RenderSettings.skybox = skybox;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;


public class skyboxController : MonoBehaviour
{
    public Material skybox;

    public void Start()
    {
        InitializeSkybox();
    }

    public async void InitializeSkybox()
    {
        DisableSkybox();
        await Wait();
        EnableSkybox();
    }

    private Task Wait()
    {
        return Task.Delay(500);
    }

    public void DisableSkybox()
    {
        RenderSettings.skybox = null;
    }
    public void EnableSkybox()
    {
        RenderSettings.skybox = skybox;
    }
}

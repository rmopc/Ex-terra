using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emissionChanger : MonoBehaviour
{
    private Light[] lights;
    public Material lightEmission;

    void Start()
    {
        lights = FindObjectsOfType(typeof(Light)) as Light[];
        lightEmission.SetColor("_EmissionColor", Color.white);
    }

    public void setEmissionRed()
    {
        lightEmission.SetColor("_EmissionColor", Color.red);
        foreach (Light light in lights)
        {
            light.enabled = false;     
        }
    }

    public void setEmissionWhite()
    {
        lightEmission.SetColor("_EmissionColor", Color.white);
        foreach (Light light in lights)
        {
            light.enabled = true;
        }
    }

}

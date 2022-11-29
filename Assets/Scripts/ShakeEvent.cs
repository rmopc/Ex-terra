using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeEvent : MonoBehaviour
{
    public CameraShake cameraShake;
    public AudioClip explosionSound;
    public AudioClip alarmSound;
    public GameObject panel;

    private Light[] lights;
    public Material lightEmission;

    public bool hasHappened;
    private AudioSource audioSource;

    public float duration;
    public float magnitude;

    void Start()
    {
        lights = FindObjectsOfType(typeof(Light)) as Light[];
        lightEmission.SetColor("_EmissionColor", Color.white);
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !hasHappened)
        {
            StartCoroutine(cameraShake.Shake(duration, magnitude));
            audioSource.PlayOneShot(explosionSound);
            hasHappened = true;
            StartCoroutine(BlackOutTime());
            StartCoroutine(AlarmSoundTime());
        }
    }

    IEnumerator BlackOutTime()
    {
        yield return new WaitForSeconds(3f);
        lightEmission.SetColor("_EmissionColor", Color.black);
        foreach (Light light in lights)
        {
            light.enabled = false;
        }
    }

    IEnumerator AlarmSoundTime()
    {
        yield return new WaitForSeconds(6f);        
        audioSource.clip = alarmSound;
        audioSource.loop = true;
        audioSource.Play();        
        lightEmission.SetColor("_EmissionColor", Color.red);
        panel.GetComponent<RayCastSimpleSwitch>().isUsable = true;
    }
}

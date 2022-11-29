using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioFader : MonoBehaviour
{
    private AudioSource audioSource;
    public float fadeTime = 2f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(FadeIn(audioSource, fadeTime));
    }

    // Update is called once per frame
    public static IEnumerator FadeIn(AudioSource audioSource, float FadeTime)
    {
        audioSource.Play();
        audioSource.volume = 0f;
        while (audioSource.volume < 0.6f)
        {
            audioSource.volume += Time.deltaTime / FadeTime;
            yield return null;
        }
    }
}

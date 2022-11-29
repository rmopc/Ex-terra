using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class pointerHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool mouse_over = false;
    private AudioSource audioSource;

    public AudioClip mouseOverClip;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouse_over = true;
        audioSource.PlayOneShot(mouseOverClip);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouse_over = false;
    }
}

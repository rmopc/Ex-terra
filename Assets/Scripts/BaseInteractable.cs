using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseInteractable : MonoBehaviour, IInteractable
{
    public UnityEvent interactEvent;
    public UnityEvent onEnterEvent;
    public UnityEvent onExitEvent;

    public void OnInteract()
    {
        //suorittaa kaikki UnityEventiin liitetyt funktiot
        interactEvent.Invoke();
    }

    public void OnEnterInteract()
    {
        onEnterEvent.Invoke();
    }

    public void OnExitInteract()
    {
        onExitEvent.Invoke();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttach : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject == player)
        {
            player.transform.parent = transform;
        }
    }
}

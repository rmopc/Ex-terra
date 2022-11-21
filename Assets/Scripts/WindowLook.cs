using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class WindowLook : MonoBehaviour
{
    private bool isLooking;
    private bool guiShow = false;

    public GameObject player;
    public GameObject windowCamera;
    public Transform exitPosition;

    public PlayableDirector director;

    // Start is called before the first frame update
    void Start()
    {
        isLooking = false;
        windowCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isLooking && Input.GetKeyDown(KeyCode.F))
        {
            isLooking = false;
            player.transform.position = exitPosition.transform.position;
            director.Stop();
            windowCamera.SetActive(false);
            player.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        guiShow = true;
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            guiShow = false;
            isLooking = true;
            player.SetActive(false);
            windowCamera.SetActive(true);
            director.Play();   
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isLooking = false;
            guiShow = false;
        }
    }

    void OnGUI()
    {
        if (guiShow == true)
        {
            GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 100, 25), "Look outside");
        }
    }
}

using ECM.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class FaderHandler : MonoBehaviour
{
    public GameObject player;
    public GameObject startPos;
    
    public GameObject cryoCam;
    public GameObject playerCam;
    public GameObject uiText;

    private PlayableDirector director;
    private BaseFirstPersonController playerControls;
    private bool hasfaded;
    private bool guiShow = false;

    public GameObject cryoDoorState;
    public GameObject sleepingGirl;
    
    void Start()
    {
        director = GetComponent<PlayableDirector>();
        playerControls = player.GetComponent<BaseFirstPersonController>();
        playerControls.enabled = false;
        playerCam.gameObject.SetActive(false);
        cryoCam.gameObject.SetActive(true);

        hasfaded = false;             
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !hasfaded)
        {
            hasfaded=true;
            director.Play();
            StartCoroutine(DeactivateText());
        }

        if (cryoDoorState.GetComponent<RayCastDoorRemote>().isOpen == true && playerControls.enabled == false)
        {
            guiShow = true;
        }

        if (Input.GetKeyDown(KeyCode.E) && hasfaded && cryoDoorState.GetComponent<RayCastDoorRemote>().isOpen == true)
        {            
            playerControls.enabled = true;
            playerCam.gameObject.SetActive(true);
            cryoCam.gameObject.SetActive(false);
            sleepingGirl.gameObject.SetActive(false);
            guiShow = false;
            StartCoroutine(DeactivateGameObject());
        }
    }

    IEnumerator DeactivateText()
    {
        yield return new WaitForSeconds(2.02F);
        uiText.SetActive(false);
    }

    void OnGUI()
    {
        if (guiShow == true)
        {
            GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 125, 25), "Exit Cryo-pod (E)");
        }
    }

    IEnumerator DeactivateGameObject()
    {
        yield return new WaitForSeconds(2.00F);
        gameObject.SetActive(false);
    }
}

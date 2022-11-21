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
            StartCoroutine(Deactivate());
        }

        if (Input.GetKeyDown(KeyCode.E) && hasfaded && cryoDoorState.GetComponent<RayCastDoorRemote>().isOpen == true )
        {
            playerControls.enabled = true;
            playerCam.gameObject.SetActive(true);
            cryoCam.gameObject.SetActive(false);
            sleepingGirl.gameObject.SetActive(false);            
        }
    }

    IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(2.02F);
        uiText.SetActive(false);
    }
}

using System.Collections;
using UnityEngine;

public class RayCastSend : MonoBehaviour
{
    /*
     * T�m� liitet��n tyhj��n objektiin hierarkiassa.
     * T�m� ampuu s�teen, joka triggerin perusteella suorittaa toiminnon
     * Huom! Et�isyys objektista ei voi olla "liian kaukana" kamerasta, eli jos s�dett� ei ammuta, tarkista et�isyydet
    */

    public int rayLength = 2; 

    bool guiShow = false;
    bool interacted;

    RaycastHit hit;

    void Start()
    {
        
    }

    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, rayLength))
        {
            Debug.DrawRay(transform.position, transform.forward, Color.green);
            
            //if (hit.collider.tag == "door")
            //{
            //    guiShow = true;
            //    {                                                                                                 
            //        if (Input.GetKeyDown("f"))
            //        {
            //            hit.collider.transform.parent.GetComponent<RayCastDoor>().OpenDoor();
            //        }
            //    }
            //}

            if (hit.collider.tag == "button")
            {
                Debug.Log("hitting button");
                guiShow = true;
                {
                    if (Input.GetKeyDown("f"))
                    {
                        hit.collider.transform.GetComponent<RayCastDoorRemote>().OpenDoor();
                    }
                }
            }

            if (hit.collider.tag == "panel")
            {
                Debug.Log("hitting panel");
                guiShow = true;
                {
                    if (Input.GetKeyDown("f"))
                    {
                        hit.collider.transform.GetComponent<RayCastSimpleSwitch>().UseSwitch();
                        hit.collider.GetComponent<IInteractable>().OnInteract();
                    }
                }
            }

            if (hit.collider.tag == "android")
            {
                Debug.Log("hitting");
                guiShow = true;
                {
                    if (Input.GetKeyDown("f"))
                    {
                        //hit.collider.transform.parent.GetComponent<RayCastLift>().UseLift();
                    }
                }
            }

            if (hit.collider.tag == "interactable")
            {
                Debug.Log("hitting interactable object");
                guiShow = true;
                {
                    if (Input.GetKeyDown("f"))
                    {                        
                        hit.collider.GetComponent<IInteractable>().OnInteract();
                        guiShow = false;
                    }
                }
            }

            if (hit.collider.tag == "interactableOnce") //tarkista ettei t�� nyt spedee t�st� yhdest� kerrasta
            {
                Debug.Log("hitting interactable object");
                guiShow = true;
                {
                    if (Input.GetKeyDown("f"))
                    {
                        interacted = true;
                        hit.collider.GetComponent<IInteractable>().OnInteract();
                    }
                }
            }

            //if (hit.collider.tag == "generator")
            //{
            //    Debug.Log("hitting interactable object");
            //    guiShow = true;
            //    {
            //        if (Input.GetKeyDown("f"))
            //        {
            //            hit.collider.transform.GetComponent<GeneratorManager>().Interact();
            //        }
            //    }
            //}

            //if (hit.collider.tag == "cardoor")
            //{
            //    guiShow = true;
            //    //{
            //    //    if (Input.GetKeyDown("f"))
            //    //    {
            //    //        hit.collider.transform.parent.GetComponent<RayCastDoor>().OpenDoor();
            //    //    }
            //    //}
            //}

            if (Time.timeScale == 0.0f)
            {
                guiShow = false;
            }
        }
        else
        {
            guiShow = false; //ei t�ll� hetkell� tee mit��n?
        }
    }
    void OnGUI() //heitt�� tota "object not set to an instance" v�lill�, mist� johtuu?
    {
        //if (hit.collider.tag == "door")
        //{
        //    if (guiShow == true && hit.collider.transform.parent.GetComponent<RayCastDoor>().isOpen == false)
        //    {
        //        if (hit.collider.GetComponent<Animation>().isPlaying == false && hit.collider.transform.parent.GetComponent<RayCastDoor>().isLocked == false) // t�ll� estet��n, ettei UI-boksi n�y koko ajan ja muutu lennosta "open" ja "close" v�lill�
        //        {
        //            GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 100, 25), "Open");
        //            //Debug.Log("Available to open door");
        //        }
        //        else if (hit.collider.GetComponent<Animation>().isPlaying == false)
        //        {
        //            //GUI.skin.box.normal.textColor = Color.red; �L� K�YT�! muuttaa pysyv�sti muidenkin v�rit.
        //            GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 100, 25), "Locked");
        //        }
        //    }

        //    else if (guiShow == true && hit.collider.transform.parent.GetComponent<RayCastDoor>().isOpen == true)
        //    {
        //        if (hit.collider.GetComponent<Animation>().isPlaying == false)
        //        {
        //            GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 100, 25), "Close");
        //            //Debug.Log("Available to close door");
        //        }
        //    }
        //}

        if (hit.collider.tag == "button")
        {
            if (guiShow == true && hit.collider.GetComponent<RayCastDoorRemote>().isOpen == false)
            {
                GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 100, 25), "Open (F)");
                Debug.Log("Available to open door");
            }

            else if (guiShow == true && hit.collider.GetComponent<RayCastDoorRemote>().isOpen == true)
            {

                GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 100, 25), "Close (F)");
                //Debug.Log("Available to close door");
            }
        }

        if(hit.collider.tag == "panel")
        {
            if (guiShow == true && hit.collider.GetComponent<RayCastSimpleSwitch>().isToggled == true && hit.collider.GetComponent<RayCastSimpleSwitch>().isUsable == true)
            {                
                GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 120, 25), "Turn off alarm (F)");
                Debug.Log("Available to turn off alarm");
            }
        }

        if (hit.collider.tag == "interactable")
        {
            if (guiShow == true)
            {
                GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 120, 25), "Use (F)");
                Debug.Log("Available to  interact with object");
            }
        }

        if (hit.collider.tag == "interactableOnce" && !interacted)
        {
            if (guiShow == true)
            {
                GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 120, 25), "Use (F)");
                Debug.Log("Available to interact with object");
            }
        }


        //if (hit.collider.tag == "interaction")
        //{
        //    if (guiShow == true && hit.collider.transform.GetComponent<RayCastInteract>().usedOnce == false) //Huomioi boolean-tarkistus
        //    {
        //        GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 100, 25), "Use");
        //    }
        //}

        //if (hit.collider.tag == "generator")
        //{
        //    if (guiShow == true && hit.collider.GetComponent<GeneratorManager>().isInteractable == true)
        //    {
        //        GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 100, 25), "Turn on");
        //    }
        //}

        //if (hit.collider.tag == "key")
        //{
        //    if (guiShow == true /*&& hit.collider.GetComponent<GeneratorManager>().isInteractable == true*/)
        //    {
        //        GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 100, 25), "Pick up");
        //    }
        //}

        //if (hit.collider.tag == "cardoor")
        //{
        //    if (guiShow == true)
        //    {
        //        GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 100, 25), "Pick up");
        //    }
        //}
    }
}
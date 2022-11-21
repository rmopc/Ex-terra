using System.Collections;
using UnityEngine;
/*
K‰yt‰ t‰t‰ ensisijassa sellaiseen objektiin, jossa Animator-komponentti.
T‰m‰ skripti liitet‰‰n siihen objektiin, josta halutaan avata ovi. GameObject door:iin m‰‰ritell‰‰n inspectorissa se kohde, mik‰ avataan
Remote-script, eli nappiin/vipuun menee TƒMƒ script, ja inspectorista m‰‰r‰t‰‰n se kohde, mik‰ avataan
Huom secondButton, eli jos on tarve saada useasta napista kontrolloida samaa ovea. 
*/

public class RayCastDoorRemote : MonoBehaviour
{

    public bool isOpen = false;
    public bool isLocked = false;
    public AudioClip buttonClick;
    public AudioClip doorOpen;
    public AudioClip doorClose;
    public AudioClip doorLocked;
    public GameObject door;
    public GameObject secondButton; //mik‰li on kaksi erillist‰ nappia ovelle

    private AudioSource audioSourceDoor; // ovesta kuuluva ‰‰ni
    private AudioSource audioSourceButton; //oven avaamisnapista kuuluva ‰‰ni
    private Animator dooranim;


    void Start()
    {
        audioSourceDoor = door.GetComponent<AudioSource>();
        audioSourceButton = GetComponent<AudioSource>();
        dooranim = door.GetComponent<Animator>();
    }


    public void OpenDoor()
    {
        isOpen = !isOpen;
        if (isOpen)
        {
            audioSourceDoor.PlayOneShot(doorOpen, 0.25f);
            audioSourceButton.PlayOneShot(buttonClick, 0.25f);
            dooranim.SetBool("open", true);
            isOpen = true;
            secondButton.GetComponent<RayCastDoorRemote>().isOpen = true;

            //koita saada t‰‰ toimimaan!
            //if (door.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("opened"))
            //{
            //    audioSourceDoor.Stop();
            //}
        }
        else
        {
            audioSourceDoor.PlayOneShot(doorClose, 0.25f);
            audioSourceButton.PlayOneShot(buttonClick, 0.25f);
            dooranim.SetBool("open", false);
            isOpen = false;
            secondButton.GetComponent<RayCastDoorRemote>().isOpen = false;
        }
    }
}
/* 
TODO!
-GUI osalta koodia siistitt‰v‰ reilusti
-Lukko‰‰ni/toiminto lis‰tt‰v‰ (kts! normi door-scripti!)
-Selvitett‰v‰ tarvitseeko sulkemistoimintoa ja/tai onko se inspectorista valittava toiminto (helppo m‰‰ritt‰‰ booleanilla :P )
*/
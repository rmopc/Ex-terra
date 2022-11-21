using System.Collections;
using UnityEngine;
// Tämä skripti liitetään siihen objektiin, josta halutaan aktivoida asia tai toiminto.
// Skriptin tarkoitus on käsitellä objekteja, jotka aktivoidaan vain kerran.
public class PanelController : MonoBehaviour
{
    [HideInInspector]
    public bool isInteractable = true;
    private bool panelIsUsable = true;

    public GameObject player;
    public Camera panelCamera;
    public GameObject objectToUnlock;
    public GameObject buttons;
    public bool usingPanel = false;
    public bool usedOnce = false;


    void Start()
    {
        buttons.SetActive(false);
        panelCamera.enabled = false;
    }

    void Update()
    {
        if (usedOnce == false && objectToUnlock.GetComponent<DoorLockController>().isLocked == false)
        {
            panelCamera.enabled = false;
            usingPanel = false;            
            player.SetActive(true);
            usedOnce = true;
            PanelDisable();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if (usingPanel == true && Input.GetKeyDown(KeyCode.E))
        {
            panelCamera.enabled = false;
            usingPanel = false;            
            player.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void Interact()
    {
        if (isInteractable)
        {
            PanelInteraction();
            if (usedOnce == true)
            {
                isInteractable = false;
            }
        }
    }

    public void PanelInteraction()
    {

        if (panelIsUsable == true && objectToUnlock.GetComponent<DoorLockController>().isLocked == true) // HUOM! Script ei toimi jos ovea ei ole lukittu inspectorissa tai muulla tavoin!
        {
            buttons.SetActive(true);
            panelCamera.enabled = true;            
            usingPanel = true;
            player.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void PanelDisable() //otetaan paneli pois käytöstä oikean koodin asettamisen jälkeen
    {
        panelIsUsable = false;
        buttons.SetActive(false);
    }
}
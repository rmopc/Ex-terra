using ECM.Components;
using ECM.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuClickListener : MonoBehaviour
{
    private CharacterMovement playerControls;
    public GameObject menu;
    public GameObject player;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!menu.activeSelf)
            {
                openMenu();
            }
            else
            {
                closeMenu();
            }            
        }
    }

    public void openMenu()
    {
        menu.SetActive(true);
        player.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }

    public void closeMenu()
    {
        menu.SetActive(false);
        player.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }
}

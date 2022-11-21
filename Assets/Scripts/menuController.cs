using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuController : MonoBehaviour
{
    public GameObject player;

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit requested");
    }

    public void ResumeGame()
    {
        player.SetActive(true);
        gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }
}

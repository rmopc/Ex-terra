using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class mainMenuController : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip clickedClip;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void NewGame()
    {
        audioSource.PlayOneShot(clickedClip);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);        
    }

    public void LoadGame()
    {
        audioSource.PlayOneShot(clickedClip);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Quit()
    {        
        Application.Quit();
    }
}

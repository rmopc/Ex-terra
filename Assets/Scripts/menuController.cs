using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        Time.timeScale = 1f;
        StartCoroutine(ResumeTimer());
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
    }

    IEnumerator ResumeTimer()
    {
        yield return new WaitForSeconds(0.50F);
        player.SetActive(true);
        gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}

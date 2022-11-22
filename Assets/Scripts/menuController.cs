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
        Time.timeScale = 1f;
        StartCoroutine(ResumeTimer());
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

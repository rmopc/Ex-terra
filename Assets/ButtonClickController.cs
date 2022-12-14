using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickController : MonoBehaviour
{

	public static string correctCode = "0016";
	public static string playerCode = "";
	public static int totalDigits = 0;
	public bool unlocked = false;

	public GameObject objectToUnlock;
	public AudioSource audioSource;
	public AudioClip clickSound;
	public AudioClip wrongCodeSound;


	void Update()
	{
		if (totalDigits == 4)
		{
			if (playerCode == correctCode)
			{
				Debug.Log("Code is Correct!");				
				objectToUnlock.GetComponent<DoorLockController>().isLocked = false;
				playerCode = "";
				totalDigits = 0;
				unlocked = true;
			}

			else
			{
				Debug.Log("Wrong code entered");
				audioSource.PlayOneShot(wrongCodeSound, 0.25f);
				playerCode = "";
				totalDigits = 0;
			}
		}
	}

	void OnMouseDown()
	{
		audioSource.PlayOneShot(clickSound, 0.25f);
		//Debug.Log("clicked button: " + gameObject.name);
		playerCode += gameObject.name;
		totalDigits += 1;
	}
}
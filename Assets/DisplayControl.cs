using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayControl : MonoBehaviour
{

	public TextMeshProUGUI text;

	void Start()
	{
		
	}

	void Update()
	{
		text.text = ButtonClickController.playerCode;
	}
}
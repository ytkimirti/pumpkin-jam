using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueObject : MonoBehaviour
{
	public string dialogueOnInteracted;

	void Start()
	{

	}

	void Update()
	{

	}

	public void ShowMesage()
	{
		print($"Show dialogue: {dialogueOnInteracted}");
	}
}

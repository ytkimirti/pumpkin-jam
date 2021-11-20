using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueObject : Interactable
{
	public string dialogueOnInteracted;

	void Start()
	{

	}

	void Update()
	{

	}

	public override void OnInteract()
	{
		print($"Show dialogue: {dialogueOnInteracted}");
	}
}

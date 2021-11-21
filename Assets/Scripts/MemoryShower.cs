using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryShower : MonoBehaviour
{
	public Image memoryImage;

	void Start()
	{

	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && !Dialogue.main.isDialogging)
		{
			gameObject.SetActive(false);

		}
	}

	public void ShowMemory(Sprite sprite)
	{
		gameObject.SetActive(true);
		memoryImage.sprite = sprite;
	}
}

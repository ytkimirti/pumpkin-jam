using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Door : MonoBehaviour
{
	// [Required]
	public int color;
	public bool isLocked;

	[Header("Refs")]

	public Door connectedDoor;
	public Room myRoom;

	[Space]
	public SpriteRenderer keyRenderer;
	public SpriteRenderer doorRenderer;


	private void Awake()
	{
		FindParent();

	}

	void Start()
	{

	}

	void Update()
	{
		UpdateDoors();
	}

	public void OnInteract()
	{
		// TODO: Add sound
	}

	void UpdateDoors()
	{
		keyRenderer.gameObject.SetActive(isLocked);

		Color col = GameManager.main.keyColors[color];

		keyRenderer.color = col;
		doorRenderer.color = col;

		if (connectedDoor)
		{
			connectedDoor.color = color;
			connectedDoor.connectedDoor = this;
			connectedDoor.isLocked = isLocked;
		}
	}

	public Vector2 FindTargetPosition()
	{
		return transform.position + (transform.up * -0.5f);
	}

	public void FindParent()
	{
		try
		{
			myRoom = transform.parent.parent.GetComponent<Room>();
		}
		catch
		{

		}
	}

	public void DrawGizmo()
	{
		FindParent();

		if (connectedDoor.connectedDoor != this)
			Gizmos.color = Color.red;
		else
			Gizmos.color = Color.green;

		Gizmos.DrawWireSphere(transform.position, 0.3f);

		if (connectedDoor)
		{
			Gizmos.DrawLine(transform.position, connectedDoor.transform.position);
		}

		//Room stuff
		Gizmos.color = Color.grey;

		if (myRoom)
			Gizmos.DrawLine(transform.position, myRoom.transform.position);
	}
}

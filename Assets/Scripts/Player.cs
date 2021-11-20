using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Player : MonoBehaviour
{
	public Room currRoom;

	[Header("In Game Stats")]
	public int[] currKeys;

	[Header("References")]
	public Transform debugEye;
	public LayerMask interactableLayerMask;

	public Entity entity;

	public static Player main;

	Interactable currInteractable;

	private void Awake()
	{
		main = this;
	}

	void Start()
	{

	}

	void Update()
	{
		entity.currInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

		debugEye.transform.localPosition = entity.currDir * 0.3f;

		currInteractable = findNearestInteractable();

		if (Input.GetKeyDown(KeyCode.Space))
		{
			// Attempting to go throught the door

			if (currInteractable)
			{
				if (currInteractable.gameObject.tag == "Door")
				{
					Door door = currInteractable.GetComponent<Door>();

					if (!door.isLocked || (door.isLocked && currKeys.Contains(door.color)))
					{
						// I can open this door
						GoThroughDoor(door);
					}
					else
					{
						// I can't open this door
					}

				}
			}
		}
	}

	Interactable findNearestInteractable()
	{
		Collider2D col = Physics2D.OverlapCircle(transform.position, 0.6f, interactableLayerMask);

		if (col)
		{
			Interactable interactable = col.gameObject.GetComponent<Interactable>();

			return interactable;
		}

		return null;
	}

	public void GoThroughDoor(Door door)
	{
		Door otherDoor = door.connectedDoor;

		ChangeRooms(otherDoor.myRoom, otherDoor.FindTargetPosition());
	}

	void ChangeRooms(Room newRoom, Vector2 newPos)
	{
		currRoom = newRoom;

		transform.position = newPos;

		CameraController.main.OnChangeRoom(newRoom);
	}
}

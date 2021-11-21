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
	public Transform interactableLabel;

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

		if (GameManager.main.gameStopped)
			entity.currInput = Vector2.zero;

		debugEye.transform.localPosition = entity.currDir * 0.3f;

		currInteractable = findNearestInteractable();

		interactableLabel.gameObject.SetActive(currInteractable);
		if (currInteractable)
		{
			// Interactable hint thing
			interactableLabel.transform.position = currInteractable.transform.position;

			// Trying to lock or unlock it
			if (Input.GetKeyDown(KeyCode.Q))
			{
				currInteractable.OnInteract();

				if (currInteractable.gameObject.tag == "Door")
				{
					Door door = currInteractable.GetComponent<Door>();

					if (currKeys.Contains(door.color))
					{
						// Toogle lock
						door.isLocked = !door.isLocked;
						if (door.connectedDoor)
							door.connectedDoor.isLocked = door.isLocked;
					}

				}

			}

			if (Input.GetKeyDown(KeyCode.E))
			{
				// Attempting to go throught the door


				currInteractable.OnInteract();


				if (currInteractable.gameObject.tag == "Door")
				{
					Door door = currInteractable.GetComponent<Door>();

					if (!door.isLocked)
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

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			GameManager.main.Die();
		}
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

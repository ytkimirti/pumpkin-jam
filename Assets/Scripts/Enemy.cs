using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public Room currRoom;
	public Door targetDoor;
	public float nearestDistance;

	[Header("References")]
	public Transform sprite;
	public Entity entity;

	void Start()
	{

	}

	void Update()
	{
		sprite.gameObject.SetActive(currRoom == Player.main.currRoom);

		entity.currInput = Vector2.zero;

		if (targetDoor && targetDoor.myRoom != currRoom)
		{
			Debug.LogError("Im not on the same room as the target door");
		}

		if (!targetDoor && currRoom == Player.main.currRoom)
		{
			// We are in the same room as player. Catch him

			Vector2 dir = (Player.main.transform.position - transform.position);

			entity.currInput = dir.normalized;

			// Collision dedection happens on player side.
		}
		else if (!targetDoor || targetDoor.isLocked)
		{
			// If you don't have a target, then find one
			targetDoor = FindDoorPlayerIsIn();
		}

		if (targetDoor && !targetDoor.isLocked)
		{
			Vector2 dir = (targetDoor.transform.position - transform.position);

			entity.currInput = dir.normalized;

			// Distance to the door
			if (dir.magnitude < nearestDistance)
			{
				GoThroughDoor(targetDoor);
			}
		}

		if (entity.currInput.x > 0)
		{
			sprite.localScale = new Vector3(-1, 1, 1);
		}
		else if (entity.currInput.x < 0)
		{
			sprite.localScale = new Vector3(1, 1, 1);
		}
	}

	public Door FindDoorPlayerIsIn()
	{
		print("finding door");
		foreach (Door d in currRoom.doors)
		{
			if (!d.isLocked && d.connectedDoor.myRoom == Player.main.currRoom)
			{
				// Player is behind this door!
				return d;
			}
		}
		return null;
	}

	public void GoThroughDoor(Door door)
	{
		Door otherDoor = door.connectedDoor;

		transform.position = otherDoor.FindTargetPosition();

		currRoom = otherDoor.myRoom;
		targetDoor = null;
	}
}

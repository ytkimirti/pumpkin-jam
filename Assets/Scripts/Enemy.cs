using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public Room currRoom;
	public Door targetDoor;
	public float nearestDistance;

	[Header("References")]
	public Transform debugEye;
	public Entity entity;

	void Start()
	{

	}

	void Update()
	{
		debugEye.transform.localPosition = entity.currDir * 0.3f;


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
		else if (!targetDoor)
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
	}

	public Door FindDoorPlayerIsIn()
	{
		foreach (Door d in currRoom.doors)
		{
			if (d.connectedDoor.myRoom == Player.main.currRoom)
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

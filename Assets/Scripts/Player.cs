using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public Room currRoom;

	[Header("References")]
	public Transform debugEye;

	public Entity entity;

	void Start()
	{

	}

	void Update()
	{
		entity.currInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

		debugEye.transform.localPosition = entity.currDir * 0.3f;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		print(other.transform.name);
		if (other.gameObject.tag == "Door")
		{
			Door door = other.gameObject.GetComponent<Door>();

			ChangeRooms(door.myRoom, door.FindTargetPosition());
		}
	}

	void ChangeRooms(Room newRoom, Vector2 newPos)
	{
		currRoom = newRoom;
	}
}

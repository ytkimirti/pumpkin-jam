using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Door : MonoBehaviour
{
	// [Required]
	public Door connectedDoor;
	public Room myRoom;


	void Start()
	{

	}

	void Update()
	{

	}

	public Vector2 FindTargetPosition()
	{
		return connectedDoor.transform.position + (connectedDoor.transform.up * -0.5f);
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

		if (!connectedDoor)
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

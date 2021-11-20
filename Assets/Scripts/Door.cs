using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Door : MonoBehaviour
{
	[Required]
	public Door connectedDoor;


	void Start()
	{

	}

	void Update()
	{

	}

	public void DrawGizmo()
	{
		if (!connectedDoor)
			Gizmos.color = Color.red;
		else
			Gizmos.color = Color.green;

		Gizmos.DrawWireSphere(transform.position, 0.3f);

		if (connectedDoor)
		{
			Gizmos.DrawLine(transform.position, connectedDoor.transform.position);
		}
	}
}

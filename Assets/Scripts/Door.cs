using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Door : Interactable
{
	// [Required]
	public int color;
	public bool isLocked;

	[Header("Refs")]
	public Door connectedDoor;
	public Room myRoom;

	[Space]
	public SpriteRenderer keyRenderer;


	private void Awake()
	{
		FindParent();
	}

	void Start()
	{

	}

	void Update()
	{
		keyRenderer.gameObject.SetActive(isLocked);

		keyRenderer.color = GameManager.main.keyColors[color];
	}

	public override void OnInteract()
	{
		print($"is locked: {isLocked} name: {gameObject.name} ");
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

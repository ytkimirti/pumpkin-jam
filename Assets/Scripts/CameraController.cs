using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public float lerpSpeed;
	public SpriteRenderer darkBG;
	Room lastRoom;

	public static CameraController main;

	private void Awake()
	{
		main = this;
	}

	void Start()
	{

	}

	void Update()
	{
		Vector2 targetPos = Player.main.transform.position;

		if (Player.main.currRoom)
			targetPos = Player.main.currRoom.transform.position;

		transform.position = Vector2.Lerp(transform.position, targetPos, Time.deltaTime * lerpSpeed);
	}

	public void OnChangeRoom(Room newRoom)
	{
		if (lastRoom)
			lastRoom.sortingGroup.sortingOrder = 0;

		print(newRoom);
		newRoom.sortingGroup.sortingOrder = 2;
		lastRoom = newRoom;
	}
}

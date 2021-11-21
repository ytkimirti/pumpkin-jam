using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public float lerpSpeed;
	public float defaultZoom = 5;
	public float zoomLerpSpeed;
	public float zoomExtraOffset;
	public SpriteRenderer darkBG;
	public Room lastRoom;

	public static CameraController main;
	public Camera cam;

	private void Awake()
	{
		main = this;
	}

	void Start()
	{
		cam = Camera.main;
	}

	void LateUpdate()
	{
		Vector2 targetPos = Player.main.transform.position;

		if (Player.main.currRoom)
			targetPos = Player.main.currRoom.transform.position;

		transform.position = Vector2.Lerp(transform.position, targetPos, Time.deltaTime * lerpSpeed);

		// Zooming
		float targetZoom = defaultZoom;

		if (Player.main.currRoom)
		{
			float newHeight = Player.main.currRoom.roomSize.x / cam.aspect;
			float height = Player.main.currRoom.roomSize.y;
			targetZoom = Mathf.Max(newHeight, height) + zoomExtraOffset;
		}

		cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime * zoomLerpSpeed);
	}

	public void OnChangeRoom(Room newRoom)
	{
		if (lastRoom)
			lastRoom.sortingGroup.sortingOrder = 0;

		newRoom.sortingGroup.sortingOrder = 2;
		lastRoom = newRoom;
	}
}

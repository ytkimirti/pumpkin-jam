using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Room : MonoBehaviour
{
	public Vector2 roomSize;
	public float colliderOffset;
	public float colliderThickness;

	[Header("Refs")]
	public Transform doorsHolder;
	public Door[] doors;

	[Space]

	public Transform colU;
	public Transform colD;
	public Transform colR;
	public Transform colL;

	private void Awake()
	{
		UpdateColliders();

	}

	void Start()
	{

	}

	void Update()
	{
	}

	private void OnDrawGizmos()
	{
		doors = doorsHolder.GetComponentsInChildren<Door>();

		foreach (Door d in doors)
		{
			d.DrawGizmo();
		}
	}

	private void OnHierarchyChange()
	{

		UpdateColliders();
	}

	void UpdateColliders()
	{
		Vector2 size = roomSize + (Vector2)(colliderOffset * Vector3.one);

		//Set the scales
		colU.localScale = new Vector3(size.x + colliderThickness, colliderThickness, 1);
		colD.localScale = new Vector3(size.x + colliderThickness, colliderThickness, 1);
		colR.localScale = new Vector3(colliderThickness, size.y + colliderThickness, 1);
		colL.localScale = new Vector3(colliderThickness, size.y + colliderThickness, 1);

		colR.transform.localPosition = Vector3.right * size.x;
		colL.transform.localPosition = Vector3.left * size.x;
		colU.transform.localPosition = Vector3.up * size.y;
		colD.transform.localPosition = Vector3.down * size.y;
	}
}

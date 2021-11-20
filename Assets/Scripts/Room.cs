using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using NaughtyAttributes;

public class Room : MonoBehaviour
{
	public Vector2 roomSize;
	public float colliderOffset;
	public float colliderThickness;

	[Header("Refs")]
	public SortingGroup sortingGroup;
	public SpriteRenderer bgSprite;
	public Transform doorsHolder;
	public Door[] doors;

	[Space]

	public Transform colU;
	public Transform colD;
	public Transform colR;
	public Transform colL;

	private void Awake()
	{
		UpdateEverything();
	}

	void Start()
	{

	}

	void Update()
	{
	}

	public void UpdateEverything()
	{
		UpdateColliders();
		bgSprite.size = roomSize * 2;
	}

	private void OnDrawGizmos()
	{
		UpdateEverything();
		doors = doorsHolder.GetComponentsInChildren<Door>();

		foreach (Door d in doors)
		{
			d.DrawGizmo();
		}
	}

	private void OnHierarchyChange()
	{
		UpdateEverything();
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

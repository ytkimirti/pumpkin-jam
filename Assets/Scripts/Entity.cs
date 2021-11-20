using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Entity : MonoBehaviour
{
	// Where he is looking
	public Vector2 currDir;
	public Vector2 currInput;

	[Header("Specs")]
	public float moveSpeed;
	public float movementSmoothing;
	Vector2 smoothVel;

	public Rigidbody2D rb;

	void Start()
	{

	}

	void Update()
	{
		Movement();
	}

	void Movement()
	{
		Vector2 targetVel = currInput * moveSpeed;

		if (currInput.magnitude > 0)
			currDir = currInput.normalized;


		rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVel, ref smoothVel, movementSmoothing);
	}
}

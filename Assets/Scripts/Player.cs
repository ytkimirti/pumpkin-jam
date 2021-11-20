using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
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
}

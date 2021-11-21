using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public bool isGameWon;
	public bool isGameOver;
	public Color[] keyColors;
	public PadLock padLock;
	public bool gameStopped;
	public GameObject memoryShower;

	public static GameManager main;

	private void Awake()
	{
		main = this;
	}

	void Start()
	{

	}

	void Update()
	{
		if (padLock.foundPassword)
			GameWon();

		gameStopped = padLock.gameObject.activeInHierarchy || memoryShower.activeInHierarchy;
	}

	public void GameWon()
	{
		if (isGameOver)
			return;

		isGameWon = true;
		isGameOver = true;
		Fader.main.FadeIn();
	}
}

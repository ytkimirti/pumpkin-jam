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
	[Space]

	public Room hallRoom;
	public bool firstInteractionHappened = false;
	public GameObject superlinNormal;
	public GameObject superlinNormalSprite;
	public GameObject superlinBad;
	public ParticleSystem explodePart;
	bool shakeSupelin = false;
	public float shakeSpeed;
	public string playerName = "Emir";

	public static GameManager main;

	private void Awake()
	{
		main = this;
	}

	void Start()
	{
		// Invoke("StartExplode", 2f);
	}

	void Update()
	{
		if (padLock.foundPassword)
			GameWon();

		gameStopped = padLock.gameObject.activeInHierarchy || memoryShower.activeInHierarchy;

		if (!firstInteractionHappened && Player.main.currRoom == hallRoom)
		{
			firstInteractionHappened = true;
			superlinNormal.SetActive(true);
			Dialogue.main.PlayDialogue("supelin");
		}

		if (shakeSupelin)
		{
			superlinNormalSprite.transform.localPosition = Vector2.right * Mathf.Sin(Time.time * shakeSpeed) * 0.08f;
		}
	}

	public void StartExplode()
	{
		shakeSupelin = true;
		Invoke("Explode", 5f);
	}

	public void Explode()
	{
		explodePart.Play();
		superlinNormal.SetActive(false);
		superlinBad.SetActive(true);
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

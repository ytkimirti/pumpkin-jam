using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public bool isGameWon;
	public bool isGameOver;
	public Color[] keyColors;
	public PadLock padLock;
	public bool gameStopped;
	public GameObject memoryShower;
	[Space]
	public AudioClip randomMusic;
	public AudioClip chaseMusic;
	public AudioClip dreamMusic;
	public AudioSource source;
	public GameObject blackObject;

	public Room hallRoom;
	public bool firstInteractionHappened = false;
	public GameObject superlinNormal;
	public GameObject superlinNormalSprite;
	public GameObject superlinBad;
	public ParticleSystem explodePart;
	bool shakeSupelin = false;
	public float shakeSpeed;
	public string playerName = "Emir";
	public GameObject jumpscareObj;
	public Enemy enemy;

	public static GameManager main;

	private void Awake()
	{
		main = this;
	}

	void Start()
	{
		playerName = FindObjectOfType<NewGameManager>().nameStr;
		// Invoke("StartExplode", 2f);
		blackObject.SetActive(true);
		Dialogue.main.PlayDialogue("dream");
		source.clip = dreamMusic;
	}

	public void OnEvent()
	{
		if (blackObject.activeInHierarchy)
		{
			blackObject.SetActive(false);
			Invoke("AfterWait", 2f);
		}
		else
		{
			StartExplode();
		}
	}

	public void AfterWait()
	{
		Dialogue.main.PlayDialogue("wakeup");
	}

	public void Die()
	{
		if (isGameOver)
			return;

		jumpscareObj.SetActive(true);
		isGameWon = false;
		isGameOver = true;
		Fader.main.FadeIn();
		Invoke("Restart", 1);
	}

	public void Restart()
	{
		SceneManager.LoadScene(1, LoadSceneMode.Single);
	}

	void Update()
	{
		if (!source.isPlaying)
			source.Play();
		if (enemy.currRoom == Player.main.currRoom)
		{
			if (source.clip != chaseMusic)
			{
				source.clip = chaseMusic;
			}
		}
		else if (!blackObject.activeInHierarchy)
		{
			if (source.clip != randomMusic)
			{
				source.clip = randomMusic;
			}
		}

		if (padLock.foundPassword)
			GameWon();

		gameStopped = padLock.gameObject.activeInHierarchy || memoryShower.activeInHierarchy || Dialogue.main.isDialogging || isGameOver;

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

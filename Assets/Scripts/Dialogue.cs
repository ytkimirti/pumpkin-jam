using System.Collections;
using UnityEngine;
using TMPro;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine.UI;
using System.Linq;
using EZCameraShake;

public class Dialogue : MonoBehaviour
{
	public bool isDialogging;
	public TextMeshProUGUI text;
	public string[] sentences;
	public float textSpeed;

	private int sentenceIndex;
	[Space]
	public TextMeshProUGUI textA;
	public TextMeshProUGUI textB;
	public Image imageA;
	public Image imageB;
	[Space]
	public Dialogues dialoguesSO;
	public Transform dialogueHolder;
	[Space]
	public char currTalkingKey;
	public string currTalkingName;
	public string currTalkingSentence;
	public Sprite currTalkingSprite;
	float defHolderY;

	public static Dialogue main;

	private void Awake()
	{
		main = this;
	}

	private void Start()
	{
		defHolderY = dialogueHolder.localPosition.y;
		text.text = string.Empty;
		isDialogging = false;
		sentenceIndex = 0;
		// PlayDialogue("intro");
	}

	public void ShowSingleSentence(string sentence)
	{
		if (isDialogging)
			return;

		sentenceIndex = 0;
		sentences = new string[1];
		sentences[0] = sentence;
		StartDialogue(0);
	}

	public void PlayDialogue(string name)
	{
		if (isDialogging)
			return;
		Dialog currDialog = null;

		foreach (Dialog d in dialoguesSO.dialogues)
		{
			if (d.name == name)
			{
				currDialog = d;
			}
		}

		if (currDialog == null)
			Debug.LogError($"No dialog with name {name}");

		sentences = currDialog.sentences;
		StartDialogue(0);
	}

	void UpdateProfiles()
	{
		if (currTalkingKey == 'A')
		{
			imageA.gameObject.SetActive(true);
			imageB.gameObject.SetActive(false);
			textA.text = currTalkingName;
			imageA.sprite = currTalkingSprite;

		}
		else
		{
			imageA.gameObject.SetActive(false);
			imageB.gameObject.SetActive(true);
			textB.text = currTalkingName;
			imageB.enabled = currTalkingSprite != null;
			imageB.sprite = currTalkingSprite;
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && isDialogging)
		{
			if (text.text == currTalkingSentence) NextSentence();
			else
			{
				StopAllCoroutines();

				text.text = "";

				text.text = currTalkingSentence;
			}
		}
	}
	public void StartDialogue(int startIndex)
	{
		text.text = "";
		currTalkingSentence = "";
		dialogueHolder.DOLocalMoveY(0, 0.6f);
		sentenceIndex = startIndex;
		isDialogging = true;
		dialogueHolder.gameObject.SetActive(true);
		StartCoroutine(StartSentence());
	}

	private IEnumerator StartSentence()
	{
		print("next sentence!");
		currTalkingSentence = sentences[sentenceIndex];
		char firstChar = currTalkingSentence[0];
		print($"First char {firstChar}");

		foreach (DialogueCharacter c in dialoguesSO.characterKeys)
		{
			if (c.key == firstChar)
			{
				currTalkingKey = c.key;
				currTalkingName = c.name;
				currTalkingSprite = c.sprite;
				break;
			}
		}

		UpdateProfiles();

		currTalkingSentence = "";

		for (int i = 3; i < sentences[sentenceIndex].Length; i++)
		{
			char c = sentences[sentenceIndex][i];
			if (c == '$')
			{
				continue;
			}
			else if (c == '|')
			{
				continue;
			}
			else if (c == '&')
			{
				continue;
			}
			currTalkingSentence = currTalkingSentence + sentences[sentenceIndex][i];
		}

		for (int i = 3; i < sentences[sentenceIndex].Length; i++)
		{
			char c = sentences[sentenceIndex][i];
			if (c == '$')
			{
				text.text += GameManager.main.playerName;
				continue;
			}
			else if (c == '|')
			{
				print("Shaked");
				CameraShaker.Instance.ShakeOnce(5, 10, 0, 1);
				continue;
			}
			else if (c == '&')
			{
				print("Exploding");
				GameManager.main.OnEvent();
				continue;
			}
			text.text += sentences[sentenceIndex][i];
			yield return new WaitForSeconds(textSpeed);
		}
	}
	private void NextSentence()
	{
		if (sentenceIndex != sentences.Length - 1)
		{
			sentenceIndex++;
			text.text = string.Empty;

			UpdateProfiles();
			StartCoroutine(StartSentence());
		}
		else
		{
			// dialogueHolder.gameObject.SetActive(false);
			dialogueHolder.DOLocalMoveY(defHolderY, 0.6f);

			isDialogging = false;
		}
	}
}

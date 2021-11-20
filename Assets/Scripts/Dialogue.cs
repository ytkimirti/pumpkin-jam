using System.Collections;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI text;
    public string[] sentences;
    public float textSpeed;

    private int sentenceIndex;
    private bool isDialogging;
    private void Start()
    {
        text.text = string.Empty;
        isDialogging = false;
        sentenceIndex = 0;
        StartDialogue(0);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isDialogging)
        {
            if (text.text == sentences[sentenceIndex]) NextSentence();
            else
            {
                StopAllCoroutines();
                text.text = sentences[sentenceIndex];
            }
        }
    }
    private void StartDialogue(int dialogueIndex)
    {
        sentenceIndex = 0;
        isDialogging = true;
        gameObject.SetActive(true);
        StartCoroutine(StartSentence());
    }
    private IEnumerator StartSentence()
    {
        foreach(char word in sentences[sentenceIndex].ToCharArray())
        {
            text.text += word;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    private void NextSentence()
    {
        if (sentenceIndex < sentences.Length - 1)
        {
            sentenceIndex++;
            text.text = string.Empty;
            StartCoroutine(StartSentence());
        }
        else
        {
            gameObject.SetActive(false);
            isDialogging = false;
        }
    }
}

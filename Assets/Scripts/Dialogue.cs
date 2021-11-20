using System.Collections;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI text;
    public string[] sentences;
    public float textSpeed;

    private int sentenceIndex;
    private void Start()
    {
        text.text = string.Empty;
        sentenceIndex = 0;
        //StartDialogue();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (text.text == sentences[sentenceIndex]) NextSentence();
            else
            {
                StopAllCoroutines();
                text.text = sentences[sentenceIndex];
            }
        }
    }
    private void StartDialogue()
    {
        sentenceIndex = 0;
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
        else gameObject.SetActive(false);
    }
}

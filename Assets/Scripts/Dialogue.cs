using System.Collections;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI text;
    public string[] sentences;
    public GameObject[] images;
    public float textSpeed;
    //UI Canvas
    public GameObject Canvas;

    private int sentenceIndex;
    private int sentenceEndIndex;
    private bool isDialogging;
    private void Awake()
    {
        DontDestroyOnLoad(Canvas.transform.gameObject);
    }
    private void Start()
    {
        text.text = string.Empty;
        isDialogging = false;
        sentenceIndex = 0;
        sentenceEndIndex = 5;
        images[0].SetActive(true);
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
    public void StartDialogue(int startIndex)
    {
        sentenceIndex = startIndex;
        isDialogging = true;
        gameObject.SetActive(true);
        StartCoroutine(StartSentence());
    }
    public void EndIndexPicker(int endIndex)
    {
        sentenceEndIndex = endIndex;
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
        if (sentenceIndex!=sentenceEndIndex)
        {
            sentenceIndex++;
            text.text = string.Empty;
            images[sentenceIndex - 1].SetActive(false);
            images[sentenceIndex].SetActive(true);
            StartCoroutine(StartSentence());
        }
        else
        {
            gameObject.SetActive(false);
            isDialogging = false;
        }
    }
}

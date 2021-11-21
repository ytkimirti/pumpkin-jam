using UnityEngine;
using TMPro;

public class PadLock : MonoBehaviour
{
    public int password;
    public TextMeshProUGUI text;
    public GameObject infoText;
    public bool foundPassword;

    private int passwordLenght;
    private void Start()
    {
        passwordLenght = 0;
        foundPassword = false;
    }
    public void AddingNumber(int number)
    {
        if (passwordLenght < 4)
        {
            infoText.SetActive(false);
            if (passwordLenght == 0) text.text = string.Empty;
            text.text += number;
            passwordLenght++;
        }
    }
    public void DeleteNumber()
    {
        if (passwordLenght > 0)
        {
            infoText.SetActive(false);
            char[] passwordArray = text.text.ToCharArray();
            text.text = string.Empty;
            for (int i = 0; i < passwordArray.Length - 1; i++) text.text += passwordArray[i];
            passwordLenght--;
            if (passwordLenght == 0) text.text = "Password";
        }
    }
    public void DoneGuessing()
    {
        if (text.text == password.ToString())
        {
            foundPassword = true;
            gameObject.SetActive(false);
        }
        else
        {
            foundPassword = false;
            gameObject.SetActive(true);
            infoText.SetActive(true);
        }
    }
    public void GoBack()
    {
        gameObject.SetActive(false);
    }
}

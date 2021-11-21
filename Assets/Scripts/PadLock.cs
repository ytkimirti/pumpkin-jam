using UnityEngine;
using TMPro;

public class PadLock : MonoBehaviour
{
	public string password;
	public TextMeshProUGUI text;
	public GameObject infoText;
	public bool foundPassword;
	public bool isFirstInteraction = true;

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
	public void DoorDialogue()
	{
		if (!isFirstInteraction)
			return;
		isFirstInteraction = false;
		Dialogue.main.PlayDialogue("door_interact");
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
		if (text.text == password)
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

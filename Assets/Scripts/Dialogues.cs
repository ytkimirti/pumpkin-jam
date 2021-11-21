using UnityEngine;
using NaughtyAttributes;

[System.Serializable]
public class Dialog
{
	public string name;
	[TextArea]
	public string[] sentences;
}

[System.Serializable]
public class DialogueCharacter
{
	public char key;
	public string name;
	public Sprite sprite;
}

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Dialogues", order = 1)]
public class Dialogues : ScriptableObject
{
	public DialogueCharacter[] characterKeys;
	public Dialog[] dialogues;
}
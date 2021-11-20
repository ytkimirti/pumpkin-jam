
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
	// private bool rangeCheck;

	public UnityEvent Interact;

	// private void Start()
	// {
	//     rangeCheck = false;
	// }

	public void OnInteract()
	{
		Interact.Invoke();
	}

	// private void Update()
	// {
	//     if (rangeCheck)
	//     {
	//         if (Input.GetKeyDown(KeyCode.E)) Interact.Invoke();
	//     }
	// }
	// private void OnTriggerEnter2D(Collider2D collision)
	// {
	//     if (collision.gameObject.tag == "Player") rangeCheck = true;
	//     else rangeCheck = false;
	// }
	// private void OnTriggerExit2D(Collider2D collision)
	// {
	//     rangeCheck = false;
	// }
}

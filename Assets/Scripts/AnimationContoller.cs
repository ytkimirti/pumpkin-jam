using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationContoller : MonoBehaviour
{
	//public Vector2 playerDirection;
	public Animator playerAnim;
	void Update()
	{
		/*if (playerDirection.x == 1) playerAnim.Play("mc_sag_yurume");
        else if (playerDirection.x == -1) playerAnim.Play("mc_sol_yurume");
        else if (playerDirection.y == 1) playerAnim.Play("mc_arka_yurume");
        else if (playerDirection.x == -1) playerAnim.Play("mc_duz_yurume");*/

		if (GameManager.main.gameStopped)
		{
			playerAnim.Play("Default");
			return;
		}

		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) playerAnim.Play("mc_arka_yurume");
		else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) playerAnim.Play("mc_duz_yurume");
		else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) playerAnim.Play("mc_sol_yurume");
		else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) playerAnim.Play("mc_sag_yurume");
		else playerAnim.Play("Default");
	}
}

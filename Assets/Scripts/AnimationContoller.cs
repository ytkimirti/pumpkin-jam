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

        if (Input.GetKey(KeyCode.W)) playerAnim.Play("mc_arka_yurume");
        else if (Input.GetKey(KeyCode.S)) playerAnim.Play("mc_duz_yurume");
        else if (Input.GetKey(KeyCode.A)) playerAnim.Play("mc_sol_yurume");
        else if (Input.GetKey(KeyCode.D)) playerAnim.Play("mc_sag_yurume");
        else playerAnim.Play("Default");
    }
}

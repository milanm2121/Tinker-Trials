using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class multi_player_animation : MonoBehaviour
{
    //legs and movement
    public Animator characterAnimator;//Add the animator 
                                      // public bool grounded;//
    public bool jumping;//
    public bool running;//
    public bool sprinting;//
    //directional;
    public Vector2 directionalmovement;//
    //wepon stuff
    public bool Aim;
    public bool reloading;
    public float reloading_percent;
    public bool shooting;//
    public float ForwardAmount = 0;//
    public float m_CurrentForward = 0;//
    //melee
    public bool melee;

    //

    //
    public multi_Player_Movement PM;
    public multi_wepon_body_game WBG;
    public multi_lethal_thrower LT;
    //public int IsRunning;

    public Rig rightarm;
    public Rig leftarm;
    /*
   READ ME AT REMI: below is all of the old code that i have put into a regon commented off NOT Deleted if you want to resume the code talk to me first 

 //  i pit a "-" in between your "*-/"

   --Milan
   */

    private void Start()
    {
        characterAnimator.SetFloat("reload speed", 1 / WBG.reload_time);
    }


    private void Update()
    {
        if (PM.RB != null)
        {
            characterAnimator.SetBool("grounded", PM.grounded);
            characterAnimator.SetBool("running", PM.running);
            characterAnimator.SetBool("walking", PM.walking);
            characterAnimator.SetFloat("X-direction", directionalmovement.x);
            characterAnimator.SetFloat("Y-direction", directionalmovement.y);
            characterAnimator.SetBool("reloading", WBG.reloading);
            characterAnimator.SetBool("aim", Aim);
            characterAnimator.SetFloat("speed", PM.RB.velocity.magnitude / 3);
            characterAnimator.SetBool("melee", melee);
            characterAnimator.SetBool("throw lethal", LT.throwing_lethal);

            if (melee == true)
            {
                rightarm.weight = 0;
            }
            else
            {
                rightarm.weight = 1;
            }

            if (WBG.reloading == true)
            {
                leftarm.weight = 0;
                rightarm.weight = 0;
            }
            else
            {
                leftarm.weight = 1;
                rightarm.weight = 1;
            }

        }
    }
}

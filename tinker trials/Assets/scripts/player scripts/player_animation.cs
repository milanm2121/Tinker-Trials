using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_animation : MonoBehaviour
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
    public bool melee_percent;
    //
    public bool throwing_leathal;
    //
    public player_Movement PM;
    public wepon_body_game WBG;
    public int IsRunning;

    public Quaternion spinerotation;

    public Transform spine;
    /*
   READ ME AT REMI: below is all of the old code that i have put into a regon commented off NOT Deleted if you want to resume the code talk to me first 

 //  i pit a "-" in between your "*-/"

   --Milan
   */

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
        }
    }
    private void LateUpdate()
    {
        spine.transform.rotation *= spinerotation;
    }

    #region oldcode    
    /*
    READ ME AT REMI: below is all of the old code that i have put into a regon commented off NOT Deleted if you want to resume the code talk to me first 
    
  //  i pit a "-" in between your "*-/"

    --Milan
    */

    //start of comment- milan
    /*

    // Start is called before the first frame update
    void Start()
    {
        ForwardAmount = 2;
        m_CurrentForward = 1;
        //Animator.SetBool(IsRunning, cha.Run.Active && GetIsMoving());
        IsRunning = Animator.StringToHash("IsRunning");
       // Animator.SetBool(IsRunning, .Run.Active && GetIsMoving());
        // characterAnimator = GetComponent<Animator>();// make sure the animator is active 


        /-*
         protected virtual void InputRun()
	{

		if (vp_Input.GetButton("Run")
			  || vp_Input.GetAxisRaw("LeftTrigger") > 0.5f		// sprint using the left gamepad trigger
			)
			FPPlayer.Run.TryStart();
		else
			FPPlayer.Run.TryStop();

	}


         *-/
         

    }

    // Update is called once per frame
    void Update()
    {
        grounded = PM.grounded;
        Buttontest();

        if (directionalmovement.magnitude > 1)
        {

            characterAnimator.SetBool("IsRunning", true);
            
        }

        if (directionalmovement.magnitude == 0)
        {
            characterAnimator.SetBool("IsRunning", false);

        }

    }

    
     public void Buttontest ()
     {
        if (Input.GetKey(KeyCode.E)) 
        {
            characterAnimator.Play("Move", 2);
            //characterAnimator.Play("Crouch", 1, 40);
             // characterAnimator.Play("Run", 1,  40);// works kind of 
             // characterAnimator.SetBool("IsRunning",true);                                     // characterAnimator.Play("Jump", 1, 20);
             // characterAnimator.Play("Walk", 1, 20);
             // characterAnimator.Play("Run", 2, 1);// playing running test, moves left sholder 
            //Debug.Log("Button Pushed ");


        }

        

     }
    public void moving()
    {

        if (directionalmovement.x == 1)
        {

        }

        if (directionalmovement.y == 1)
        {
            Debug.Log("moving");
        }



        //characterAnimator.SetFloat
        //characterAnimator.Play("Run", 1, 40);// works kind of 
        //characterAnimator.SetBool("IsRunning", true);
        // m_CurrentForward = +1;
        //Debug.Log(m_CurrentForward);
        //if (m_CurrentForward == 10)
        {
            //characterAnimator.SetBool("IsRunning", false);
        }
       // ForwardAmount = Animator.StringToHash("Forward");
        //Animator.SetFloat(ForwardAmount, m_CurrentForward);


    }

    /-*
       //Inputs for Animation from OG import 
    // floats
		ForwardAmount = Animator.StringToHash("Forward");
		PitchAmount = Animator.StringToHash("Pitch");
		StrafeAmount = Animator.StringToHash("Strafe");
		TurnAmount = Animator.StringToHash("Turn");
		VerticalMoveAmount = Animator.StringToHash("VerticalMove");

		// booleans
		IsAttacking = Animator.StringToHash("IsAttacking");
		IsClimbing = Animator.StringToHash("IsClimbing");
		IsCrouching = Animator.StringToHash("IsCrouching");
		IsGrounded = Animator.StringToHash("IsGrounded");
		IsMoving = Animator.StringToHash("IsMoving");
		IsOutOfControl = Animator.StringToHash("IsOutOfControl");
		IsReloading = Animator.StringToHash("IsReloading");
		IsRunning = Animator.StringToHash("IsRunning");
		IsSettingWeapon = Animator.StringToHash("IsSettingWeapon");
		IsZooming = Animator.StringToHash("IsZooming");
		IsFirstPerson = Animator.StringToHash("IsFirstPerson");

		// triggers
		StartClimb = Animator.StringToHash("StartClimb");
		StartOutOfControl = Animator.StringToHash("StartOutOfControl");
		StartReload = Animator.StringToHash("StartReload");

		// enum indices
		WeaponGripIndex = Animator.StringToHash("WeaponGrip");
		WeaponTypeIndex = Animator.StringToHash("WeaponType");


    // --- booleans used to transition between blend states ---
		// TODO: these should be moved to event callbacks on the next optimization run

		Animator.SetBool(IsRunning, Player.Run.Active && GetIsMoving());
		Animator.SetBool(IsCrouching, Player.Crouch.Active);
		Animator.SetInteger(WeaponTypeIndex, Player.CurrentWeaponType.Get());
		Animator.SetInteger(WeaponGripIndex, Player.CurrentWeaponGrip.Get());
		Animator.SetBool(IsSettingWeapon, Player.SetWeapon.Active);
		Animator.SetBool(IsReloading, Player.Reload.Active);
		Animator.SetBool(IsOutOfControl, Player.OutOfControl.Active);
		Animator.SetBool(IsClimbing, Player.Climb.Active);
		Animator.SetBool(IsZooming, Player.Zoom.Active);
		Animator.SetBool(IsGrounded, m_Grounded);
		Animator.SetBool(IsMoving, GetIsMoving());
		Animator.SetBool(IsFirstPerson, Player.IsFirstPerson.Get());

		// --- floats used inside blend states to blend between animations ---

		Animator.SetFloat(TurnAmount, m_CurrentTurn);
		Animator.SetFloat(ForwardAmount, m_CurrentForward);
		Animator.SetFloat(StrafeAmount, m_CurrentStrafe);
		Animator.SetFloat(PitchAmount, (-Player.Rotation.Get().x) / 90.0f);

		if (m_Grounded)
			Animator.SetFloat(VerticalMoveAmount, 0.0f);
		else
		{
			if (Player.Velocity.Get().y < 0.0f)
				Animator.SetFloat(VerticalMoveAmount, Mathf.Lerp(Animator.GetFloat(VerticalMoveAmount), -1.0f, Time.deltaTime * 3));
			else
				Animator.SetFloat(VerticalMoveAmount, Player.MotorThrottle.Get().y * 10.0f);
		}

    *-/

    end of comment-milan
   */
    #endregion
}

/*
by:Milan Manji
script descrition: this script is used for player cammera movement and player rotaion it has controler funtionality.


*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_Camera : MonoBehaviour
{
    GameObject perant;//the player gameobject(player modele)

    //math stuff
    public float mouseX;
    public float mouseY;
    //used to store the next frames vector
    Vector2 mouseposition;

    //used to effect the sensitivitys of horizontal and vertical input
    public float sensitivityX;
    public float senstivivtyY;

    // a bool used to unlock the mouse and mak it visable when the game is playing
    public bool camera_Pause;

    //the camera it self
    Camera cam;

    float defaltFOV;

    public player_ID P_ID;

    public load_scean LS;

    public GameObject head;

    public player_animation animator;

    
    // Start is called before the first frame update
    void Start()
    {
        perant = transform.parent.gameObject;

        //locks the mouse on start
        Cursor.lockState = CursorLockMode.Locked;
        camera_Pause = false;

        cam = GetComponent<Camera>();

        defaltFOV = cam.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {

        GetComponentInParent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);

        if (P_ID.is_player == true)
        {

            //clamps the player sensitivity
            Mathf.Clamp(sensitivityX, 1, 10);
            Mathf.Clamp(senstivivtyY, 1, 10);

            /*this if statement is used to cheak for the type ofinput initolised at the start of gameplay
             *and effects what input is read
             *the else statement is currently unused but could be inplamented on later
             */
            if (camera_Pause == false)
            {
                if (controler_input_Setup_script.contorllerType == 0)
                {
                    mouseX = Input.GetAxisRaw("Mouse X") * sensitivityX;
                    mouseY = Input.GetAxisRaw("Mouse Y") * senstivivtyY;
                }
                else
                {
                    mouseX = controler_input_manager.Right_Stick.x * sensitivityX;
                    mouseY = controler_input_manager.Right_Stick.y * senstivivtyY;
                }
            }


            //the math of storing the players next rotation in the mouse position value

            mouseposition = mouseposition + new Vector2(mouseX, mouseY);
            mouseposition.y = Mathf.Clamp(mouseposition.y, -90, 90);

            //the x axsis changes the player
            perant.transform.rotation = Quaternion.AngleAxis(mouseposition.x, Vector3.up);


            if (animator == null)
            {
                //while the y axis changes the camera(head)
                transform.localRotation = Quaternion.AngleAxis(-mouseposition.y, Vector3.right);
            }
            else
            {
                int spinalAdgustment=1;
                if (0>-mouseposition.y)
                {
                    spinalAdgustment = -1;
                }
                else
                {
                    spinalAdgustment = 1;
                }
                animator.spinerotation = Quaternion.AngleAxis(-mouseposition.y,new Vector3(1,0.5f *spinalAdgustment,0));
                transform.position = head.transform.position +new Vector3(0,0.2f,0);
                transform.localRotation = Quaternion.AngleAxis(-mouseposition.y, Vector3.right);

            }

        }

        //used to unlock the mouse in a pause like state
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            camera_Pause = true;
        }

        if(camera_Pause==true && Input.GetKeyDown(KeyCode.R))
        {
            LS.loadScean("main menu");
        }

        //used to relock the mouse to effect the game
        if (Input.GetMouseButton(0) && Input.mousePresent == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            camera_Pause = false;
        }
    }

    //added for shooting recoil in game
    public void Flinch_Recoil(Vector2 recoil)
    {

        mouseposition += recoil;
    }

    public void ADSZoom(float zoom)
    {
        float x = defaltFOV * (1f-(zoom/10));
        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView -= 20f * Time.deltaTime, x, defaltFOV);
        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, x, defaltFOV);
        
    }
    
}

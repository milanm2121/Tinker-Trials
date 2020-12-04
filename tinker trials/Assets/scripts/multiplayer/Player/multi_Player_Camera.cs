using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multi_Player_Camera : MonoBehaviour,IPunObservable
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

    public PhotonView perant_PV;

    bool initalised=false;

    public load_scean LS;

    public GameObject head;

    public multi_player_animation animator;

    bool stun;
    float stuntime;

    public GameObject wepon;



    // Start is called before the first frame update
    public void initalise_cam()
    {
        Canvas[] canvas=GameObject.FindObjectsOfType<Canvas>();
        Camera[] camlist= new Camera[Camera.allCamerasCount];
        Camera.GetAllCameras(camlist);
        for (int i = 0; camlist.Length > i; i++) {

            if (camlist[i].GetComponent<multi_Player_Camera>().perant_PV.IsMine == true)
            {
                camlist[i].enabled = true;
                camlist[i].gameObject.transform.parent.transform.SetAsFirstSibling();
            }
            else
            {
                camlist[i].enabled = false;
            }

            if (canvas[i].transform.parent.name != "helm")
            {
                print(canvas[i].transform.parent.name);
                if (canvas[i].gameObject.transform.parent.GetComponent<PhotonView>().IsMine)
                {
                    canvas[i].gameObject.SetActive(true);
                }
                else
                {
                    canvas[i].gameObject.SetActive(false);
                }
            }
        }


        perant = transform.parent.gameObject;

        //locks the mouse on start
        Cursor.lockState = CursorLockMode.Locked;
        camera_Pause = false;

        cam = GetComponent<Camera>();

        defaltFOV = cam.fieldOfView;
        initalised = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (initalised)
        {
            GetComponentInParent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);

            if (perant_PV.IsMine == true)
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


                if (stun == true)
                {
                    mouseposition = mouseposition + new Vector2(mouseX, mouseY).normalized;
                }
                else
                {
                    mouseposition = mouseposition + new Vector2(mouseX, mouseY);
                }
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
                    int spinalAdgustment = 1;
                    if (0 > -mouseposition.y)
                    {
                        spinalAdgustment = -1;
                    }
                    else
                    {
                        spinalAdgustment = 1;
                    }
                    transform.position = head.transform.position;
                    transform.localRotation = Quaternion.AngleAxis(-mouseposition.y, Vector3.right);

                }
            }

            //used to unlock the mouse in a pause like state
            if (Input.GetKey(KeyCode.Escape))
            {
                Cursor.lockState = CursorLockMode.None;
                camera_Pause = true;
            }

            if (camera_Pause == true && Input.GetKeyDown(KeyCode.R))
            {
                if (GameObject.Find("multiplayer_game_maneger"))
                    GameObject.Find("multiplayer_game_maneger").GetComponent<multiplayer_game_maneger>().LeaveLobby();

            }

            //used to relock the mouse to effect the game
            if (Input.GetMouseButton(0) && Input.mousePresent == true)
            {
                Cursor.lockState = CursorLockMode.Locked;
                camera_Pause = false;
            }
            if (stuntime > 0)
            {
                stun = true;
                stuntime -= Time.deltaTime;
            }
            else
            {
                stun = false;
                stuntime = 0;
            }
        }
    }

    //added for shooting recoil in game
    public void Flinch_Recoil(Vector2 recoil)
    {

        mouseposition += recoil;
        wepon.transform.Rotate(new Vector3(0, 0, 1), -recoil.magnitude);

    }

    public void ADSZoom(float zoom)
    {
        float x = defaltFOV * (1f-(zoom/10));
        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView -= 20f * Time.deltaTime, x, defaltFOV);
        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, x, defaltFOV);
        
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
  
            stream.SendNext(transform.rotation.eulerAngles);
        }
        else if (stream.IsReading)
        {
            transform.rotation = Quaternion.Euler((Vector3)stream.ReceiveNext());
        }


    }
}
﻿/*
by:Milan Manji
script descrition: moves the player based off the player rotation and uses unitys rigid body physics to prevent cliping
this script is used to allow for player to move with velosity and added vectors which allows movement to be smooth
and slide if needed
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_Movement : MonoBehaviour
{
    //stores the final movement vector
    Vector3 direction;

    //the storage of movement on the players x axsis
    Vector3 directionX;
    //the storage ofthe players movement on the Y axis
    Vector3 directionY;

    //used to store the calculated vectors of direction based of the players rotated offset
    Vector3 forward;
    Vector3 back;
    Vector3 left;
    Vector3 right;

    //for the AI to interact with the movement script
    bool AIForward;
    bool AIBack;
    bool AILeft;
    bool AIRight;

    //used to calculate if the player want to keep its mometum
    public bool keep_Momentum;

    //not sure what this is
    Vector3 diection_Delay;

    //used for casting a raycast to calculate mantaling small walls upt to the players chest for climing fast
    public Transform player_feet;
    public Transform playerChest;

    // the rigitbody
    public Rigidbody RB;

    //the speed of the player
    public float speed;

    public float initalSpeed;

    //used to set the jump hight
    public int jump_Hight;
    // used to activate or disable multijump
    public bool multi_Jump;
    //uf multijump is active how many time can you jump in the air
    public int max_Jump_Limit;
    //used to store your extra jumps from multi jumping
    int extra_Jumps;

    // used to see if the player is grounded
    public bool grounded;
    // Start is called before the first frame update

    public player_animation PA;


    public player_stats PS;

    Vector3 SwingOffset;
    bool swinging=false;
    GameObject node;

    public player_ID P_ID;

    public player_sounds Sounds;
    public bool running;
    public bool walking;
    public float inital_running_multiplyer;
    private float running_multiplyer;


    public bool low_gravity = false;


    public bool leftground=false;
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        extra_Jumps = max_Jump_Limit;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (RB != null)
        {
            if(RB.velocity.magnitude>30)
            RB.velocity -= RB.velocity*0.01f;

            if (low_gravity == true)
            {
                RB.AddForce(new Vector3(0, 5f, 0));
            }

            if (Input.GetKey(KeyInputs.KP.run) && P_ID.is_player)
            {
                running = true;
                running_multiplyer = inital_running_multiplyer;
                walking = false;
            }
            else
            {
                running = false;
                running_multiplyer = 0;
                if (RB.velocity != Vector3.zero)
                {
                    walking = true;
                }
                else
                {
                    walking = false;
                }
            }

            if (RB.velocity != Vector3.zero && grounded == true)
            {
                if (running == true)
                {
                    Sounds.running = true;
                    Sounds.walking = false;

                }
                else
                {
                    Sounds.walking = true;
                    Sounds.running = false;

                }
            }

            //keyboard

            //sets all the vecters to 0 for the input calculation
            forward = Vector3.zero;
            back = Vector3.zero;
            left = Vector3.zero;
            right = Vector3.zero;


            //used to calculate the directional vector based off the rotaional offetof the player
            if ((P_ID.is_player == true && Input.GetKey(KeyInputs.KP.left)) || AILeft == true)
            {
                left = new Vector3((-transform.right).normalized.x * speed * 100, RB.velocity.y, (-transform.right).normalized.z * speed * 100);
            }
            if ((P_ID.is_player == true && Input.GetKey(KeyInputs.KP.right)) || AIRight == true)
            {
                right = new Vector3((transform.right).normalized.x * speed * 100, RB.velocity.y, (transform.right).normalized.z * speed * 100);
            }

            if ((P_ID.is_player == true && Input.GetKey(KeyInputs.KP.backwards)) || AIBack == true)
            {
                back = new Vector3((-transform.forward).normalized.x * speed * 100, RB.velocity.y, (-transform.forward).normalized.z * speed * 100);
            }
            if ((P_ID.is_player == true && Input.GetKey(KeyInputs.KP.forward)) || AIForward == true)
            {

                forward = new Vector3((transform.forward).normalized.x * speed * 100, RB.velocity.y, (transform.forward).normalized.z * speed * 100);
                // if (PA != null)
                //     PA.moving();//Rem

            }


            //momentum
            //this calculation is used only if the keep mometum bool it ticked,
            //this calculation is used to allow the player to influence the directional velosity based of the previous freames velosity
            if (P_ID.is_player == true &&  (Input.GetKey(KeyInputs.KP.left) && Input.GetKey(KeyInputs.KP.right)))
            {
                left = Vector3.zero;
                right = Vector3.zero;
                directionX = Vector3.zero;
            }


            if (P_ID.is_player == true &&  (Input.GetKey(KeyInputs.KP.backwards) && Input.GetKey(KeyInputs.KP.forward)))
            {
                forward = Vector3.zero;
                back = Vector3.zero;
                directionY = Vector3.zero;
            }


            if (P_ID.is_player == true && keep_Momentum == true && (Input.GetKey(KeyInputs.KP.left) || Input.GetKey(KeyInputs.KP.right) || Input.GetKey(KeyInputs.KP.forward) || Input.GetKey(KeyInputs.KP.backwards)))
            {
                direction = Vector3.zero;
                direction = (directionX + directionY) * Time.deltaTime;
                RB.velocity = new Vector3(direction.x, RB.velocity.y, direction.z) + new Vector3(direction.x, 0, direction.z) * running_multiplyer;
            }
            else
            {
                direction = Vector3.zero;
                directionY = Vector3.zero;
                directionX = Vector3.zero;
            }
            //no momentum
            // this is used to calculate the next velosity of the rigit body and overwright it
            if (keep_Momentum == false )
            {
                direction = (forward + back + left + right) * Time.deltaTime;
                
                RB.velocity = new Vector3(direction.x, RB.velocity.y, direction.z) + (new Vector3(direction.x, 0, direction.z) * running_multiplyer);


            }

            //controler
            /*  {
                  if (keep_Momentum == false)
                  {
                      directionX = new Vector3((transform.right).normalized.x * speed, RB.velocity.y, (transform.right).normalized.z * speed) * controler_input_manager.Left_Stick.x;
                      directionY = new Vector3((transform.forward).normalized.x * speed, RB.velocity.y, (transform.forward).normalized.z * speed) * controler_input_manager.Left_Stick.y;
                      direction = directionX + directionY;
                      RB.velocity = new Vector3(direction.x, RB.velocity.y, direction.z);
                  }

                  if (keep_Momentum == true)
                  {
                      directionX = new Vector3((transform.right).normalized.x * speed, RB.velocity.y, (transform.right).normalized.z * speed) * controler_input_manager.Left_Stick.x;
                      directionY = new Vector3((transform.forward).normalized.x * speed, RB.velocity.y, (transform.forward).normalized.z * speed) * controler_input_manager.Left_Stick.y;
                      if (((directionX.x + directionY.x) < RB.velocity.x && (directionX.x + directionY.x) > 0) || ((directionX.x + directionY.x) > RB.velocity.x && (directionX.x + directionY.x) < 0) || ((directionX.y + directionY.y) < RB.velocity.y && (directionX.y + directionY.y) > 0) || ((directionX.y + directionY.y) > RB.velocity.y && (directionX.y + directionY.y) < 0))
                      {
                          print("keep_Momentum");
                      }
                      else
                      {
                          direction = directionX + directionY;
                          RB.velocity = new Vector3(direction.x, RB.velocity.y, direction.z);
                      }
                  }
           */
       // }
            if (PA != null)
            {
                PA.directionalmovement = new Vector2(direction.x, direction.x);
            }


            //jumping
            // this cheack to see if the player is grounded because the player shoud be able to jump if on the ground
            if (grounded == true)
            {
                if ((P_ID.is_player == true && Input.GetKeyDown(KeyInputs.KP.jump) || controler_input_manager.Bottom_Button))
                {
                    if (PA != null)
                        PA.jumping = true;
                    RB.velocity = new Vector3(RB.velocity.x, jump_Hight, RB.velocity.z);
                    grounded = false;
                }
            }
            //allows the player to jump if it has multijump and spare jums left
            if (multi_Jump == true && extra_Jumps > 0 && grounded == false && (P_ID.is_player == true && (Input.GetKeyDown(KeyInputs.KP.jump) || controler_input_manager.Bottom_Button)))
            {
                RB.velocity = new Vector3(RB.velocity.x, jump_Hight, RB.velocity.z);
                extra_Jumps = extra_Jumps - 1;
            }

            //swinging
            if (swinging == true && Input.GetKey(KeyInputs.KP.jump))
            {

                node.GetComponent<Rigidbody>().velocity = RB.velocity / 2;
                transform.position = node.transform.position - SwingOffset;
                print("swinging");
            }
            else if (!Input.GetKey(KeyInputs.KP.jump) && swinging == true)
            {
                RB.velocity = node.GetComponent<Rigidbody>().velocity;
                swinging = false;

            }

            AIBack = false;
            AIForward = false;
            AILeft = false;
            AIRight = false;
        }
        if (leftground == true && grounded == true)
        {
            Collider[] col =Physics.OverlapSphere(player_feet.position, 0.2f);
            bool hitground=false;
            for (int i = 0; col.Length > i; i++)
            {
                if (col[i].tag == "ground")
                {
                    hitground = true;
                    
                }
            }
            if (hitground == false)
            {
                grounded = false;
                Sounds.grounded = false;
                print("left ground");
            }
            
        }
        if (grounded == false)
        {
            Collider[] col = Physics.OverlapSphere(player_feet.position, 0.2f);
            for (int i = 0; col.Length > i; i++)
            {
                if (col[i].tag == "ground")
                {
                    grounded = true;
                    extra_Jumps = max_Jump_Limit;
                    keep_Momentum = false;
                    leftground = false;
                }
            }
        }

    }
    
    // used to set the player to be grounded and reset the max jump limit if there is acollioin with a object that it taged gound
    private void OnCollisionEnter(Collision col)
    {
    /*    if (col.gameObject.tag == "ground")
        {
            grounded = true;
            extra_Jumps = max_Jump_Limit;
            keep_Momentum = false;
            leftground = false;
        }
    */
        if (col.gameObject.tag == "rope")
        {
            node = col.gameObject;
            SwingOffset = node.transform.position - transform.position;
            swinging = true;
            if(RB)
                node.GetComponent<Rigidbody>().velocity = RB.velocity;
        }
    }

    // used to calculate the players matale potential, can it mantal?
    // players can mantale anything that is below there chest hight
    private void OnCollisionStay(Collision collision)
    {
        RaycastHit raychest;
        Physics.Raycast(playerChest.position, direction, out raychest, 1f);
        RaycastHit rayfeet;
        Physics.Raycast(player_feet.position, direction, out rayfeet, 1);

        if (rayfeet.collider != null && raychest.collider == null)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y + 5, transform.position.z), Time.deltaTime);
            print("manteling");
        }

        
    }

    //provents juming if you ar not touching the ground
    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "ground")
        {
            leftground = true;
            
  //          keep_Momentum = true;
        }
    }

    //not sure what this is its unsed from my undersanding
    void mometum()
    {
        diection_Delay = direction;
        RB.velocity = diection_Delay;

    }

    public void AI_left()
    {
        AILeft = true;
    }
    public void AI_right()
    {
        AIRight = true;
    }
    public void AI_back()
    {
        AIBack = true;
    }
    public void AI_forward()
    {
        AIForward = true;
    }

}

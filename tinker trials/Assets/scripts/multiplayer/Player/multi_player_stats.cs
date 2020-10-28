/*
by:Milan Manji
script descrition: stores the players data like health armour, also holds player ragdols
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class multi_player_stats : MonoBehaviourPunCallbacks
{
    //used to gateherThe layers weight and applay a movement penalty to the player speed
    public armor_game AG;
    public wepon_body_game WBG;
    public player_Movement PM;

    public Text healthtext;

    bool loaded = false;

    //used to add flinch
    public player_Camera PC;


    //universal stats
    public float health;
    public int armour;

    //the weight used to penalise player movement
    public float weight;


    //used for ragdols
    public Animator animator;
    public GameObject Skeleton;

    //for element tick effect
    public float element_tick;

    //element bools
    public float fire_meter;

    public float frost_meter;

    public float electrucity_meter;

    public float dirt_meter;
    public Image dirt1;
    public Image dirt2;
    public Image dirt3;
    public Image dirt4;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("loadstats", 1);

    }

    // Update is called once per frame
    void Update()
    {
        if (animator != null)
        {
            if (health <= 0)
            {
                animator.enabled = false;
                Skeleton.SetActive(true);
                Destroy(GetComponent<Rigidbody>());
            }
            else
            {
                animator.enabled = true;
                Skeleton.SetActive(false);
            }
        }
        else
        {
            if (health <= 0)
            {
                Destroy(gameObject, 3);
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            }
        }
        dirt();

        if (healthtext != null)
            healthtext.text = "health" + ((int)health).ToString();
    }

    private void FixedUpdate()
    {
        if (loaded == true)
        {
            element_tick += Time.deltaTime;
            while (element_tick > 1)
            {
                element_tick = -1;

                //functions go here
                if (fire_meter >= 75)
                {
                    fireDMG();
                }
                ice();

                if (electrucity_meter >= 60)
                {
                    electricity();
                }


                fire_meter = Mathf.Clamp(fire_meter - 1, 1, 110);
                frost_meter = Mathf.Clamp(frost_meter - 5, 1, 100);
                electrucity_meter = Mathf.Clamp(electrucity_meter - 5, 1, 110);

            }


        }

    }


    public void damage_player(float damage, Vector2Int element)
    {
        //damage armour calculation
        damage /= armour;
        health -= damage;
    }
    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.layer == 9)
        {
            if (col.rigidbody.velocity.magnitude > 5)
            {
                damage_player(col.rigidbody.velocity.magnitude, new Vector2Int(0, 0));
            }
        }
    }
    void fireDMG()
    {
        health -= 5;
    }
    void ice()
    {
        PM.speed = PM.initalSpeed * (1 - frost_meter / 100);
    }
    void dirt()
    {
        if (dirt_meter < 25)
        {
            Color C = dirt1.color;
            C.a = dirt_meter / 25;
            dirt1.color = C;
            dirt2.gameObject.SetActive(false);
            dirt3.gameObject.SetActive(false);
            dirt4.gameObject.SetActive(false);
        }
        else if (dirt_meter < 50)
        {
            Color C = dirt2.color;
            C.a = (dirt_meter - 25) / 25;
            dirt1.color = C;
            dirt2.gameObject.SetActive(true);
            dirt3.gameObject.SetActive(false);
            dirt4.gameObject.SetActive(false);
        }
        else if (dirt_meter < 75)
        {
            Color C = dirt3.color;
            C.a = (dirt_meter - 50) / 25;
            dirt1.color = C;
            dirt2.gameObject.SetActive(true);
            dirt3.gameObject.SetActive(true);
            dirt4.gameObject.SetActive(false);
        }
        else if (dirt_meter >= 100)
        {
            Color C = dirt4.color;
            C.a = (dirt_meter - 75) / 25;
            dirt1.color = C;
            dirt2.gameObject.SetActive(true);
            dirt3.gameObject.SetActive(true);
            dirt4.gameObject.SetActive(true);
        }
        dirt_meter = Mathf.Clamp(dirt_meter - Time.deltaTime * 30, 0, 120);
    }
    void electricity()
    {
        PC.Flinch_Recoil(new Vector2(Random.Range(-5, 5), Random.Range(-5, 5)));
    }

    [PunRPC]
    private void loadstats(int roomid)
    {
        if (photonView.IsMine == true)
        {
            PM = GetComponent<player_Movement>();

            //calculates the weight and defence at the start of a game
            armour = AG.deffence / 10;
            weight = AG.weight + WBG.weight;
            //calculating avrage speed
            PM.speed = PM.speed - (weight / 10);
            PM.initalSpeed = PM.speed;
            loaded = true;
        }
        else
        {
         //   PhotonNetwork.
        }
    }

}

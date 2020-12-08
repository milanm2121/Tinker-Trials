/*
by:Milan Manji
script descrition: stores the players data like health armour, also holds player ragdols
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_stats : MonoBehaviour
{
    //used to gateherThe layers weight and applay a movement penalty to the player speed
    public armor_game AG;
    public wepon_body_game WBG;
    public player_Movement PM;
    public lethal_thrower LT;
    public player_ID PID;

    public Text healthtext;

    bool loaded=false;

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

    public Image health_bar;

    public Collider[] ragdoll;
    public Rigidbody[] ragdoll2;

    public GameObject damage_numbers_UI_Canvas;
    public GameObject damage_numbers;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("loadstats", 1);
        foreach (Collider collider in ragdoll)
        {
            collider.enabled = false;

        }
        foreach (Rigidbody rigidbody in ragdoll2)
        {
            rigidbody.isKinematic = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (animator != null)
        {
            if (health <= 0)
            {
                animator.enabled = false;
                foreach (Collider collider in ragdoll)
                {
                    collider.enabled = true;
                    
                }
                foreach(Rigidbody rigidbody in ragdoll2)
                {
                    rigidbody.isKinematic = false;
                }
                Destroy(GetComponent<Rigidbody>());
                Destroy(gameObject, 3);
                WBG.enabled = false;
                LT.enabled = false;


            }
            else
            {
                animator.enabled = true;
                foreach (Collider collider in ragdoll)
                {
                    collider.enabled = false;
                }
                // Skeleton.SetActive(false);
            }
        }
        else
        {
            if (health <= 0)
            {
                Destroy(gameObject, 3);
                GetComponent<Rigidbody>().constraints=RigidbodyConstraints.None;
            }
        }
        if(PID.is_player==true)
            dirt();
        
        if(health_bar!=null)
            health_bar.fillAmount = health / 100;

        if (healthtext != null)
        {
            healthtext.text = "health" + ((int)health).ToString();
           
        }

        fire_meter = Mathf.Clamp(fire_meter, 1, 110);
        frost_meter = Mathf.Clamp(frost_meter, 1, 100);
        electrucity_meter = Mathf.Clamp(electrucity_meter, 1, 110);
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


    public void damage_player(float damage,Vector2Int element)
    {
        //damage armour calculation
        damage /= armour;
        health -= (int)damage;
        GameObject UI_can = Instantiate(damage_numbers_UI_Canvas, transform.position,Quaternion.identity);
        GameObject base_damage=Instantiate(damage_numbers, UI_can.transform);
        base_damage.GetComponent<damage_numbers>().damage((int)damage, 0);
        
        if (element.x == 1)
        {
            fire_meter += damage*2;
            GameObject elemental_damage = Instantiate(damage_numbers, UI_can.transform);
            elemental_damage.GetComponent<damage_numbers>().damage((int)damage*2, 1);
        }
        if (element.x == 2)
        {
            frost_meter += damage * 2;
            GameObject elemental_damage = Instantiate(damage_numbers, UI_can.transform);
            elemental_damage.GetComponent<damage_numbers>().damage((int)damage, 2);
        }
        if (element.x == 3)
        {
            dirt_meter += damage * 2;
            GameObject elemental_damage = Instantiate(damage_numbers, UI_can.transform);
            elemental_damage.GetComponent<damage_numbers>().damage((int)damage*2, 3);
        }
        if (element.x == 4)
        {
            electrucity_meter += damage * 2;
            GameObject elemental_damage = Instantiate(damage_numbers, UI_can.transform);
            elemental_damage.GetComponent<damage_numbers>().damage((int)damage*2, 4);
        }
        

        if (element.y == 1)
        {
            fire_meter += damage * 2;
            GameObject elemental_damage = Instantiate(damage_numbers, UI_can.transform);
            elemental_damage.GetComponent<damage_numbers>().damage((int)damage*2, 1);
        }
        if (element.y == 2)
        {
            frost_meter += damage * 2;
            GameObject elemental_damage = Instantiate(damage_numbers, UI_can.transform);
            elemental_damage.GetComponent<damage_numbers>().damage((int)damage*2, 2);
        }
        if (element.y == 3)
        {
            dirt_meter += damage * 2;
            GameObject elemental_damage = Instantiate(damage_numbers, UI_can.transform);
            elemental_damage.GetComponent<damage_numbers>().damage((int)damage*2, 3);
        }
        if (element.y == 4)
        {
            electrucity_meter += damage * 2;
            GameObject elemental_damage = Instantiate(damage_numbers, UI_can.transform);
            elemental_damage.GetComponent<damage_numbers>().damage((int)damage*2, 4);
        }

    }
    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.layer == 9)
        {
            if (col.rigidbody.velocity.magnitude > 5)
            {
                damage_player(col.rigidbody.velocity.magnitude,new Vector2Int(0, 0));
            }
        }
    }
    void fireDMG()
    {
        health -= 5;
    }
    void ice()
    {
        PM.speed = PM.initalSpeed* (1-frost_meter/100);
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
            C.a = (dirt_meter-25) / 25;
            dirt1.color = C;
            dirt2.gameObject.SetActive(true);
            dirt3.gameObject.SetActive(false);
            dirt4.gameObject.SetActive(false);
        }
        else if (dirt_meter < 75)
        {
            Color C = dirt3.color;
            C.a = (dirt_meter-50) / 25;
            dirt1.color = C;
            dirt2.gameObject.SetActive(true);
            dirt3.gameObject.SetActive(true);
            dirt4.gameObject.SetActive(false);
        }
        else if(dirt_meter >= 100)
        {
            Color C = dirt4.color;
            C.a = (dirt_meter-75) / 25;
            dirt1.color = C;
            dirt2.gameObject.SetActive(true);
            dirt3.gameObject.SetActive(true);
            dirt4.gameObject.SetActive(true);
        }
        dirt_meter=Mathf.Clamp(dirt_meter - Time.deltaTime * 30,0,120);
    }
    void electricity()
    {
        PC.Flinch_Recoil(new Vector2(Random.Range(-5, 5), Random.Range(-5, 5)));
    }

    private void loadstats()
    {
        PM = GetComponent<player_Movement>();

        //calculates the weight and defence at the start of a game
        armour = AG.deffence / 10;
        weight = AG.weight + WBG.weight/3;
        if (WBG.suport_script.SO.speciality == 1)
        {
            weight = AG.weight;
            PM.low_gravity = true;
        }

        //calculating avrage speed
        PM.speed = PM.speed - (weight/10);

        if (AG.L_boots_script.BO.speciality == 1)
        {
            PM.speed *= 1.5f;
        }

        PM.initalSpeed = PM.speed;
        loaded = true;

        if (AG.L_boots_script.BO.speciality == 2)
        {
            PM.multi_Jump = true;
        }
        else
        {
            PM.multi_Jump = false;
        }

        if (AG.L_boots_script.BO.speciality == 3)
        {
            WBG.melee_range *= 2;
        }


         if (AG.cheastplate_script.CPO.specicality == 1)
        {
            WBG.reserve_ammo *= 2;
        }

        if (AG.cheastplate_script.CPO.specicality == 2)
        {
            LT.sholder_launcher = true;
        }
    }

}

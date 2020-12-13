/*
by:Milan Manji
script descrition: this script important for generating the wepon in game

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class wepon_body_game : MonoBehaviour
{
    //used for hipfire and ADS positioning
    public Transform hip;
    public Transform ADS;

    public GameObject barrel;
    public wepon_barrel barrel_script;

    public GameObject scope;
    public wepon_scope scope_script;

    public GameObject grip;
    public wepon_grip grip_script;

    public GameObject amunition;
    public wepon_anumition amunition_script;

    public GameObject suport;
    public wepon_suport suport_script;

    public GameObject reciver;
    public wepon_reciver reciver_script;

    //the weight of the wepon
    public float weight;

    //the range of the wepon
    int range;

    //the recoli vecter used to apply reciol
    Vector2 recoil;

    //the velosity/direction of projectiles
    Vector3 velosity;

    //used to counteract recoil
    float XStability;
    float Ystability;

    //used to dictate firerate
    float firerrate;
    float intialfirerate;
    float firetick;

    //used as trigger for gravity gun michanic
    bool blastPrime=false;

    //a struct that each projectile holds
    public projectileREf proREF;

    public player_Movement PM;

    //the class used to summon pojectiles
    public entity_maneger EM;

    //the material and mesh of the projectile
    public Material defaltProjectileMat;
    public Mesh defaltProjectileMesh;

    //the player camera script
    public player_Camera PC;
    //the player animation refence script
    public player_animation PA;

    //used to dictate the firetype
    public enum firetype {projectile,buckshot,gravity,lazer};
    public firetype Firetype = firetype.projectile;

    //used to show a lazer
    public LineRenderer lazer;

    //used for dictating amoucount and reloading
    int ammoCount=0;
    public bool reloading=false;
    public float reload_time;
    public int reserve_ammo;
    

    public player_ID P_ID;

    public bool AI_shooting=false;

    public Text ammocount;

    float overheat_damage_multiplyer;
    public TMP_Text megerment;
    public float recoil_reduction;

    bool can_shoot=true;

    public float melee_range=0.3f;
    public Transform cam;
    public Transform rigthand;

    //shooting sounds
    public AudioClip surpressed_Fire;
    public AudioClip nerf_Fire;
    public AudioClip buckshot_Fire;
    public AudioClip lazer_Fire;

    public AudioClip gravity_start;
    public AudioClip gravity_hold;

    


    // generates the stats and wepons
    void Start()
    {
        reciver_script = reciver.GetComponent<wepon_reciver>();
        barrel_script = barrel.GetComponent<wepon_barrel>();
        scope_script = scope.GetComponent<wepon_scope>();
        amunition_script = amunition.GetComponent<wepon_anumition>();
        grip_script = grip.GetComponent<wepon_grip>();
        suport_script = suport.GetComponent<wepon_suport>();

        select_class(static_classes.Class1);

        weight += reciver_script.RO.weight;
        weight += barrel_script.BO.weight;
        weight += scope_script.SO.weight;
        weight += amunition_script.AO.weight;
        weight += grip_script.GO.weight;
        weight += suport_script.SO.weight;

        //the order is important so dont change it
        generateGunStars();
        generateProjectile();

        

        EM = GameObject.Find("entitymaniger").GetComponent<entity_maneger>();

    }

    // Update is called once per frame
    void Update()
    {
        if (ammocount != null)
            ammocount.text = ammoCount + " / " + reserve_ammo;
        velosity = -transform.right.normalized * proREF.range;

        if (P_ID.is_player == true && can_shoot==true && reloading==false)
        {
            
            if (Input.GetMouseButton(1))
            {
                transform.position = Vector3.Lerp(transform.position, ADS.position, 1 / weight);
                PC.ADSZoom(scope_script.SO.zoom);
                PA.Aim = true;
                if (scope_script.SO.speciality==1) {
                    RaycastHit col;
                    Physics.Raycast(barrel.transform.position, velosity.normalized, out col, int.MaxValue);
                    megerment.text = col.distance + "m";
                }
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, hip.position, 1 / weight);
                PC.ADSZoom(1);
                PA.Aim = false;
                megerment.text = "";

            }

        }
        if(can_shoot == true && reloading == false)
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0, 90, 0), Time.deltaTime * 2);

        //laser stuff
        if (Firetype == firetype.lazer)
        {
            lazer.gameObject.SetActive(true);
            if (lazer.startWidth > 0) {
                lazer.startWidth -= 0.02f;
                lazer.endWidth -= 0.02f;
            }
            if (lazer.startWidth < 0)
            {
                lazer.startWidth = 0;
                lazer.endWidth = 0;
            }

        }
        else
        {
            lazer.gameObject.SetActive(false);
        }
        //melee
        if (Input.GetKeyDown(KeyCode.V) &&PA.melee==false && P_ID.is_player==true)
        {
            StartCoroutine(melee());
        }
        //reload
        if (Input.GetKeyDown(KeyCode.R)&& reloading==false &&reserve_ammo>0 && P_ID.is_player == true)
        {
            StartCoroutine(reload());
        }
        
    }

    private void FixedUpdate()
    {
        // sets the firereate of the wepon
        firetick += Time.deltaTime;
        if (reloading == false)
        {
            if ((Input.GetMouseButton(0) && P_ID.is_player==true ||AI_shooting==true) && can_shoot==true &&(PM.running==false||suport_script.SO.speciality==2))
            {
                if (firetick >= firerrate && Firetype != firetype.gravity && ammoCount > 0)
                {
                    if (reciver_script.RO.spciality == 3)
                    {
                        firerrate = Mathf.Clamp(firerrate * 0.8f, 0.01f, int.MaxValue);
                    }

                    ammoCount -= 1;
                    if (PA != null)
                        PA.shooting = true;

                    if (barrel_script.BO.specalty == 2)
                    {
                        overheat_damage_multiplyer = Mathf.Clamp(overheat_damage_multiplyer * 1.1f, 1, int.MaxValue);
                    }

                    if (Firetype == firetype.projectile)
                    {
                        shoot(out recoil);
                        if (barrel_script.BO.specalty == 1)
                        {
                            Audio_Maneger.create_sound(transform.position,surpressed_Fire,0.5f);
                        }
                        else
                        {
                            Audio_Maneger.create_sound(transform.position,nerf_Fire,0.5f);

                        }
                        if(suport_script.SO.speciality == 1)
                        {
                            PM.RB.AddForce(-velosity);
                        }


                    }

                    if (Firetype == firetype.buckshot)
                    {
                        shootBuckshot();
                        if (barrel_script.BO.specalty == 1)
                        {
                            Audio_Maneger.create_sound(transform.position,surpressed_Fire,0.5f);
                        }
                        else
                        {
                            Audio_Maneger.create_sound(transform.position,buckshot_Fire,0.5f);

                        }
                        if (suport_script.SO.speciality == 1)
                        {
                            PM.RB.AddForce(-velosity);
                        }

                    }

                    if (amunition_script.AO.speciality == 2)
                    {
                       
                        if (Firetype == firetype.lazer)
                            shootLazer();
                        if (barrel_script.BO.specalty == 1)
                        {
                            Audio_Maneger.create_sound(transform.position, surpressed_Fire,0.5f);
                        }
                        else
                        {
                            Audio_Maneger.create_sound(transform.position, lazer_Fire,0.5f);

                        }
                    }

                    firetick = 0;

                    if (grip_script.GO.speciality == 2)
                    {
                        
                        PC.Flinch_Recoil(recoil/recoil_reduction);
                        recoil_reduction += 0.2f;
                    }
                    else
                    {
                        PC.Flinch_Recoil(recoil);
                    }
                }

                if (ammoCount <= 0 && reloading == false &&reserve_ammo>0)
                {
                    StartCoroutine(reload());
                }

                if (Firetype == firetype.gravity && amunition_script.AO.speciality == 2)
                {
                    vortex();
                }
            }
            else
            {
                recoil_reduction = 1;
                overheat_damage_multiplyer = 1;
                firerrate = Mathf.Clamp(firerrate * 1.2f, 0.01f, intialfirerate);

                if (Firetype == firetype.gravity && blastPrime == true)
                {
                    blastPrime = false;
                    blast();
                }
            }
        }
        
    } 

    // adds recoil penalty for shooting
    void shoot(out Vector2 Recoil)
    {
        EM.shootProjectile(transform.position,velosity , new projectileREf { blast_radious = proREF.blast_radious, damage = (int)(proREF.damage * overheat_damage_multiplyer), element = proREF.element, range = proREF.range }, transform.rotation, defaltProjectileMat, defaltProjectileMesh);
        Recoil = new Vector2(Random.Range(-1+XStability, 1-XStability), Random.Range(0, 1-Ystability)).normalized * proREF.damage/10;
    }

    void shootBuckshot()
    {
        
        for (int i = 0; 12 > i; i++)
        {
           
            Vector3 randomvelosity = velosity+ new Vector3(Random.Range(-7, 8), Random.Range(-7, 8), Random.Range(-7, 8));
            EM.shootProjectile(transform.position, randomvelosity, new projectileREf { blast_radious = proREF.blast_radious, damage = (int)(proREF.damage * overheat_damage_multiplyer), element = proREF.element, range = proREF.range }, transform.rotation, defaltProjectileMat, defaltProjectileMesh);
            recoil = new Vector2(Random.Range(-XStability, XStability), Random.Range(0, Ystability)).normalized * proREF.damage/10;
        }
        
    }

    void shootLazer()
    {
        RaycastHit col;
        Physics.Raycast(barrel.transform.position, velosity.normalized, out col, int.MaxValue);
        lazer.SetPosition(0, barrel.transform.position);
        if (col.collider != null)
        {
            lazer.SetPosition(1, col.point);
        }
        else
        {
            lazer.SetPosition(1, barrel.transform.position + (velosity.normalized * 100));
        }

            lazer.startWidth = 0.1f;
        lazer.endWidth = 0.1f;
        if (col.rigidbody != null)
        {
            if (col.collider.GetComponent<player_stats>() != null)
            {
                col.collider.GetComponent<player_stats>().damage_player(proREF.damage*overheat_damage_multiplyer, proREF.element);
            }
            else if (col.collider.gameObject.GetComponent<object_health>() != null)
            {
                col.collider.gameObject.GetComponent<object_health>().damage_object((int)(proREF.damage * overheat_damage_multiplyer));
            }
            else if (col.collider.gameObject.GetComponent<dummy_script>() != null)
            {
                col.collider.gameObject.GetComponent<dummy_script>().damage_player(proREF.damage * overheat_damage_multiplyer, proREF.element);
            }
            col.rigidbody.velocity += velosity.normalized *5* proREF.damage/10 * overheat_damage_multiplyer;
        }
    }

    void vortex()
    {
        List<Rigidbody> targets = new List<Rigidbody>();
        Collider[] col =Physics.OverlapSphere(transform.position + (-transform.right.normalized*1), barrel_script.BO.lenght);
        for(int i=0;col.Length>i; i++)
        {
            if (col[i].GetComponent<Rigidbody>() != null && col[i].gameObject.layer==9)
                targets.Add(col[i].GetComponent<Rigidbody>());
        }
        for(int i=0;targets.Count>i; i++)
        {
            Vector3 offest= ((barrel.transform.position-transform.right.normalized * 1) - targets[i].transform.position);
            targets[i].velocity = offest.normalized *(amunition_script.AO.damage*offest.magnitude);
        }
        blastPrime = true;
    }

    void blast()
    {
        List<Rigidbody> targets = new List<Rigidbody>();
        Collider[] col = Physics.OverlapSphere(transform.position + (-transform.right.normalized * 1), 10f);
        for (int i = 0; col.Length > i; i++)
        {
            if (col[i].GetComponent<Rigidbody>() != null && col[i].gameObject.layer == 9)
                targets.Add(col[i].GetComponent<Rigidbody>());
        }
        for (int i = 0; targets.Count > i; i++)
        {
            targets[i].velocity = -transform.right.normalized * amunition_script.AO.damage *10;
        }
    }


    // loads the class
    public void select_class(class_class.Class class_)
    {
        if (P_ID.is_player == true)
        {
            //load class

            barrel_script.BO = class_.Wepon.barrel;
            reciver_script.RO = class_.Wepon.reciver;
            scope_script.SO = class_.Wepon.scope;
            amunition_script.AO = class_.Wepon.amunition;
            grip_script.GO = class_.Wepon.grip;
            suport_script.SO = class_.Wepon.suport;

        }
        else
        {
            generate_wepon();
        }

        //generate wepon
        reciver_script.generateRecever();
        barrel_script.generateBarrel();
        scope_script.generateScope();
        amunition_script.generateObject();
        grip_script.generateGip();
        suport_script.generateSuport();

        //postioning wepon parts
        position_parts();

    }

    

    // posions the parts in game
    public void position_parts()
    {
        reciver.transform.localPosition = Vector3.zero;

        barrel.transform.localPosition = reciver_script.barrel_fit;

        scope.transform.localPosition = reciver_script.scope_fit;

        amunition.transform.localPosition = reciver_script.anumition_fit;

        grip.transform.localPosition = reciver_script.grip_fit;

        suport.transform.localPosition = reciver_script.suport_fit;
    }

    void generateProjectile()
    {
        proREF = new projectileREf
        {
            blast_radious = amunition_script.AO.blast_radius,
            element = new Vector2Int(amunition_script.AO.element, reciver_script.RO.element),
            range = (range)*10,
            damage = amunition_script.AO.damage*10,
       //     Mat = defaltMat,
       //     mesh = defaltMesh
        };
        
        
    }
    // sets the fire rate
    void generateGunStars()
    {
        firerrate = 1f/reciver_script.RO.fire_rate*2;
        print(firerrate);
        intialfirerate = firerrate;
        if (reciver_script.RO.spciality == 1 && amunition_script.AO.speciality==2)
        {
            Firetype = firetype.gravity;
        }
        if (reciver_script.RO.spciality == 2 && amunition_script.AO.speciality == 2)
        {
            Firetype = firetype.lazer;
        }
        if (amunition_script.AO.speciality == 1)
        {
            Firetype = firetype.buckshot;
        }
        XStability = (90f - (float)grip_script.GO.grip_angle)/10f;
      

        Ystability = (float)grip_script.GO.grip_angle/10f;

        range = amunition_script.AO.range * barrel_script.BO.lenght;
        if (Firetype == firetype.lazer && barrel_script.BO.material == 1)
            range += 5;

        if (Firetype == firetype.projectile && barrel_script.BO.material == 2)
            range += 5;

        ammoCount = amunition_script.AO.rounds;
        reserve_ammo = ammoCount * 5;

        reload_time = weight/4;

        if (amunition_script.AO.speciality == 3)
        {
            reload_time = reload_time/2;
        }
    }

    IEnumerator reload()
    {
        transform.parent = rigthand;
        reloading = true;
        yield return new WaitForSeconds(reload_time);
        int usedRounds =amunition_script.AO.rounds - ammoCount;
        
        ammoCount += Mathf.Clamp(usedRounds,0,reserve_ammo);
        reserve_ammo -= usedRounds;
        reloading = false;
        transform.parent = cam;

    }

    IEnumerator melee()
    {
        can_shoot = false;
        reloading = false;
        StopCoroutine(reload());
        PA.melee = true;

        transform.parent = rigthand;
        yield return new WaitForSeconds(0.2f);
        RaycastHit[] targets=Physics.BoxCastAll(transform.parent.position, new Vector3(1f, 1f, 1f), transform.parent.forward, transform.parent.rotation, melee_range);
        for (int i = 0; targets.Length > i; i++)
        {
            if (targets[i].collider.gameObject != PA.gameObject)
            {
                if (targets[i].rigidbody != null)
                {
                    targets[i].rigidbody.velocity += velosity/proREF.range*10;
                    if (targets[i].collider.gameObject.GetComponent<player_stats>() != null)
                    {
                        player_stats target = targets[i].collider.gameObject.GetComponent<player_stats>();
                        target.damage_player(10000, Vector2Int.zero);

                        if (grip_script.GO.speciality == 1)
                        {
                            target.PC.stun_player();
                        }
                    }
                    
                }

            }
        }
        yield return new WaitForSeconds(0.2f);
        PA.melee = false;
        can_shoot = true;
        transform.parent = cam;
    }

    private void generate_wepon()
    {
        if (true)
        {
            barrel_object x = ScriptableObject.CreateInstance<barrel_object>();


            x.lenght = Random.Range(1, 5);
            x.material = Random.Range(0, 2);
            x.specalty = Random.Range(0, 3);
            x.name = "barrel";
            x.weight = x.lenght + x.specalty;

            if (x.specalty == 0)
            {
                x.mesh = Resources.Load("AssetsFixed_Exported/Barrel/Generic_Barrel", typeof(Mesh)) as Mesh;
                x.mat = Resources.Load("AssetsFixed_Exported/Barrel/Generic_Barrel", typeof(Material)) as Material;
            }
            if (x.specalty == 1)
            {
                x.mesh = (Mesh)Resources.Load("AssetsFixed_Exported/Barrel/PaintCanSupressor_Barrel", typeof(Mesh));
                x.mat = (Material)Resources.Load("AssetsFixed_Exported/Barrel/PaintCanSupressor_Barrel", typeof(Material));
            }
            if (x.specalty == 2)
            {

                x.mesh = (Mesh)Resources.Load("AssetsFixed_Exported/Barrel/OverheatDisplay_Barrel", typeof(Mesh));
                x.mat = (Material)Resources.Load("AssetsFixed_Exported/Barrel/OverheatDisplay_Barrel", typeof(Material));
            }
            barrel_script.BO=x;
        }
        //amunition
        if (true)
        {
            amunition_object x = ScriptableObject.CreateInstance<amunition_object>();



            x.blast_radius = Random.Range(0, 5);
            x.element = Random.Range(0, 5);
            x.prjectile = 1;
            x.range = Random.Range(1, 5);
            x.rounds = Random.Range(1, 100);
            x.speciality = Random.Range(0, 4);
            x.damage = Random.Range(1, 3);

            x.name = "amunition";
            x.weight = x.blast_radius + x.range + x.rounds / 10 + x.damage / 2;

            if (x.speciality == 0 || x.speciality == 1)
            {
                x.mesh = (Mesh)Resources.Load("AssetsFixed_Exported/Ammo/GenericMag_Ammo", typeof(Mesh));
                x.mat = (Material)Resources.Load("AssetsFixed_Exported/Ammo/GenericMag_Ammo", typeof(Material));
            }
            if (x.speciality == 2)
            {
                x.mesh = (Mesh)Resources.Load("AssetsFixed_Exported/Ammo/Energy_Ammo", typeof(Mesh));
                x.mat = (Material)Resources.Load("AssetsFixed_Exported/Ammo/Energy_Ammo", typeof(Material));
            }
            if (x.speciality == 3)
            {

                x.mesh = (Mesh)Resources.Load("AssetsFixed_Exported/Ammo/FastMag_Ammo", typeof(Mesh));
                x.mat = (Material)Resources.Load("AssetsFixed_Exported/Ammo/FastMag_Ammo", typeof(Material));
            }
            amunition_script.AO = x; ;
        }

        //grips
        if (true)
        {
            grip_object x = ScriptableObject.CreateInstance<grip_object>();



            x.name = "grip";
            x.grip_angle = Random.Range(0, 90);
            x.speciality = Random.Range(0, 3);


            x.weight = 2 + x.speciality;

            if (x.speciality == 0)
            {
                x.meshshape = (Mesh)Resources.Load("AssetsFixed_Exported/Grip/Generic_Grip", typeof(Mesh));
                x.mat = (Material)Resources.Load("AssetsFixed_Exported/Grip/Generic_Grip", typeof(Material));
            }
            if (x.speciality == 1)
            {
                x.meshshape = (Mesh)Resources.Load("AssetsFixed_Exported/Grip/StunBash_Grip", typeof(Mesh));
                x.mat = (Material)Resources.Load("AssetsFixed_Exported/Grip/StunBash_Grip", typeof(Material));
            }
            if (x.speciality == 2)
            {
                x.meshshape = (Mesh)Resources.Load("AssetsFixed_Exported/Grip/AutoAdjust_Grip", typeof(Mesh));
                x.mat = (Material)Resources.Load("AssetsFixed_Exported/Grip/AutoAdjust_Grip", typeof(Material));
            }

            grip_script.GO = x;
        }
        //reciver
        if (true)
        {
            weponReciver_object x = ScriptableObject.CreateInstance<weponReciver_object>();



            x.name = "reciver";


            x.fire_rate = Random.Range(1, 5);
            x.spciality = Random.Range(1, 4);
            x.element = Random.Range(0, 5);
            x.wepon_type = 1;


            x.weight = x.fire_rate;

            x.anumition_fit = new Vector3(0.2f, -0.5f, 0);
            x.barrel_fit = new Vector3(-1.5f, 0, 0);
            x.grip_fit = new Vector3(-.7f, -0.8f, 0);
            x.scope_fit = new Vector3(0, 0.5f, 0);
            x.suport_fit = new Vector3(1.5f, -0.3f, 0);

            if (x.spciality == 0)
            {
                x.mesh = (Mesh)Resources.Load("AssetsFixed_Exported/Receiver/Generic_Receiver", typeof(Mesh));
                x.mat = (Material)Resources.Load("AssetsFixed_Exported/Receiver/Generic_Receiver", typeof(Material));
                x.anumition_fit = new Vector3(0.2f, -0.5f, 0);
                x.barrel_fit = new Vector3(-1.5f, 0, 0);
                x.grip_fit = new Vector3(-.7f, -0.8f, 0);
                x.scope_fit = new Vector3(0, 0.5f, 0);
                x.suport_fit = new Vector3(1.5f, -0.3f, 0);
            }
            if (x.spciality == 1)
            {
                x.mesh = (Mesh)Resources.Load("AssetsFixed_Exported/Receiver/Physics_Receiver", typeof(Mesh));
                x.mat = (Material)Resources.Load("AssetsFixed_Exported/Receiver/Physics_Receiver", typeof(Material));
            }
            if (x.spciality == 2)
            {
                x.mesh = (Mesh)Resources.Load("AssetsFixed_Exported/Receiver/Laser_Receiver", typeof(Mesh));
                x.mat = (Material)Resources.Load("AssetsFixed_Exported/Receiver/Laser_Receiver", typeof(Material));
            }
            if (x.spciality == 3)
            {
                x.mesh = (Mesh)Resources.Load("AssetsFixed_Exported/Receiver/Rotary_Receiver", typeof(Mesh));
                x.mat = (Material)Resources.Load("AssetsFixed_Exported/Receiver/Rotary_Receiver", typeof(Material));
            }


            reciver_script.RO = x;
        }
        //scopes
        if (true)
        {
            scope_object x = ScriptableObject.CreateInstance<scope_object>();


            x.speciality = Random.Range(0, 2);
            if (Random.Range(0, 1) == 0)
            {
                x.trhermal = false;
            }
            else
            {
                x.trhermal = true;
            }
            x.zoom = Random.Range(1, 10);



            x.name = "optic";
            x.weight = 2 + x.zoom;

            if (x.zoom < 9)
            {
                x.mesh = (Mesh)Resources.Load("AssetsFixed_Exported/Aim/Distance_Aim", typeof(Mesh));
                x.mat = (Material)Resources.Load("AssetsFixed_Exported/Aim/Distance_Aim", typeof(Material));
            }
            else if (x.zoom < 6 || x.trhermal == true)
            {
                x.mesh = (Mesh)Resources.Load("AssetsFixed_Exported/Aim/Alert_Aim", typeof(Mesh));
                x.mat = (Material)Resources.Load("AssetsFixed_Exported/Aim/Alert_Aim", typeof(Material));
            }
            else if (x.zoom < 3)
            {
                x.mesh = (Mesh)Resources.Load("AssetsFixed_Exported/Aim/Generic_Aim", typeof(Mesh));
                x.mat = (Material)Resources.Load("AssetsFixed_Exported/Aim/Generic_Aim", typeof(Material));
            }

            scope_script.SO=x;
        }

        //support/stock
        if (true)
        {
            Suport_object x = ScriptableObject.CreateInstance<Suport_object>();


            x.speciality = Random.Range(0, 3);

            x.name = "stock";
            x.weight = 2;


            if (x.speciality == 0)
            {
                x.mesh = (Mesh)Resources.Load("AssetsFixed_Exported/Stock/Generic_Stock", typeof(Mesh));
                x.mat = (Material)Resources.Load("AssetsFixed_Exported/Stock/Generic_Stock", typeof(Material));
            }
            if (x.speciality == 1)
            {
                x.mesh = (Mesh)Resources.Load("AssetsFixed_Exported/Stock/LowGravityThruster_Stock", typeof(Mesh));
                x.mat = (Material)Resources.Load("AssetsFixed_Exported/Stock/LowGravityThruster_Stock", typeof(Material));
            }
            if (x.speciality == 2)
            {
                x.mesh = (Mesh)Resources.Load("AssetsFixed_Exported/Stock/Boot_Stock", typeof(Mesh));
                x.mat = (Material)Resources.Load("AssetsFixed_Exported/Stock/Boot_Stock", typeof(Material));
            }


            suport_script.SO = x;
        }
    }
}

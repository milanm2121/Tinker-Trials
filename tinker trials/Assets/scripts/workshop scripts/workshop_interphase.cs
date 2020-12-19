/*
by:Milan Manji
script descrition: is used for the player to interact with the workshop system and save and load class data
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class workshop_interphase : MonoBehaviour
{
    //these vairables are used to cheak what calss you looking at
    public Button class1;
    public Button class2;
    public Button class3;
    public Button class4;
    public int Class_Sellected;

    // this is used to cheach what phase ofthe workshop your in,
    //1= main menue, 2 = class componet(e.g. helmit), 3 =part sellect (e.g. barrel)
    public int workshop_Phase = 1;

    // the constuctor that makes the wepon componet of a class in the workshop
    public wepon_Constructor wc;

    // the constuctor that makes the wepon componet of a class in the workshop
    public armour_constructor ac;

    // the constuctor that makes the wepon componet of a class in the workshop
    public leathal_construcor lc;

    // the transform for all of the components the camera moves to
    public Transform hub;
    public Transform wepon_creation;
    public Transform armour_creation;
    public Transform leathal_creation;
    //used to refrence which component the camrea is going to
    public int menue_section = 0;

    //the game objects that hold the WC, AC and LC
    public GameObject Wepon_constructor;
    public GameObject Armour_constructor;
    public GameObject Leathal_constructor;

    //the position of the WC,AC and LC agme oobects in the hub menu
    public Transform wepon_hub;
    public Transform armour_hub;
    public Transform leathal_hub;

    // the back button
    public Text back_button_text;
    // Start is called before the first frame update
    void Start()
    {
        // used to load scriptable objects from the player staric invetory
        Debug.Log("load_data");
        if (save_system.has_save_data == false)
        {
            generate_parts(300);
        }
        else
        {
            load_inventory();//before loading in new parts turn off
        }
        save_inventory();
    }

    // Update is called once per frame
    void Update()
    {
        if (workshop_Phase == 1)
        {
            class1.interactable=true;
            class2.interactable=true;
            class3.interactable=true;
            class4.interactable=true;
            if (SceneManager.GetActiveScene().name == "workshop")
            {
                back_button_text.text = "main menu";
            }
            else if(SceneManager.GetActiveScene().name == "workshop form firing range")
            {
                back_button_text.text = "return to range";
            }
        }
        else
        {
            class1.interactable=false;
            class2.interactable=false;
            class3.interactable=false;
            class4.interactable=false;
            back_button_text.text = "back";
        }

        // sets the menue componets to be in the hub
        if (menue_section == 0)
        {
            transform.position = Vector3.Lerp(transform.position, hub.position, 0.2f);
            Wepon_constructor.transform.position = Vector3.Lerp(Wepon_constructor.transform.position, wepon_hub.position, 0.2f);
            Armour_constructor.transform.position = Vector3.Lerp(Armour_constructor.transform.position, armour_hub.position, 0.2f);
            Armour_constructor.transform.localScale = new Vector3(1, 1, 1);
            Leathal_constructor.transform.position = Vector3.Lerp(Leathal_constructor.transform.position, leathal_hub.position, 0.2f);

        }
        //moves the camera and selected class componet constructor to its own menue
        if (workshop_Phase == 2)
        {
            if (menue_section == 1)
            {
                transform.position = Vector3.Lerp(transform.position, wepon_creation.position +new Vector3(0,1,0), 0.2f);
                Wepon_constructor.transform.position = Vector3.Lerp(Wepon_constructor.transform.position, new Vector3(wepon_creation.position.x,wepon_creation.position.y,2f), 0.2f);
            }
            if (menue_section == 2)
            {
                transform.position = Vector3.Lerp(transform.position, armour_creation.position + new Vector3(1, 0, 0), 0.2f);
                Armour_constructor.transform.localScale = new Vector3(1.7f,1.7f,1.7f);
                Armour_constructor.transform.position = Vector3.Lerp(Armour_constructor.transform.position, new Vector3(armour_creation.position.x, armour_creation.position.y, 2), 0.2f);
            }
            if (menue_section == 3)
            {
                transform.position = Vector3.Lerp(transform.position, leathal_creation.position + new Vector3(1, 0, 0), 0.2f);
                Leathal_constructor.transform.position = Vector3.Lerp(Leathal_constructor.transform.position, new Vector3(leathal_creation.position.x, leathal_creation.position.y, 2), 0.2f);
            }
        }
    }
    //sets the selected class to be loaded
    //button presses
    public void class1Click()
    {
        workshop_Phase = 1;
        Class_Sellected = 1;
        wc.select_class(static_classes.Class1);
        ac.selectclass(static_classes.Class1);
        lc.selectclass(static_classes.Class1);
    }
    public void class2Click()
    {
        workshop_Phase = 1;
        Class_Sellected = 2;
        wc.select_class(static_classes.Class2);
        ac.selectclass(static_classes.Class2);
        lc.selectclass(static_classes.Class2);
    }
    public void class3Click()
    {
        workshop_Phase = 1;
        Class_Sellected = 3;
        wc.select_class(static_classes.Class3);
        ac.selectclass(static_classes.Class3);
        lc.selectclass(static_classes.Class3);
    }
    public void class4Click()
    {
        workshop_Phase = 1;
        Class_Sellected = 4;
        wc.select_class(static_classes.Class4);
        ac.selectclass(static_classes.Class4);
        lc.selectclass(static_classes.Class4);
    }
    // button fuctions used to load the classed based of what compont is clicked in the UI
    public void pickWepon()
    {
        if (Class_Sellected != 0)
        {
            workshop_Phase = 2;
            menue_section = 1;
        }
    }
    public void pickArmour()
    {
        if (Class_Sellected != 0)
        {
            workshop_Phase = 2;
            menue_section = 2;
        }
    }
    public void pickLeathal()
    {
        if (Class_Sellected != 0)
        {
            workshop_Phase = 2;
            menue_section = 3;
        }
    }

    //the back button moves the workshop state back and also saves the classes
    public void Back()
    {
        class_class.Class saved_class = new class_class.Class();

        if (workshop_Phase == 1 && SceneManager.GetActiveScene().name== "workshop")
        {
            SceneManager.LoadScene(0);
        }
        else if(workshop_Phase == 1 && SceneManager.GetActiveScene().name == "workshop form firing range")
        {
            SceneManager.LoadScene("Range");
        }



        if (workshop_Phase == 2)
        {
            workshop_Phase = 1;
            menue_section = 0;
        }
        if (workshop_Phase == 3 || workshop_Phase == 4 || workshop_Phase == 5)
        {

            wepon_Constructor x = Wepon_constructor.GetComponent<wepon_Constructor>();
            armour_constructor y = Armour_constructor.GetComponent<armour_constructor>();
            leathal_construcor z = Leathal_constructor.GetComponent<leathal_construcor>();

            saved_class.Wepon.amunition = x.anumition_script.AO;
            saved_class.Wepon.barrel = x.barrel_script.BO;
            saved_class.Wepon.grip = x.grip_script.GO;
            saved_class.Wepon.reciver = x.reciver_script.RO;
            saved_class.Wepon.scope = x.scope_script.SO;
            saved_class.Wepon.suport = x.suport_script.SO;

            saved_class.Armour.headpeice = y.headgear_script.HGO;
            saved_class.Armour.chestpeice = y.cheastplate_script.CPO;
            saved_class.Armour.boots = y.boots_script.BO;

            saved_class.Lethal.primer = z.primer_script.PO;
            saved_class.Lethal.payload = z.payload_script.PO;
            saved_class.Lethal.container = z.container_script.CO;

            if (Class_Sellected == 1 && workshop_Phase == 3)
            {
                static_classes.Class1 = saved_class;

            }
            if (Class_Sellected == 2 && workshop_Phase == 3)
            {
                static_classes.Class2 = saved_class;
            }
            if (Class_Sellected == 3 && workshop_Phase == 3)
            {
                static_classes.Class3 = saved_class;
            }
            if (Class_Sellected == 4 && workshop_Phase == 3)
            {
                static_classes.Class4 = saved_class;
            }

            save_inventory();
            workshop_Phase = 2;
        }
    }

    //loads the players inventory from a static script
    void load_inventory()
    {
        wc.barrels = player_inventory.barrels;
        wc.amunition_types = player_inventory.amunition_types;
        wc.grips = player_inventory.grips;
        wc.recevers = player_inventory.recevers;
        wc.scopes = player_inventory.scopes;
        wc.supports = player_inventory.suports;

        ac.boots = player_inventory.boots;
        ac.cheastplates = player_inventory.cheastplates;
        ac.headgear = player_inventory.headgear;

        lc.primers = player_inventory.primers;
        lc.payloads = player_inventory.payloads;
        lc.containers = player_inventory.containers;
    }

    //saves the players invetoy to a static script and then to a binary file
    void save_inventory()
    {
        player_inventory.barrels = wc.barrels;
        player_inventory.amunition_types = wc.amunition_types;
        player_inventory.grips = wc.grips;
        player_inventory.recevers = wc.recevers;
        player_inventory.scopes = wc.scopes;
        player_inventory.suports = wc.supports;

        player_inventory.boots = ac.boots;
        player_inventory.cheastplates = ac.cheastplates;
        player_inventory.headgear = ac.headgear;

        player_inventory.primers = lc.primers;
        player_inventory.payloads = lc.payloads;
        player_inventory.containers = lc.containers;


        player_inventory.saveinventory();
    }

    public void generate_parts(int NumToGen)
    {
        for (int i = 0; NumToGen > i; i++)
        {
            int PartToGen =Random.Range(1, 13);
            //barrels
            if (PartToGen == 1)
            {
                barrel_object x = ScriptableObject.CreateInstance<barrel_object>();


                x.lenght = Random.Range(1, 10);
                x.material = Random.Range(0, 2);
                x.specalty = Random.Range(0, 3);
                x.name = "barrel";
                x.weight = x.lenght + x.specalty;

                if (x.specalty == 0)
                {
                    x.mesh = Resources.Load("final calss parts/wepons/barrel/GenericBarrel", typeof(Mesh)) as Mesh;
                    x.mat = Resources.Load("final calss parts/wepons/barrel/generic barrel", typeof(Material)) as Material;
                }
                if (x.specalty == 1)
                {
                    x.mesh = (Mesh)Resources.Load("final calss parts/wepons/barrel/PaintCan_Supressor_barrel", typeof(Mesh));
                    x.mat = (Material)Resources.Load("final calss parts/wepons/barrel/paintcan barrel 2", typeof(Material));
                }
                if (x.specalty == 2)
                {
                   
                    x.mesh = (Mesh)Resources.Load("final calss parts/wepons/barrel/Mesh_OverHeat", typeof(Mesh));
                    x.mat = (Material)Resources.Load("final calss parts/wepons/barrel/overheat barrel", typeof(Material));
                }
                wc.barrels.Add(x);
            }
            //amunition
            if (PartToGen == 2)
            {
                amunition_object x = ScriptableObject.CreateInstance<amunition_object>();


                
                x.blast_radius = Random.Range(0,5);
                x.element = Random.Range(0,5);
                x.prjectile = 1;
                x.range = Random.Range(1,5);
                x.rounds = Random.Range(1,100);
                x.speciality = Random.Range(0,4);
                x.damage = Random.Range(1,10);

                x.name = "amunition";
                x.weight = x.blast_radius +x.range+x.rounds/10+x.damage/2;

                if (x.speciality == 0 || x.speciality==1)
                {
                    x.mesh = (Mesh)Resources.Load("final calss parts/wepons/amunition/generic mag", typeof(Mesh));
                    x.mat = (Material)Resources.Load("final calss parts/wepons/amunition/generic mag", typeof(Material));
                }
                if (x.speciality == 2)
                {
                    x.mesh = (Mesh)Resources.Load("final calss parts/wepons/amunition/EnergyAmmo", typeof(Mesh));
                    x.mat = (Material)Resources.Load("final calss parts/wepons/amunition/energy", typeof(Material));
                }
                if (x.speciality == 3)
                {

                    x.mesh = (Mesh)Resources.Load("final calss parts/wepons/amunition/FastMag", typeof(Mesh));
                    x.mat = (Material)Resources.Load("final calss parts/wepons/amunition/fastmag", typeof(Material));
                }
                wc.amunition_types.Add(x);
            }

            //grips
            if (PartToGen == 3)
            {
                grip_object x = ScriptableObject.CreateInstance<grip_object>();



                x.name = "grip";
                x.grip_angle = Random.Range(0,90);
                x.speciality = Random.Range(0,3);

             
                x.weight = 2+x.speciality;
                
                if (x.speciality == 0)
                {
                    x.meshshape = (Mesh)Resources.Load("final calss parts/wepons/grip/generic grip", typeof(Mesh));
                    x.mat = (Material)Resources.Load("final calss parts/wepons/grip/generic grip", typeof(Material));
                }
                if (x.speciality == 1)
                {
                    x.meshshape = (Mesh)Resources.Load("final calss parts/wepons/grip/Grip_Stun_Bash", typeof(Mesh));
                    x.mat = (Material)Resources.Load("final calss parts/wepons/grip/stun bash", typeof(Material));
                }
                if (x.speciality == 2)
                {
                    x.meshshape = (Mesh)Resources.Load("final calss parts/wepons/grip/AutoAdjustGrip", typeof(Mesh));
                    x.mat = (Material)Resources.Load("final calss parts/wepons/grip/auto adjust", typeof(Material));
                }
                
                wc.grips.Add(x);
            }
            //reciver
            if (PartToGen == 4)
            {
                weponReciver_object x = ScriptableObject.CreateInstance<weponReciver_object>();



                x.name = "reciver";
   

                x.fire_rate = Random.Range(1,5);
                x.spciality = Random.Range(0,4);
                x.element = Random.Range(0,5);
                x.wepon_type = 1;

      
                x.weight = x.fire_rate;

                x.anumition_fit = new Vector3(0.2f, -0.5f, 0);
                x.barrel_fit = new Vector3(-1.5f, 0, 0);
                x.grip_fit = new Vector3(-.7f, -0.8f, 0);
                x.scope_fit = new Vector3(0, 0.5f, 0);
                x.suport_fit = new Vector3(1.5f, -0.3f, 0);

                if (x.spciality == 0)
                {
                    x.mesh = (Mesh)Resources.Load("final calss parts/wepons/reciver/generic reciver", typeof(Mesh));
                    x.mat = (Material)Resources.Load("final calss parts/wepons/reciver/generic reciver", typeof(Material));
                    x.anumition_fit = new Vector3(0.2f, -0.5f, 0);
                    x.barrel_fit = new Vector3(-1.5f, 0, 0);
                    x.grip_fit = new Vector3(-.7f, -0.8f, 0);
                    x.scope_fit = new Vector3(0, 0.5f, 0);
                    x.suport_fit = new Vector3(1.5f, -0.3f, 0);
                }
                if (x.spciality == 1)
                {
                    x.mesh = (Mesh)Resources.Load("final calss parts/wepons/reciver/GRAVITY RECIVER", typeof(Mesh));
                    x.mat = (Material)Resources.Load("final calss parts/wepons/reciver/suck and push reciver", typeof(Material));
                }
                if (x.spciality == 2)
                {
                    x.mesh = (Mesh)Resources.Load("final calss parts/wepons/reciver/energy reciver", typeof(Mesh));
                    x.mat = (Material)Resources.Load("final calss parts/wepons/reciver/energy reciver", typeof(Material));
                }
                if (x.spciality == 3)
                {
                    x.mesh = (Mesh)Resources.Load("final calss parts/wepons/reciver/ROTARRY RECIVEWR", typeof(Mesh));
                    x.mat = (Material)Resources.Load("final calss parts/wepons/reciver/rotary reciver", typeof(Material));          
                }


                wc.recevers.Add(x);
            }
            //scopes
            if (PartToGen == 5)
            {
                scope_object x = ScriptableObject.CreateInstance<scope_object>();

                
                x.speciality = Random.Range(0,2);
                if (Random.Range(0, 1) == 0) {
                    x.trhermal = false;
                }
                else
                {
                    x.trhermal = true;
                }
                x.zoom = Random.Range(1,10);

                

                x.name = "optic";
                x.weight = 2 + x.zoom;

                if (x.zoom > 7)
                {
                    x.mesh = (Mesh)Resources.Load("final calss parts/wepons/optic/DistanceScope", typeof(Mesh));
                    x.mat = (Material)Resources.Load("final calss parts/wepons/optic/distance aim", typeof(Material));
                }
                else if (x.zoom > 3 || x.trhermal==true)
                {
                    x.mesh = (Mesh)Resources.Load("final calss parts/wepons/optic/AlertScope", typeof(Mesh));
                    x.mat = (Material)Resources.Load("final calss parts/wepons/optic/alert aim", typeof(Material));
                }
                else 
                {
                    x.mesh = (Mesh)Resources.Load("final calss parts/wepons/optic/GenericAim", typeof(Mesh));
                    x.mat = (Material)Resources.Load("final calss parts/wepons/optic/generic aim", typeof(Material));
                }

                wc.scopes.Add(x);
            }

            //support/stock
            if (PartToGen == 6)
            {
                Suport_object x = ScriptableObject.CreateInstance<Suport_object>();


                x.speciality = Random.Range(0,3);

                x.name = "stock";
                x.weight = 2;
                

                if (x.speciality == 0)
                {
                    x.mesh = (Mesh)Resources.Load("final calss parts/wepons/stock/generic_stock", typeof(Mesh));
                    x.mat = (Material)Resources.Load("final calss parts/wepons/stock/generic stock", typeof(Material));
                }
                if (x.speciality == 1)
                {
                    x.mesh = (Mesh)Resources.Load("final calss parts/wepons/stock/lowGravity_thruster", typeof(Mesh));
                    x.mat = (Material)Resources.Load("final calss parts/wepons/stock/lowgravity stock", typeof(Material));
                }
                if (x.speciality == 2)
                {
                    x.mesh = (Mesh)Resources.Load("final calss parts/wepons/stock/RunGun_Stock", typeof(Mesh));
                    x.mat = (Material)Resources.Load("final calss parts/wepons/stock/rin and gin stock", typeof(Material));
                    
                }
                

                wc.supports.Add(x);
            }

            if (PartToGen == 7)
            {
                headgear_object x = ScriptableObject.CreateInstance<headgear_object>();


                x.name = "headgear";
                
                x.deffence = Random.Range(1,10);
                x.speciality = Random.Range(0, 3);
                x.weight = x.deffence + x.speciality;

                if (x.speciality == 0)
                {
                    if (Random.Range(0, 2) == 1)
                    {
                        x.mesh = (Mesh)Resources.Load("final calss parts/armour/helmit/Generic_Helmet_1", typeof(Mesh));
                        x.mat = (Material)Resources.Load("final calss parts/armour/helmit/generic helmit 1", typeof(Material));
                    }
                    else
                    {
                        x.mesh = (Mesh)Resources.Load("final calss parts/armour/helmit/Generic_Helmet_2", typeof(Mesh));
                        x.mat = (Material)Resources.Load("final calss parts/armour/helmit/generic helmit 2", typeof(Material));
                    }
                }
                if (x.speciality == 1)
                {
                    x.mesh = (Mesh)Resources.Load("final calss parts/armour/helmit/Advanced_helmet", typeof(Mesh));
                    x.mat = (Material)Resources.Load("final calss parts/armour/helmit/advance hemit", typeof(Material));
                }
                if (x.speciality == 2)
                {
                    x.mesh = (Mesh)Resources.Load("final calss parts/armour/helmit/Sensory_helmet", typeof(Mesh));
                    x.mat = (Material)Resources.Load("final calss parts/armour/helmit/sensery helm", typeof(Material));
                }


                ac.headgear.Add(x);
            }

            if (PartToGen == 8)
            {
                cheastplate_object x = ScriptableObject.CreateInstance<cheastplate_object>();


                x.name = "chestplate";

                x.deffence = Random.Range(1, 10);
                x.specicality = Random.Range(0, 3);
                x.weight = x.deffence + x.specicality;

                if (x.specicality == 0)
                {
                    if (Random.Range(0, 2) == 1)
                    {
                        x.mesh = (Mesh)Resources.Load("final calss parts/armour/chestplate/Generic_Chest", typeof(Mesh));
                        x.material = (Material)Resources.Load("final calss parts/armour/chestplate/generic 1", typeof(Material));
                    }
                    else
                    {
                        x.mesh = (Mesh)Resources.Load("final calss parts/armour/chestplate/Generic_Chest_1", typeof(Mesh));
                        x.material = (Material)Resources.Load("final calss parts/armour/chestplate/generic 2", typeof(Material));
                    }
                }
                if (x.specicality == 1)
                {
                    x.mesh = (Mesh)Resources.Load("final calss parts/armour/chestplate/Ammo_Chest", typeof(Mesh));
                    x.material = (Material)Resources.Load("final calss parts/armour/chestplate/ammo chestplate", typeof(Material));
                }
                if (x.specicality == 2)
                {
                    x.mesh = (Mesh)Resources.Load("final calss parts/armour/chestplate/LauncherPads_Chest", typeof(Mesh));
                    x.material = (Material)Resources.Load("final calss parts/armour/chestplate/launcher", typeof(Material));
                }


                ac.cheastplates.Add(x);
            }

            if (PartToGen == 9)
            {
                boots_object x = ScriptableObject.CreateInstance<boots_object>();


                x.name = "boots";

                x.deffence = Random.Range(1, 10);
                x.speciality = Random.Range(0, 3);
                x.weight = x.deffence + x.speciality;

                if (x.speciality == 0)
                {
                    x.mesh = (Mesh)Resources.Load("final calss parts/armour/boots/Generic_Boots", typeof(Mesh));
                    x.mat = (Material)Resources.Load("final calss parts/armour/boots/generic boots", typeof(Material));
                }
                if (x.speciality == 1)
                {
                    x.mesh = (Mesh)Resources.Load("final calss parts/armour/boots/HorseKick_Boots", typeof(Mesh));
                    x.mat = (Material)Resources.Load("final calss parts/armour/boots/horse kick boots", typeof(Material));
                }
                if (x.speciality == 2)
                {
                    x.mesh = (Mesh)Resources.Load("final calss parts/armour/boots/Speed_Boots", typeof(Mesh));
                    x.mat = (Material)Resources.Load("final calss parts/armour/boots/speed boots", typeof(Material));
                }


                ac.boots.Add(x);
            }
            if (PartToGen == 10)
            {
                primer_object x = ScriptableObject.CreateInstance<primer_object>();


                x.name = "primer";

                if (Random.Range(0,2) == 1)
                    x.manual = true;
                x.speciality = Random.Range(0,4);
                x.timer = Random.Range(1,5);

                if (x.speciality == 0)
                {
                    x.mesh = (Mesh)Resources.Load("final calss parts/lethal/primer/Lever", typeof(Mesh));
                    x.mat = (Material)Resources.Load("final calss parts/lethal/primer/granade container 2", typeof(Material));
                }
                if (x.speciality == 1)
                {
                    //vortex
                    x.mesh = (Mesh)Resources.Load("final calss parts/lethal/primer/Vortex primer", typeof(Mesh));
                    x.mat = (Material)Resources.Load("final calss parts/lethal/primer/vortex container", typeof(Material));
                }
                if (x.speciality == 2)
                {
                    //mine
                    x.mesh = (Mesh)Resources.Load("final calss parts/lethal/primer/Mine primer", typeof(Mesh));
                    x.mat = (Material)Resources.Load("final calss parts/lethal/primer/mine primer", typeof(Material));
                }
                if (x.speciality == 3)
                {
                    //impact
                    x.mesh = (Mesh)Resources.Load("final calss parts/lethal/primer/impact_container", typeof(Mesh));
                    x.mat = (Material)Resources.Load("final calss parts/lethal/primer/impact primer", typeof(Material));
                }


                lc.primers.Add(x);
            }

            if (PartToGen == 11)
            {
                payload_object x = ScriptableObject.CreateInstance<payload_object>();



                x.name = "payload";
                int stat_point=10;
                int stat = Random.Range(1,Mathf.Clamp(5,1,stat_point));
                x.damage = stat;
                stat_point -= stat;
                stat = Random.Range(1, Mathf.Clamp(5, 1, stat_point));
                x.element = stat;
                stat_point -= stat;
                stat = Random.Range(1, Mathf.Clamp(5, 1, stat_point));
                x.radious = stat;
           
                lc.payloads.Add(x);
            }

            if (PartToGen == 12)
            {
                container_object x = ScriptableObject.CreateInstance<container_object>();


                x.name = "container";

                x.speciality = Random.Range(0,4);
                if (Random.Range(0,2) == 1)
                    x.sticky = true;
                x.weight = x.speciality + 3;

                if (x.speciality == 0)
                {
                    x.mesh = (Mesh)Resources.Load("final calss parts/lethal/container/Body", typeof(Mesh));
                    x.mat = (Material)Resources.Load("final calss parts/lethal/container/granade container", typeof(Material));
                }
                if (x.speciality == 1)
                {
                    //knife
                    x.mesh = (Mesh)Resources.Load("final calss parts/lethal/container/Knife", typeof(Mesh));
                    x.mat = (Material)Resources.Load("final calss parts/lethal/container/knife container", typeof(Material));
                }
                if (x.speciality == 2)
                {
                    //seeker
                    x.mesh = (Mesh)Resources.Load("final calss parts/lethal/container/Seeker_container", typeof(Mesh));
                    x.mat = (Material)Resources.Load("final calss parts/lethal/container/seeker container", typeof(Material));
                }
                if (x.speciality == 3)
                {
                    //shrapnel
                    x.mesh = (Mesh)Resources.Load("final calss parts/lethal/container/JunkBall", typeof(Mesh));
                    x.mat = (Material)Resources.Load("final calss parts/lethal/container/granade container", typeof(Material));
                }


                lc.containers.Add(x);
            }
        }

    }
}

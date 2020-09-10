/*
by:Milan Manji
script descrition: is used for the player to interact with the workshop system and save and load class data
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        //load_inventory();//before loading in new parts turn off
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
            back_button_text.text = "main menu";
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

        if (workshop_Phase == 1)
        {
            SceneManager.LoadScene(0);
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
}

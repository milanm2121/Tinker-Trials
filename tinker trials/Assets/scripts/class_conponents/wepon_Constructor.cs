/*
by:Milan Manji
script descrition: this script is used for the workshp to interact with the wepon componet and viseversa

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wepon_Constructor : MonoBehaviour
{
    //the workshop interface script
    public workshop_interphase WI;

    //The componets for the wepon 
    public GameObject barrel;
    public wepon_barrel barrel_script;

    public GameObject scope;
    public wepon_scope scope_script;

    public GameObject grip;
    public wepon_grip grip_script;

    public GameObject anumition;
    public wepon_anumition anumition_script;

    public GameObject suport;
    public wepon_suport suport_script;

    public GameObject reciver;
    public wepon_reciver reciver_script;


    // adefalt class the game gives you if there is no class or an incompleat class
    public class_class.wepon defalt_class;

    //the menu for each indivisual part of the compont
    public GameObject barrel_menu; 
    public GameObject reciver_menue;
    public GameObject scopes_menue;
    public GameObject amunition_menue;
    public GameObject grip_menue;
    public GameObject suports_menue;

    // the list for the menu to lad for each componet
    public List<barrel_object> barrels;
    public List<weponReciver_object> recevers;
    public List<scope_object> scopes;
    public List<amunition_object> amunition_types;
    public List<grip_object> grips;
    public List<Suport_object> supports;

    // which menue is beeing looked at
    int active_list=0;
    // a text box that aperes when a part  is sellected
    public GameObject decription;

    // a list of bution to acivate and deactivate when a menue is up
    public List<GameObject> buttons;

    // Start is called before the first frame update
    void Start()
    {
        reciver = transform.GetChild(1).gameObject;
        reciver_script = reciver.GetComponent<wepon_reciver>();

        barrel = transform.GetChild(0).gameObject;
        barrel_script = barrel.GetComponent<wepon_barrel>();

        scope = transform.GetChild(2).gameObject;
        scope_script = scope.GetComponent<wepon_scope>();

        anumition = transform.GetChild(3).gameObject;
        anumition_script = anumition.GetComponent<wepon_anumition>();

        grip = transform.GetChild(4).gameObject;
        grip_script = grip.GetComponent<wepon_grip>();

        suport = transform.GetChild(5).gameObject;
        suport_script = suport.GetComponent<wepon_suport>();

    }

    // loads the class selected in to the Wecon_Constructor
    public void select_class(class_class.Class class_)
    {
        //load class
        if (class_.Wepon.barrel == null || class_.Wepon.reciver == null || class_.Wepon.scope == null || class_.Wepon.amunition == null || class_.Wepon.grip == null || class_.Wepon.suport == null)
        {
            barrel_script.BO = defalt_class.barrel;
            reciver_script.RO = defalt_class.reciver;
            scope_script.SO = defalt_class.scope;
            anumition_script.AO = defalt_class.amunition;
            grip_script.GO = defalt_class.grip;
            suport_script.SO = defalt_class.suport;
        }
        else//used defalt class
        {
            barrel_script.BO = class_.Wepon.barrel;
            reciver_script.RO = class_.Wepon.reciver;
            scope_script.SO = class_.Wepon.scope;
            anumition_script.AO = class_.Wepon.amunition;
            grip_script.GO = class_.Wepon.grip;
            suport_script.SO = class_.Wepon.suport;
        }
        //generate wepon
        reciver_script.generateRecever();
        barrel_script.generateBarrel();
        scope_script.generateScope();
        anumition_script.generateObject();
        grip_script.generateGip();
        suport_script.generateSuport();

        //postioning wepon parts
        position_parts();

    }

    private void Update()
    {
        // activates and de activates button when a part menue is up
        if (WI.workshop_Phase == 2)
        {
            for(int i = 0; buttons.Count > i; i++)
            {
                buttons[i].SetActive(true);
                barrel.SetActive(true);
                reciver.SetActive(true);
                scope.SetActive(true);
                anumition.SetActive(true);
                grip.SetActive(true);
                suport.SetActive(true);
                decription.SetActive(false);
            }
            active_list = 0;
        }
        else if(WI.workshop_Phase==3)
        {
            for (int i = 0; buttons.Count > i; i++)
            {
                buttons[i].SetActive(false);
                barrel.SetActive(false);
                reciver.SetActive(false);
                scope.SetActive(false);
                anumition.SetActive(false);
                grip.SetActive(false);
                suport.SetActive(false);
                decription.SetActive(true);
            }
        }

        //activates and deactivates the menues
        if (active_list == 1)
        {
            barrel_menu.SetActive(true);
        }
        else
        {
            barrel_menu.SetActive(false);
        }
        if (active_list == 2)
        {
            reciver_menue.SetActive(true);
        }
        else
        {
            reciver_menue.SetActive(false);
        }
        if (active_list == 3)
        {
            scopes_menue.SetActive(true);
        }
        else
        {
            scopes_menue.SetActive(false);
        }
        if (active_list == 4)
        {
            amunition_menue.SetActive(true);
        }
        else
        {
            amunition_menue.SetActive(false);
        }
        if (active_list == 5)
        {
            grip_menue.SetActive(true);
        }
        else
        {
            grip_menue.SetActive(false);
        }
        if (active_list == 6)
        {
            suports_menue.SetActive(true);
        }
        else
        {
            suports_menue.SetActive(false);
        }

        
    }
    //public fuctions for buttons to activate a menue
    public void changeBarrel()
    {
        active_list = 1;
        WI.workshop_Phase = 3;
    }
    public void changeScope()
    {
        active_list = 3;
        WI.workshop_Phase = 3;
    }
    public void changeReciver()
    {
        active_list = 2;
        WI.workshop_Phase = 3;
    }
    public void changeAmunition()
    {
        active_list = 4;
        WI.workshop_Phase = 3;
    }
    public void channgeGrip()
    {
        active_list = 5;
        WI.workshop_Phase = 3;
    }
    public void changeSupport()
    {
        active_list = 6;
        WI.workshop_Phase = 3;
    }

    //positions the parts to work with the reciver componets
    public void position_parts()
    {
        reciver.transform.localPosition = Vector3.zero;

        barrel.transform.localPosition = reciver_script.barrel_fit;

        scope.transform.localPosition = reciver_script.scope_fit;

        anumition.transform.localPosition = reciver_script.anumition_fit;

        grip.transform.localPosition = reciver_script.grip_fit;

        suport.transform.localPosition = reciver_script.suport_fit;
    }
}

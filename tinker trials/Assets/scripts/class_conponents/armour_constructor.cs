/*
by:Milan Manji
script descrition: this script important for generating the armour and works in the same sence as the wepon constructor use that as a refrence

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armour_constructor : MonoBehaviour
{
    public workshop_interphase WI;

    public GameObject head_gear;
    public headgear headgear_script;

    public GameObject cheastplate;
    public cheastplate cheastplate_script;

    public GameObject Boots;
    public boots_scripts boots_script;

    public headgear_object defaltHeadGear;
    public cheastplate_object defalt_chestplate;
    public boots_object defaltBoots;

    public GameObject headgear_menu;
    public GameObject cheastplate_menu;
    public GameObject boots_menu;

    public List<headgear_object> headgear;
    public List<cheastplate_object> cheastplates;
    public List<boots_object> boots;

    int active_list = 0;
    public GameObject decription;

    public List<GameObject> buttons;

    public void selectclass(class_class.Class Class_)
    {
        //defalt armour
        if (Class_.Armour.headpeice == null || Class_.Armour.chestpeice == null || Class_.Armour.boots == null)
        {
            headgear_script.HGO = defaltHeadGear;
            cheastplate_script.CPO = defalt_chestplate;
            boots_script.BO = defaltBoots;
        }
        else//load armour
        {
            headgear_script.HGO = Class_.Armour.headpeice;
            cheastplate_script.CPO = Class_.Armour.chestpeice;
            boots_script.BO = Class_.Armour.boots;
        }
        //generate armour
        headgear_script.Generate_headGear();
        cheastplate_script.gerateCheastPlate();
        boots_script.generateBoots();
    }

    private void Update()
    {
        if (WI.workshop_Phase == 2)
        {
            for (int i = 0; buttons.Count > i; i++)
            {
                buttons[i].SetActive(true);
                head_gear.SetActive(true);
                cheastplate.SetActive(true);
                Boots.SetActive(true);
                decription.SetActive(false);
            }
            active_list = 0;
        }
        else if (WI.workshop_Phase == 3)
        {
            for (int i = 0; buttons.Count > i; i++)
            {
                buttons[i].SetActive(false);
                head_gear.SetActive(false);
                cheastplate.SetActive(false);
                Boots.SetActive(false);
                decription.SetActive(true);
            }
        }


        if (active_list == 1)
        {
            headgear_menu.SetActive(true);
        }
        else
        {
            headgear_menu.SetActive(false);
        }
        if (active_list == 2)
        {
            cheastplate_menu.SetActive(true);
        }
        else
        {
            cheastplate_menu.SetActive(false);
        }
        if (active_list == 3)
        {
            boots_menu.SetActive(true);
        }
        else
        {
            boots_menu.SetActive(false);
        }
    }

    public void change_headgear()
    {
        active_list = 1;
        WI.workshop_Phase = 3;
    }
    public void change_chestplate()
    {
        active_list = 2;
        WI.workshop_Phase = 3;
    }
    public void change_boots()
    {
        active_list = 3;
        WI.workshop_Phase = 3;
    }

}

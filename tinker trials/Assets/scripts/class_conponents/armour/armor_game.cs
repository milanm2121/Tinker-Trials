/*
by:Milan Manji
script descrition: this script is used for generating armour in game and all of its stats

*/
//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class armor_game : MonoBehaviour
{
    public GameObject head_gear;
    public headgear headgear_script;

    public GameObject cheastplate;
    public cheastplate cheastplate_script;

    public GameObject L_Boots;
    public boots_scripts L_boots_script;
    
    public GameObject R_Boots;
    public boots_scripts R_boots_script;

    public float weight=0;
    public int deffence;

    public AudioMixer SFX;

    public player_ID PID;

    // Start is called before the first frame update
    void Awake()
    {
        //adds all of the stats of get a defence value
        if (PID.is_player == true)
        {
            selectclass(static_classes.Class1);
        }
        else
        {
            Generate_armour();
            headgear_script.Generate_headGear();
            cheastplate_script.gerateCheastPlate();
            L_boots_script.generateBoots();
            R_boots_script.generateBoots();
        }
        weight += headgear_script.HGO.weight;
        weight += cheastplate_script.CPO.weight;
        weight += L_boots_script.BO.weight;
        deffence += headgear_script.HGO.deffence;
        deffence += cheastplate_script.CPO.deffence;
        deffence += L_boots_script.BO.deffence;
        deffence = deffence / 3 * 10;

        

    }

    

    // Update is called once per frame
    void Start()
    {
        if (headgear_script.HGO.speciality == 2)
        {
            Debug.Log(SFX.SetFloat("SFX Volume",10));
        }
        else
        {
            Debug.Log(SFX.SetFloat("SFX Volume", 0));
        }
    }
    public void selectclass(class_class.Class Class_)
    {
        //defalt armour
        

        headgear_script.HGO = Class_.Armour.headpeice;
        cheastplate_script.CPO = Class_.Armour.chestpeice;
        L_boots_script.BO = Class_.Armour.boots;
        R_boots_script.BO = Class_.Armour.boots;


        //generate armour
        headgear_script.Generate_headGear();
        cheastplate_script.gerateCheastPlate();
        L_boots_script.generateBoots();
        R_boots_script.generateBoots();

    }
    
    private void Generate_armour()
    {
        if (true)
        {
            headgear_object x = ScriptableObject.CreateInstance<headgear_object>();


            x.name = "headgear";

            x.deffence = Random.Range(1, 10);
            x.speciality = Random.Range(0, 3);
            x.weight = x.deffence + x.speciality;

            if (x.speciality == 0)
            {
                x.mesh = (Mesh)Resources.Load("AssetsFixed_Exported/Armour/Generic_Helmet", typeof(Mesh));
                x.mat = (Material)Resources.Load("AssetsFixed_Exported/Armour/Generic_Helmet", typeof(Material));
            }
            if (x.speciality == 1)
            {
                x.mesh = (Mesh)Resources.Load("AssetsFixed_Exported/Armour/Communication_Helmet", typeof(Mesh));
                x.mat = (Material)Resources.Load("AssetsFixed_Exported/Armour/Communication_Helmet", typeof(Material));
            }
            if (x.speciality == 2)
            {
                x.mesh = (Mesh)Resources.Load("AssetsFixed_Exported/Armour/Communication_Helmet", typeof(Mesh));
                x.mat = (Material)Resources.Load("AssetsFixed_Exported/Armour/Communication_Helmet", typeof(Material));
            }


            headgear_script.HGO=x;
        }

        if (true)
        {
            cheastplate_object x = ScriptableObject.CreateInstance<cheastplate_object>();


            x.name = "chestplate";

            x.deffence = Random.Range(1, 10);
            x.specicality = Random.Range(0, 4);
            x.weight = x.deffence + x.specicality;

            if (x.specicality == 0)
            {

                x.mesh = (Mesh)Resources.Load("AssetsFixed_Exported/Armour/Generic1_Chest", typeof(Mesh));
                x.material = (Material)Resources.Load("AssetsFixed_Exported/Armour/Generic1_Chest", typeof(Material));
            }
            if (x.specicality == 1)
            {
                x.mesh = (Mesh)Resources.Load("AssetsFixed_Exported/Armour/Ammo_Chest", typeof(Mesh));
                x.material = (Material)Resources.Load("AssetsFixed_Exported/Armour/Ammo_Chest", typeof(Material));
            }
            if (x.specicality == 2)
            {
                x.mesh = (Mesh)Resources.Load("AssetsFixed_Exported/Armour/LauncherPads_Chest", typeof(Mesh));
                x.material = (Material)Resources.Load("AssetsFixed_Exported/Armour/LauncherPads_Chest", typeof(Material));
            }


            cheastplate_script.CPO = x;
        }

        if (true)
        {
            boots_object x = ScriptableObject.CreateInstance<boots_object>();


            x.name = "boots";

            x.deffence = Random.Range(1, 10);
            x.speciality = Random.Range(0, 3);
            x.weight = x.deffence + x.speciality;

            if (x.speciality == 0)
            {
                x.mesh = (Mesh)Resources.Load("AssetsFixed_Exported/Armour/Generic_Boot", typeof(Mesh));
                x.mat = (Material)Resources.Load("AssetsFixed_Exported/Armour/Generic_Boot", typeof(Material));
            }
            if (x.speciality == 1)
            {
                x.mesh = (Mesh)Resources.Load("AssetsFixed_Exported/Armour/HorseKick_Boot", typeof(Mesh));
                x.mat = (Material)Resources.Load("AssetsFixed_Exported/Armour/HorseKick_Boot", typeof(Material));
            }
            if (x.speciality == 2)
            {
                x.mesh = (Mesh)Resources.Load("AssetsFixed_Exported/Armour/Speed_Boot", typeof(Mesh));
                x.mat = (Material)Resources.Load("AssetsFixed_Exported/Armour/Speed_Boot", typeof(Material));
            }


            L_boots_script.BO = x;
            R_boots_script.BO = x;
        }
    }
}

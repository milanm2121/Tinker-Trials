/*
by:Milan Manji
script descrition: this script is used for generating armour in game and all of its stats

*/
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
    
    // Start is called before the first frame update
    void Awake()
    {
        //adds all of the stats of get a defence value
        selectclass(static_classes.Class1);
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
}

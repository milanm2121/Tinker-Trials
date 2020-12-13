/*
by:Milan Manji
script descrition: this script is used for generating headgear decriptions in the menu find refrence to this script in the amunition section because of its basicly the same

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class select_headgear : MonoBehaviour
{
    public headgear HG;
    public armour_constructor AC;
    public TMP_Text text;
    public GameObject hover_pannel;

    private void Start()
    {
        HG = GetComponent<headgear>();
    }
    public void selectHeadgear()
    {
        AC.headgear_script.HGO = HG.HGO;
        AC.headgear_script.Generate_headGear();
    }
    public void headgear_decription()
    {
        hover_pannel.transform.position = transform.position;

        string decription = "";
        decription += "Name: " + HG.HGO.name + "\n"+"\n";
        decription += "Deffence: " + HG.HGO.deffence + "\n";
        decription += "This effects your players armour rating the higer it is the less damage you take" + "\n" + "\n";


        if (HG.HGO.speciality == 0)
        {
            decription += "Speciality: " + "none" + "\n" + "\n";
        }
        else if (HG.HGO.speciality == 1)
        {
            decription += "Speciality: " + "Advanced hud, more UI" + "\n" + "\n";
        }
        else if (HG.HGO.speciality == 2)
        {
            decription += "Speciality: " + "Sensory boost, hear moar" + "\n" + "\n";
        }

        decription += "Weight: " + HG.HGO.weight + "\n";
        decription += "This effects your players movement speed only";

        text.text = decription;
    }

}

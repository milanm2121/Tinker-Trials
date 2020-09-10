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
        string decription = "";
        decription += "name: " + HG.HGO.name + "\n";
        decription += "deffence: " + HG.HGO.deffence + "\n";

        if (HG.HGO.speciality == 0)
        {
            decription += "speciality: " + "none" + "\n";
        }
        else if (HG.HGO.speciality == 1)
        {
            decription += "speciality: " + "Advanced hud, more UI" + "\n";
        }
        else if (HG.HGO.speciality == 2)
        {
            decription += "speciality: " + "Sensory boost, hear moar" + "\n";
        }

        decription += "weight: " + HG.HGO.weight + "\n";
        text.text = decription;
    }

}

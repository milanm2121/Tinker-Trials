/*
by:Milan Manji
script descrition: this script is used for generating boot decriptions in the menu find refrence to this script in the amunition section because of its basicly the same

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class select_boots : MonoBehaviour
{
    public boots_scripts BT;
    public armour_constructor AC;
    public TMP_Text text;
    public GameObject hover_pannel;

    private void Start()
    {
        BT = GetComponent<boots_scripts>();
    }
    public void selectBoots()
    {
        AC.boots_script.BO = BT.BO;
        AC.boots_script.generateBoots();
    }
    public void Boots_decription()
    {
        hover_pannel.transform.position = transform.position;

        string decription = "";
        decription += "name: " + BT.BO.name + "\n";
        decription += "deffence: " + BT.BO.deffence + "\n";

        if (BT.BO.speciality == 0)
        {
            decription += "speciality: " + "none" + "\n";
        }
        else if (BT.BO.speciality == 1)
        {
            decription += "speciality: " + "speed boots" + "\n";
        }
        else if (BT.BO.speciality == 2)
        {
            decription += "speciality: " + "dubble jump" + "\n";
        }
        else if (BT.BO.speciality == 3)
        {
            decription += "speciality: " + "kick" + "\n";
        }

        decription += "weight: " + BT.BO.weight + "\n";
        text.text = decription;
    }

}

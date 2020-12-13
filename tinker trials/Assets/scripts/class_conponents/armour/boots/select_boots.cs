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
        decription += "Name: " + BT.BO.name + "\n";

        decription += "Deffence: " + BT.BO.deffence + "\n";
        decription += "This effects your players armour rating the higer it is the less damage you take" + "\n" + "\n";


        if (BT.BO.speciality == 0)
        {
            decription += "Speciality: " + "none" + "\n" + "\n";
        }
        else if (BT.BO.speciality == 1)
        {
            decription += "Speciality: " + "speed boots, this makes you move faster" + "\n" + "\n";
        }
        else if (BT.BO.speciality == 2)
        {
            decription += "Speciality: " + "dubble jump, this allows you to have an extra jump in the air" + "\n" + "\n";
        }
        else if (BT.BO.speciality == 3)
        {
            decription += "Speciality: " + "kick, this extends your melee range" + "\n" + "\n";
        }

        decription += "Weight: " + BT.BO.weight + "\n";
        decription += "This effects your players movement speed only";
        text.text = decription;
    }

}

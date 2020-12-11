/*
by:Milan Manji
script descrition: this script is used for generating cheastplates decriptions in the menu find refrence to this script in the amunition section because of its basicly the same

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class select_cheastplate : MonoBehaviour
{
    public cheastplate CP;
    public armour_constructor AC;
    public TMP_Text text;
    public GameObject hover_pannel;


    private void Start()
    {
        CP = GetComponent<cheastplate>();
    }
    public void selectCheastplate()
    {
        AC.cheastplate_script.CPO = CP.CPO;
        AC.cheastplate_script.gerateCheastPlate();
    }
    public void cheastplte_decription()
    {
        hover_pannel.transform.position = transform.position;

        string decription = "";
        decription += "name: " + CP.CPO.name + "\n";
        decription += "deffence: " + CP.CPO.deffence + "\n";

        if (CP.CPO.specicality == 0)
        {
            decription += "speciality: " + "none" + "\n";
        }
        else if (CP.CPO.specicality == 1)
        {
            decription += "speciality: " + "More ammo, hold more ammo" + "\n";
        }
        else if (CP.CPO.specicality == 2)
        {
            decription += "speciality: " + "Shoulder launcher, launch lethal while shooting or running" + "\n";
        }
        else if (CP.CPO.specicality == 3)
        {
            decription += "speciality: " + "Blast resistance, take less explosive damage" + "\n";
        }

        decription += "weight: " + CP.CPO.weight + "\n";
        text.text = decription;
    }

}

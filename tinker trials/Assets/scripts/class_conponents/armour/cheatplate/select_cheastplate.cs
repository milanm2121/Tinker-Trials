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
        decription += "Name: " + CP.CPO.name + "\n"+"\n";
        decription += "Deffence: " + CP.CPO.deffence + "\n";
        decription += "This effects your players armour rating the higer it is the less damage you take" + "\n" + "\n";

        if (CP.CPO.specicality == 0)
        {
            decription += "Speciality: " + "none" + "\n" + "\n";
        }
        else if (CP.CPO.specicality == 1)
        {
            decription += "Speciality: " + "More ammo, hold more ammo" + "\n" + "\n";
        }
        else if (CP.CPO.specicality == 2)
        {
            decription += "Speciality: " + "Shoulder launcher, launch lethal while shooting or running" + "\n" + "\n";
        }
   /*     else if (CP.CPO.specicality == 3)
        {
            decription += "Speciality: " + "Blast resistance, take less explosive damage" + "\n";
        }
   */
        decription += "Weight: " + CP.CPO.weight + "\n";
        decription += "This effects your players movement speed only";

        text.text = decription;
    }

}

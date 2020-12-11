/*
by:Milan Manji
script descrition: this script sets the text box description to desibe a part
and also sets the amunition object to be sellected for the class

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class sellect_amunition : MonoBehaviour
{
    public wepon_anumition WG;
    public wepon_Constructor WC;
    public TMP_Text text;
    public GameObject hover_pannel;

    private void Start()
    {
        WG = GetComponent<wepon_anumition>();
    }
    public void selectAmunition()
    {
        WC.anumition_script.AO = WG.AO;
        WC.anumition_script.generateObject();
    }
    public void Amunition_decription()
    {
        hover_pannel.transform.position = transform.position;

        string decription = "";
        decription += "name: " + WG.AO.name + "\n";
        decription += "damage: " + WG.AO.damage + "\n";
        decription += "blast radious: " + WG.AO.blast_radius + "\n";
        
        if (WG.AO.element == 0)
        {
            decription += "element: " + "none" + "\n";
        }else if (WG.AO.element == 1)
        {
            decription += "element: " + "fire" + "\n";
        }
        else if(WG.AO.element == 2)
        {
            decription += "element: " + "frost" + "\n";
        }
        else if (WG.AO.element == 3)
        {
            decription += "element: " + "earth" + "\n";
        }
        else if (WG.AO.element == 4)
        {
            decription += "element: " + "electricity" + "\n";
        }

        decription += "base range: " + WG.AO.range + "\n";

        decription += "rounds : " + WG.AO.rounds + "\n";

        if (WG.AO.speciality == 0)
        {
            decription += "speciality: " + "none" + "\n";
        }
        else if (WG.AO.speciality == 1)
        {
            decription += "speciality: " + "Buckshot, gun shoots buckshot spread" + "\n";
        }
        else if (WG.AO.speciality == 2)
        {
            decription += "speciality: " + "Energy, Powers the Lasers and Push/Pull Receivers" + "\n";
        }
        else if (WG.AO.speciality == 3)
        {
            decription += "speciality: " + "Fastmags, reload faster" + "\n";
        }
        decription += "weight: " + WG.AO.weight + "\n";
        text.text = decription;
    }
}

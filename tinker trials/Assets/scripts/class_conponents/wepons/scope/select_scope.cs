using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class select_scope : MonoBehaviour
{
    public wepon_scope WS;
    public wepon_Constructor WC;
    public TMP_Text text;
    public GameObject hover_pannel;

    private void Start()
    {
        WS = GetComponent<wepon_scope>();
    }
    public void selectScope()
    {
        WC.scope_script.SO = WS.SO;
        WC.scope_script.generateScope();
    }
    public void Scope_decription()
    {
        hover_pannel.transform.position = transform.position;

        string decription = "";
        decription += "name: " + WS.SO.name + "\n";
        decription += "zoom: " + WS.SO.zoom + "\n";
        if (WS.SO.trhermal == false)
        {
            decription += "thermal: " + "false" + "\n";
        }
        else if (WS.SO.trhermal == false)
        {
            decription += "thermal: " + "true" + "\n";
        }

        if (WS.SO.speciality == 0)
        {
            decription += "speciality: " + "none" + "\n";
        }
    /*    else if (WS.SO.speciality == 1)
        {
            decription += "speciality: " + "Alert, adds a visual effect to alert the player when they are being aimed at." + "\n";
        }
    */
        else if (WS.SO.speciality == 1)
        {
            decription += "speciality: " + "distance measurement, adds a measurement of how far the target aimed at is" + "\n";
        }
        
        decription += "weight: " + WS.SO.weight + "\n";
        text.text = decription;
    }
}

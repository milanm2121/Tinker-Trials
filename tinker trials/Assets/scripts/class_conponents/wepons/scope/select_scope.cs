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
        decription += "Name: " + WS.SO.name + "\n"+ "\n";
        decription += "Zoom: " + WS.SO.zoom + "\n";
        decription += "This effects zoom distance when aiming" + "\n";

        if (WS.SO.speciality == 0)
        {
            decription += "Speciality: " + "none" + "\n" + "\n";
        }

        else if (WS.SO.speciality == 1)
        {
            decription += "Speciality: " + "distance measurement, adds a measurement of how far the target aimed at is" + "\n" + "\n";
        }
        
        decription += "Weight: " + WS.SO.weight + "\n";
        decription += "This effects your players movement speed, reload and aim down sight speed";

        text.text = decription;
    }
}

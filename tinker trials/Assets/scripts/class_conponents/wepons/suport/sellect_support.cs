using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class sellect_support : MonoBehaviour
{
    public wepon_suport WS;
    public wepon_Constructor WC;
    public TMP_Text text;
    public GameObject hover_pannel;

    private void Start()
    {
        WS = GetComponent<wepon_suport>();
    }
    public void selectSupport()
    {
        WC.suport_script.SO = WS.SO;
        WC.suport_script.generateSuport();
    }
    public void Support_decription()
    {
        hover_pannel.transform.position = transform.position;

        string decription = "";
        decription += "name: " + WS.SO.name + "\n";
        

        if (WS.SO.speciality == 0)
        {
            decription += "speciality: " + "none" + "\n";
        }
        else if (WS.SO.speciality == 1)
        {
            decription += "speciality: " + "low gravity, allows for the player to negate weight penalties for kickback from firing weapons and slow falling. Allows a form of flying" + "\n";
        }
        else if (WS.SO.speciality == 2)
        {
            decription += "speciality: " + "gun and run, run shoot and aim at the same time" + "\n";
        }
        else if (WS.SO.speciality == 3)
        {
            decription += "speciality: " + "Wheels, allows for the player to negate weight penalties for the cost of momentum and not being able to jump" + "\n";
        }
        decription += "weight: " + WS.SO.weight + "\n";
        text.text = decription;
    }
}

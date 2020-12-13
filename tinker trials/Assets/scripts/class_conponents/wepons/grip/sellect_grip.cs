using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class sellect_grip : MonoBehaviour
{
    public wepon_grip WG;
    public wepon_Constructor WC;
    public TMP_Text text;
    public GameObject hover_pannel;

    private void Start()
    {
        WG = GetComponent<wepon_grip>();
    }
    public void selectGrip()
    {
        WC.grip_script.GO = WG.GO;
        WC.grip_script.generateGip();
    }
    public void Grip_decription()
    {
        hover_pannel.transform.position = transform.position;

        string decription = "";
        decription += "Name: " + WG.GO.name + "\n" + "\n";

        decription += "Grip angel: " + WG.GO.grip_angle + "\n";
        decription += "This effects your wepons recoil stability the closer to 90 is horizontal and the clser to 0 is vertical" + "\n" + "\n";



        if (WG.GO.speciality == 0)
        {
            decription += "Speciality: " + "none" + "\n" + "\n";
        }
        else if (WG.GO.speciality == 1)
        {
            decription += "Speciality: " + "stun bash, melee blows stun enemies" + "\n" + "\n";
        }
        else if (WG.GO.speciality == 2)
        {
            decription += "Speciality: " + "auto adjust, recoil is reduced over sustained fire" + "\n" + "\n";
        }
        decription += "Weight: " + WG.GO.weight + "\n" + "\n";
        decription += "This effects your players movement speed, reload and aim down sight speed" + "\n" + "\n";

        text.text = decription;
    }
}

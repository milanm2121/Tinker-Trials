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
        decription += "name: " + WG.GO.name + "\n";
        decription += "grip angel: " + WG.GO.grip_angle + "\n";

        if (WG.GO.speciality == 0)
        {
            decription += "speciality: " + "none" + "\n";
        }
        else if (WG.GO.speciality == 1)
        {
            decription += "speciality: " + "stun bash, melee blows stun enemies" + "\n";
        }
        else if (WG.GO.speciality == 2)
        {
            decription += "speciality: " + "auto adjust, recoil is reduced over sustained fire" + "\n";
        }
        decription += "weight: " + WG.GO.weight + "\n";
        text.text = decription;
    }
}

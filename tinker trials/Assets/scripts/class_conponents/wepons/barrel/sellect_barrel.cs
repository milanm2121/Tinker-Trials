using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class sellect_barrel : MonoBehaviour
{
    public wepon_barrel WB;
    public wepon_Constructor WC;
    public TMP_Text text;
    public GameObject hover_pannel;

    private void Start()
    {
        WB = GetComponent<wepon_barrel>();
    }
    public void selectBarrel()
    {

        WC.barrel_script.BO = WB.BO;
        WC.barrel_script.generateBarrel();
    }
    public void barrel_decription()
    {
        hover_pannel.transform.position = transform.position;

        string decription = "";
        decription += "Name: "+ WB.BO.name + "\n" + "\n";
        decription += "Range: "+ WB.BO.lenght + "\n" + "\n";
        decription += "This effects the projectile speed and distance before expirey" + "\n" +"\n";
        if (WB.BO.material == 1)
        {
            decription += "Material: " + "glass" + "\n";
            decription += "Adds extra range with lasers" + "\n" + "\n";
        }
        else if (WB.BO.material == 0)
        {
            decription += "Material: " + "wood" + "\n";
            decription += "Adds extra range to projectiles" + "\n" + "\n";
        }
        else if (WB.BO.material == 3)
        {
            decription += "Material: " + "plastic" + "\n" + "\n";
        }
        else if (WB.BO.material == 2)
        {
            decription += "Material: " + "metal" + "\n" + "\n";
        }
        

        if (WB.BO.specalty == 0)
        {
            decription += "Speciality: " + "none" + "\n" + "\n";
        }
        else if (WB.BO.specalty == 1)
        {
            decription += "Speciality: " + "Suppressor, suppresses sound" + "\n" + "\n";
        }
        else if (WB.BO.specalty == 2)
        {
            decription += "Speciality: " + "Overheat, increases damage over consistent firing" + "\n" + "\n";
        }
        decription += "Weight: "+WB.BO.weight + "\n";
        decription += "This effects your players movement speed, reload and aim down sight speed" + "\n" + "\n";
        text.text = decription;
    }
}

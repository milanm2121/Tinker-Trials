using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class sellect_barrel : MonoBehaviour
{
    public wepon_barrel WB;
    public wepon_Constructor WC;
    public TMP_Text text;
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
        string decription = "";
        decription += "name: "+ WB.BO.name + "\n";
        decription += "range: "+ WB.BO.lenght + "\n";
        if (WB.BO.material == 0)
        {
            decription += "material: " + "glass" + "\n";
        }
        else if (WB.BO.material == 1)
        {
            decription += "material: " + "wood" + "\n";
        }
        else if (WB.BO.material == 2)
        {
            decription += "material: " + "plastic" + "\n";
        }
        else if (WB.BO.material == 3)
        {
            decription += "material: " + "metal" + "\n";
        }

        if (WB.BO.specalty == 0)
        {
            decription += "speciality: " + "none" + "\n";
        }
        else if (WB.BO.specalty == 1)
        {
            decription += "speciality: " + "Suppressor, suppresses sound" + "\n";
        }
        else if (WB.BO.specalty == 2)
        {
            decription += "speciality: " + "Overheat, increases damage over consistent firing" + "\n";
        }
        decription += "weight: "+WB.BO.weight + "\n";
        text.text = decription;
    }
}

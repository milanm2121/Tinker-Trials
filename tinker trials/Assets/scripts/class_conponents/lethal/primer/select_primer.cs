using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class select_primer : MonoBehaviour
{
    public primer P;
    public leathal_construcor LC;
    public TMP_Text text;
    public GameObject hover_pannel;


    private void Start()
    {
        P = GetComponent<primer>();
    }
    public void selectPrimer()
    {
        LC.primer_script.PO = P.PO;
        LC.primer_script.GeneratePrimer();
    }
    public void Primer_decription()
    {
        hover_pannel.transform.position = transform.position;

        string decription = "";
        decription += "Name: " + P.PO.name + "\n" + "\n";
        

        if (P.PO.manual == false)
        {
            decription += "Fusetime: " + P.PO.timer + "\n";
            decription += "This dictates time in seconds befre detonation once thrown." + "\n" + "\n";

            decription += "manual: " + "no" + "\n";
        }
        else if (P.PO.manual == true)
        {
            decription += "Fusetime: " + "N/A" + "\n";
            decription += "This dictates time in seconds befre detonation once thrown." + "\n" + "\n";

            decription += "manual: " + "yes" + "\n";
        }
        decription += "This dictates weither you can detinate your throwable manualy." + "\n" + "\n";


        if (P.PO.speciality == 0)
        {
            decription += "speciality: " + "none" + "\n" + "\n";
        }
        else if (P.PO.speciality == 1)
        {
            decription += "speciality: " + "Vortex, sucks enemy in while fuse is going off" + "\n" + "\n";
        }
        else if (P.PO.speciality == 2)
        {
            decription += "speciality: " + "Mine, set and forget" + "\n" + "\n";
        }
        else if (P.PO.speciality == 3)
        {
            decription += "speciality: " + "Impact, explodes on impact" + "\n" + "\n";
        }
        text.text = decription;
    }
}

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
        decription += "name: " + P.PO.name + "\n";
        decription += "fusetime: " + P.PO.timer + "\n";

        if (P.PO.manual == false)
        {
            decription += "manual: " + "no" + "\n";
        }
        else if (P.PO.manual == true)
        {
            decription += "manual: " + "yes" + "\n";
        }

        if (P.PO.speciality == 0)
        {
            decription += "speciality: " + "none" + "\n";
        }
        else if (P.PO.speciality == 1)
        {
            decription += "speciality: " + "Vortex, sucks enemy in while fuse is going off" + "\n";
        }
        else if (P.PO.speciality == 2)
        {
            decription += "speciality: " + "Mine, set and forget" + "\n";
        }
        else if (P.PO.speciality == 3)
        {
            decription += "speciality: " + "Impact, explodes on impact" + "\n";
        }
        text.text = decription;
    }
}

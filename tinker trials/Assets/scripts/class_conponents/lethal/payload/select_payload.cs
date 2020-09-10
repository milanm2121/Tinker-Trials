using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class select_payload : MonoBehaviour
{
    public payload PL;
    public leathal_construcor LC;
    public TMP_Text text;
    private void Start()
    {
        PL = GetComponent<payload>();
    }
    public void selectPayload()
    {
        LC.payload_script.PO = PL.PO;
        LC.payload_script.generatePayload();
    }
    public void Payload_decription()
    {
        string decription = "";
        decription += "name: " + PL.PO.name + "\n";
        decription += "damage: " + PL.PO.damage + "\n";
        decription += "range: " + PL.PO.radious + "\n";

        if (PL.PO.element == 0)
        {
            decription += "element: " + "none" + "\n";
        }
        else if (PL.PO.element == 1)
        {
            decription += "element: " + "fire" + "\n";
        }
        else if (PL.PO.element == 2)
        {
            decription += "elemnt: " + "frost" + "\n";
        }
        else if (PL.PO.element == 3)
        {
            decription += "element: " + "electricity" + "\n";
        }
        else if (PL.PO.element == 3)
        {
            decription += "element: " + "wind" + "\n";
        }
        text.text = decription;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class select_payload : MonoBehaviour
{
    public payload PL;
    public leathal_construcor LC;
    public TMP_Text text;
    public GameObject hover_pannel;

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
        hover_pannel.transform.position = transform.position;

        string decription = "";
        decription += "Name: " + PL.PO.name + "\n"+"\n";

        decription += "Damage: " + PL.PO.damage + "\n";
        decription += "This effects the damage of your throwabels detonation " + "\n" + "\n";

        decription += "Damage Radious: " + PL.PO.radious + "\n";
        decription += "This effects the blast radious of your throwabels detonation " + "\n" + "\n";

        if (PL.PO.element == 0)
        {
            decription += "Element: " + "none" + "\n";
            decription += "Elemental effect have the abillity to apply statias effect on your targets" + "\n" + "\n";
        }
        else if (PL.PO.element == 1)
        {
            decription += "Element: " + "fire" + "\n";
            decription += "This elemental effect set your target on fire and applys damage tick of 5" + "\n" + "\n";
        }
        else if (PL.PO.element == 2)
        {
            decription += "Element: " + "frost" + "\n";
            decription += "This elemental effect slows your target the higher the frost damage is" + "\n" + "\n";
        }
        else if (PL.PO.element == 3)
        {
            decription += "Element: " + "earth" + "\n";
            decription += "This elemental graduly impaires your targets vision" + "\n" + "\n";
        }
        else if (PL.PO.element == 3)
        {
            decription += "Element: " + "electricity" + "\n";
            decription += "This elemental effect applyes a electrified statias effect causing your target to randomy flinch" + "\n" + "\n";
        }
        text.text = decription;
    }
}

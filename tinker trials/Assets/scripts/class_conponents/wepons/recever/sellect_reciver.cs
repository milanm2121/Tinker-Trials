using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class sellect_reciver : MonoBehaviour
{
    public wepon_reciver WR;
    public wepon_Constructor WC;
    public TMP_Text text;
    public GameObject hover_pannel;

    private void Start()
    {
        WR = GetComponent<wepon_reciver>();
    }
    public void selectReciveer()
    {
        WC.reciver_script.RO = WR.RO;
        WC.reciver_script.generateRecever();
        WC.position_parts();
    }
    public void recever_decription()
    {
        hover_pannel.transform.position = transform.position;

        string decription = "";
        decription += "name: " + WR.RO.name + "\n";

        if (WR.RO.element == 0)
        {
            decription += "element: " + "none" + "\n";
        }
        else if(WR.RO.element == 1)
        {
            decription += "element: " + "fire" + "\n";
        }
        else if (WR.RO.element == 2)
        {
            decription += "element: " + "frost" + "\n";
        }
        else if (WR.RO.element == 3)
        {
            decription += "element: " + "earth" + "\n";
        }
        else if(WR.RO.element == 0)
        {
            decription += "element: " + "electricity" + "\n";
        }


        decription += "firerate: " + WR.RO.fire_rate + "\n";
        decription += "wepontype: " + WR.RO.wepon_type + "\n";

        if (WR.RO.spciality == 0)
        {
            decription += "speciality: " + "none" + "\n";
        }
        else if (WR.RO.spciality == 1)
        {
            decription += "speciality: " + "Suck/Push, turns weapon into a physics gun allowing players to pick up and push junk around, Energy specialization from ammunition is needed to power weapon" + "\n";
        }
        else if (WR.RO.spciality == 2)
        {
            decription += "speciality: " + "Lazers, gun shoots lasers instead of bullet, Energy specialization from ammunition is needed to power weapon" + "\n";
        }
        else if (WR.RO.spciality == 3)
        {
            decription += "speciality: " + "Rotary, fire rate gradually speed up over time of sustained fire, not compatible with Energy specialization from ammunition" + "\n";
        }
        decription += "weight: " + WR.RO.weight + "\n";
        text.text = decription;
    }
}

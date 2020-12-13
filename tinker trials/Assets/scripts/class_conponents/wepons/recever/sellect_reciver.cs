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
        decription += "Name: " + WR.RO.name + "\n"+"\n";

        if (WR.RO.element == 0)
        {
            decription += "Element: " + "none" + "\n";
            decription += "Elemental effect have the abillity to apply statias effect on your targets" + "\n" + "\n";
        }
        else if(WR.RO.element == 1)
        {
            decription += "Element: " + "fire" + "\n";
            decription += "This elemental effect set your target on fire and applys damage tick of 5" + "\n" + "\n";
        }
        else if (WR.RO.element == 2)
        {
            decription += "Element: " + "frost" + "\n";
            decription += "This elemental effect slows your target the higher the frost damage is" + "\n" + "\n";
        }
        else if (WR.RO.element == 3)
        {
            decription += "Element: " + "earth" + "\n";
            decription += "This elemental graduly impaires your targets vision" + "\n" + "\n";
        }
        else if(WR.RO.element == 4)
        {
            decription += "Element: " + "electricity" + "\n";
            decription += "This elemental effect applyes a electrified statias effect causing your target to randomy flinch" + "\n" + "\n";
        }


        decription += "Firerate: " + WR.RO.fire_rate + "\n";
        decription += "This is the amount of rounds fired a second times x2" + "\n" + "\n";


        if (WR.RO.spciality == 0)
        {
            decription += "Speciality: " + "none" + "\n" + "\n";
        }
        else if (WR.RO.spciality == 1)
        {
            decription += "Speciality: " + "Suck/Push, turns weapon into a physics gun allowing players to pick up and push junk around, Energy specialization from ammunition is needed to power weapon" + "\n" + "\n";
        }
        else if (WR.RO.spciality == 2)
        {
            decription += "Speciality: " + "Lazers, gun shoots lasers instead of bullet, Energy specialization from ammunition is needed to power weapon" + "\n" + "\n";
        }
        else if (WR.RO.spciality == 3)
        {
            decription += "Speciality: " + "Rotary, fire rate gradually speed up over time of sustained fire, not compatible with Energy specialization from ammunition" + "\n" + "\n";
        }
        decription += "Weight: " + WR.RO.weight + "\n";
        decription += "This effects your players movement speed, reload and aim down sight speed" ;

        text.text = decription;
    }
}

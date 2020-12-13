/*
by:Milan Manji
script descrition: this script sets the text box description to desibe a part
and also sets the amunition object to be sellected for the class

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class sellect_amunition : MonoBehaviour
{
    public wepon_anumition WG;
    public wepon_Constructor WC;
    public TMP_Text text;
    public GameObject hover_pannel;

    private void Start()
    {
        WG = GetComponent<wepon_anumition>();
    }
    public void selectAmunition()
    {
        WC.anumition_script.AO = WG.AO;
        WC.anumition_script.generateObject();
    }
    public void Amunition_decription()
    {
        hover_pannel.transform.position = transform.position;

        string decription = "";
        decription += "Name: " + WG.AO.name + "\n" + "\n";
        decription += "Damage: " + WG.AO.damage + "\n";
        decription += "This is the amount of damage your projectile and impact blast does " + "\n" + "\n";
        decription += "Blast radious: " + WG.AO.blast_radius + "\n"; 
        decription += "This is the raidous of effect that your projectile impact has" + "\n" + "\n";

        if (WG.AO.element == 0)
        {
            decription += "Element: " + "none" + "\n";
            decription += "Elemental effect have the abillity to apply statias effect on your targets" + "\n" + "\n";
        }
        else if (WG.AO.element == 1)
        {
            decription += "Element: " + "fire" + "\n";
            decription += "This elemental effect set your target on fire and applys damage tick of 5" + "\n" + "\n";
        }
        else if(WG.AO.element == 2)
        {
            decription += "Element: " + "frost" + "\n";
            decription += "This elemental effect slows your target the higher the frost damage is" + "\n" + "\n";

        }
        else if (WG.AO.element == 3)
        {
            decription += "Element: " + "earth" + "\n";
            decription += "This elemental graduly impaires your targets vision" + "\n" + "\n";
        }
        else if (WG.AO.element == 4)
        {
            decription += "Element: " + "electricity" + "\n";
            decription += "This elemental effect applyes a electrified statias effect causing your target to randomy flinch" + "\n" + "\n";
        }



        decription += "Base range: " + WG.AO.range + "\n";
        decription += "This dictates your projectiels range and speed "+"\n"+"\n";

        decription += "Rounds : " + WG.AO.rounds + "\n";
        decription += "This dictates the rounds in your magazine" + "\n" + "\n";


        if (WG.AO.speciality == 0)
        {
            decription += "Speciality: " + "none" + "\n" + "\n";
        }
        else if (WG.AO.speciality == 1)
        {
            decription += "Speciality: " + "Buckshot, gun shoots buckshot spread" + "\n" + "\n";
        }
        else if (WG.AO.speciality == 2)
        {
            decription += "Speciality: " + "Energy, Powers the Lasers and Push/Pull Receivers" + "\n" + "\n";
        }
        else if (WG.AO.speciality == 3)
        {
            decription += "Speciality: " + "Fastmags, reload faster" + "\n" + "\n";
        }
        decription += "Weight: " + WG.AO.weight + "\n";
        decription += "This effects your players movement speed, reload and aim down sight speed" + "\n" + "\n";
        text.text = decription;
    }
}

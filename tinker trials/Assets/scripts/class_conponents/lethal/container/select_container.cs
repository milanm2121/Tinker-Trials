using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class select_container : MonoBehaviour
{
    public container C;
    public leathal_construcor LC;
    public TMP_Text text;
    public GameObject hover_pannel;

    private void Start()
    {
        C = GetComponent<container>();
    }
    public void selectContainer()
    {
        LC.container_script.CO = C.CO;
        LC.container_script.generateContainer();
    }
    public void Container_decription()
    {
        hover_pannel.transform.position = transform.position;

        string decription = "";
        decription += "Name: " + C.CO.name + "\n"+"\n";
        

        if (C.CO.sticky == false)
        {
            decription += "Sticky: " + "no" + "\n";
        }
        else if (C.CO.sticky == true)
        {
            decription += "Sticky: " + "yes" + "\n";
        }
        decription += "This dictaes if your throwabel stick to surfaces " + "\n"+"\n";

        if (C.CO.speciality == 0)
        {
            decription += "Speciality: " + "none" + "\n" + "\n";
        }
        else if (C.CO.speciality == 1)
        {
            decription += "Speciality: " + "Knife, damages and sticks to players on collision" + "\n" + "\n";
        }
        else if (C.CO.speciality == 2)
        {
            decription += "Speciality: " + "Seeker, follows the closest enemy" + "\n" + "\n";
        }
        else if (C.CO.speciality == 3)
        {
            decription += "Speciality: " + "Shrapnel, creates junk on explosion" + "\n" + "\n";
        }
        decription += "Weight: " + C.CO.weight + "\n";
        decription += "This effects your projectiles throw distance";


        text.text = decription;


    }
}

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
        decription += "name: " + C.CO.name + "\n";
        

        if (C.CO.sticky == false)
        {
            decription += "sticky: " + "no" + "\n";
        }
        else if (C.CO.sticky == true)
        {
            decription += "sticky: " + "yes" + "\n";
        }

        if (C.CO.speciality == 0)
        {
            decription += "speciality: " + "none" + "\n";
        }
        else if (C.CO.speciality == 1)
        {
            decription += "speciality: " + "Knife, damages and sticks to players on collision" + "\n";
        }
        else if (C.CO.speciality == 2)
        {
            decription += "speciality: " + "Seeker, follows the closest enemy" + "\n";
        }
        else if (C.CO.speciality == 3)
        {
            decription += "speciality: " + "Shrapnel, creates junk on explosion" + "\n";
        }
        decription += "weight: " + C.CO.weight + "\n";

        
        text.text = decription;


    }
}

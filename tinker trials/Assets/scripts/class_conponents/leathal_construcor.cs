/*
by:Milan Manji
script descrition: this script important for generating the lethal throwables and works in the same sence as the wepon constructor use that as a refrence

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leathal_construcor : MonoBehaviour
{
    public workshop_interphase WI;

    public GameObject primer;
    public primer primer_script;

    public GameObject Payload;
    public payload payload_script;

    public GameObject container;
    public container container_script;

    public primer_object defalt_primer;
    public payload_object defalt_payload;
    public container_object defalt_container;

    public GameObject primer_menu;
    public GameObject payload_menu;
    public GameObject container_menu;

    public List<primer_object> primers;
    public List<payload_object> payloads;
    public List<container_object> containers;

    int active_list = 0;
    public GameObject decription;

    public List<GameObject> buttons;

    public void selectclass(class_class.Class Class_)
    {
        if (Class_.Lethal.primer == null || Class_.Lethal.payload == null || Class_.Lethal.container == null)
        {
            primer_script.PO = defalt_primer;
            payload_script.PO = defalt_payload;
            container_script.CO = defalt_container;
        }
        else
        {
            primer_script.PO = Class_.Lethal.primer;
            payload_script.PO = Class_.Lethal.payload;
            container_script.CO = Class_.Lethal.container;
        }

        primer_script.GeneratePrimer();
        payload_script.generatePayload();
        container_script.generateContainer();
    }
    private void Update()
    {
        if (WI.workshop_Phase == 2)
        {
            for (int i = 0; buttons.Count > i; i++)
            {
                buttons[i].SetActive(true);
                primer.SetActive(true);
                Payload.SetActive(true);
                container.SetActive(true);
                decription.SetActive(false);
            }
            active_list = 0;
        }
        else if (WI.workshop_Phase == 3)
        {
            for (int i = 0; buttons.Count > i; i++)
            {
                buttons[i].SetActive(false);
                primer.SetActive(false);
                Payload.SetActive(false);
                container.SetActive(false);
                decription.SetActive(true);
            }
        }
        if (active_list == 1)
        {
            primer_menu.SetActive(true);
        }
        else
        {
            primer_menu.SetActive(false);
        }
        if (active_list == 2)
        {
            payload_menu.SetActive(true);
        }
        else
        {
            payload_menu.SetActive(false);
        }
        if (active_list == 3)
        {
            container_menu.SetActive(true);
        }
        else
        {
            container_menu.SetActive(false);
        }
    }

    public void change_primer()
    {
        active_list = 1;
        WI.workshop_Phase = 3;
    }
    public void change_payload()
    {
        active_list = 2;
        WI.workshop_Phase = 3;
    }
    public void change_container()
    {
        active_list = 3;
        WI.workshop_Phase = 3;
    }

}

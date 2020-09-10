/*
by:Milan Manji
script descrition: this script is used for generating cheastplates in the menu, find refrence to this script in the amunition section because of its basicly the same

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cheastplate_sellection : MonoBehaviour
{
    public GameObject[] cheastplates;
    public armour_constructor AC;
    public int selected_object;
    int page = 0;
    // Start is called before the first frame update
    void Start()
    {
        populatemenue();
    }

    // Update is called once per frame
    public void next_page()
    {
        if (page * 9 < AC.cheastplates.Count)
        {
            page++;
            populatemenue();
        }
    }

    public void previous_page()
    {
        if (page != 0)
        {
            page--;
            populatemenue();
        }
    }

    void populatemenue()
    {
        for (int i = 0; 9 > i; i++)
        {
            if (AC.cheastplates.Count > (9 * page) + i)
            {
                cheastplates[i].GetComponent<cheastplate>().CPO = AC.cheastplates[(9 * page) + i];
                cheastplates[i].GetComponent<cheastplate>().gerateCheastPlate();
                cheastplates[i].gameObject.GetComponent<MeshCollider>().sharedMesh = AC.headgear[(9 * page) + i].mesh;
                cheastplates[i].SetActive(true);
            }
            else
            {
                cheastplates[i].SetActive(false);
            }
        }
    }
}

/*
by:Milan Manji
script descrition: this script is used for generating boots in the menufind refrence to this script in the amunition section because of its basicly the same

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boots_sellection : MonoBehaviour
{
    public GameObject[] Boots;
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
        if (page * 9 < AC.boots.Count)
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
            if (AC.headgear.Count > (9 * page) + i)
            {
                Boots[i].GetComponent<boots_scripts>().BO = AC.boots[(9 * page) + i];
                Boots[i].GetComponent<boots_scripts>().generateBoots();
                Boots[i].gameObject.GetComponent<MeshCollider>().sharedMesh = AC.headgear[(9 * page) + i].mesh;
                Boots[i].SetActive(true);
            }
            else
            {
                Boots[i].SetActive(false);
            }
        }
    }
}

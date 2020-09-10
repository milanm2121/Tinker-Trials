/*
by:Milan Manji
script descrition: this script is used for generating headgear in the menufind refrence to this script in the amunition section because of its basicly the same

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headgear_sellection : MonoBehaviour
{
    public GameObject[] headgear;
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
        if (page * 9 < AC.headgear.Count)
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
                headgear[i].GetComponent<headgear>().HGO = AC.headgear[(9 * page) + i];
                headgear[i].GetComponent<headgear>().Generate_headGear();
                headgear[i].gameObject.GetComponent<MeshCollider>().sharedMesh = AC.headgear[(9 * page) + i].mesh;
                headgear[i].SetActive(true);
            }
            else
            {
                headgear[i].SetActive(false);
            }
        }
    }
}

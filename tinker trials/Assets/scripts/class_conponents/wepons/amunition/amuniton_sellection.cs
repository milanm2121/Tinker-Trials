/*
by:Milan Manji
script descrition: this script set the amunition menueto load paerts from the list saved

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class amuniton_sellection : MonoBehaviour
{
    public GameObject[] amunition;
    public wepon_Constructor WC;
    public int selected_object;
    int page = 0;
    // Start is called before the first frame update
    void Start()
    {
        populatemenue();
    }

    // loads the next pahe
    public void next_page()
    {
        if (page * 9 < WC.amunition_types.Count)
        {
            page++;
            populatemenue();
        }
    }
    // loads the previous page
    public void previous_page()
    {
        if (page != 0)
        {
            page--;
            populatemenue();
        }
    }

    // loads objects baised on the players invtery list stored in the wepon componet
    void populatemenue()
    {
        for (int i = 0; 9 > i; i++)
        {
            if (WC.amunition_types.Count > (9 * page) + i)
            {
                amunition[i].GetComponent<wepon_anumition>().AO = WC.amunition_types[(9 * page) + i];
                amunition[i].GetComponent<wepon_anumition>().generateObject();
                amunition[i].gameObject.GetComponent<MeshCollider>().sharedMesh = WC.amunition_types[(9 * page) + i].mesh;
                amunition[i].SetActive(true);
            }
            else
            {
                amunition[i].SetActive(false);
            }
        }
    }
}

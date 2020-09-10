using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrel_selection : MonoBehaviour
{
    public GameObject[] barrels;
    public wepon_Constructor WC;
    public int selected_object;
    int page=0;
    // Start is called before the first frame update
    void Start()
    {
        populatemenue();
    }

    // Update is called once per frame
    public void next_page()
    {
        if (page * 9 < WC.barrels.Count)
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
            if (WC.barrels.Count > (9 * page) + i)
            {
                barrels[i].GetComponent<wepon_barrel>().BO = WC.barrels[(9 * page) + i];
                barrels[i].GetComponent<wepon_barrel>().generateBarrel();
                barrels[i].gameObject.GetComponent<MeshCollider>().sharedMesh = WC.barrels[(9 * page) + i].mesh;
                barrels[i].SetActive(true);
            }
            else
            {
                barrels[i].SetActive(false);
            }
        }
    }
}

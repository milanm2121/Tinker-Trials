using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grip_sellection : MonoBehaviour
{
    public GameObject[] grips;
    public wepon_Constructor WC;
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
        if (page * 9 < WC.grips.Count)
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
            if (WC.recevers.Count > (9 * page) + i)
            {
                grips[i].GetComponent<wepon_grip>().GO = WC.grips[(9 * page) + i];
                grips[i].GetComponent<wepon_grip>().generateGip();
                grips[i].gameObject.GetComponent<MeshCollider>().sharedMesh = WC.grips[(9 * page) + i].meshshape;
                grips[i].SetActive(true);
            }
            else
            {
                grips[i].SetActive(false);
            }
        }
    }
}

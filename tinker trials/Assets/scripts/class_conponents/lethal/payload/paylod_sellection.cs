using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paylod_sellection : MonoBehaviour
{
    public GameObject[] payloads;
    public leathal_construcor LC;
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
        if (page * 9 < LC.payloads.Count)
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
            if (LC.payloads.Count > (9 * page) + i)
            {
                payloads[i].GetComponent<payload>().PO = LC.payloads[(9 * page) + i];
                payloads[i].GetComponent<payload>().generatePayload();
                payloads[i].SetActive(true);
            }
            else
            {
                payloads[i].SetActive(false);
            }
        }
    }
}

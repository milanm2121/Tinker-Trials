using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class primer_sellection : MonoBehaviour
{
    public GameObject[] primers;
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
        if (page * 9 < LC.primers.Count)
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
            if (LC.primers.Count > (9 * page) + i)
            {
                primers[i].GetComponent<primer>().PO = LC.primers[(9 * page) + i];
                primers[i].GetComponent<primer>().GeneratePrimer();
                primers[i].gameObject.GetComponent<MeshCollider>().sharedMesh = LC.primers[(9 * page) + i].mesh;
                primers[i].SetActive(true);
            }
            else
            {
                primers[i].SetActive(false);
            }
        }
    }
}
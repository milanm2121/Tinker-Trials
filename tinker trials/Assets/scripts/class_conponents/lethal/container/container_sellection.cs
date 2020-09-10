using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class container_sellection : MonoBehaviour
{
    public GameObject[] containers;
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
        if (page * 9 < LC.containers.Count)
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
                containers[i].GetComponent<container>().CO = LC.containers[(9 * page) + i];
                containers[i].GetComponent<container>().generateContainer();
                containers[i].gameObject.GetComponent<MeshCollider>().sharedMesh = LC.containers[(9 * page) + i].mesh;
                containers[i].SetActive(true);
            }
            else
            {
                containers[i].SetActive(false);
            }
        }
    }
}
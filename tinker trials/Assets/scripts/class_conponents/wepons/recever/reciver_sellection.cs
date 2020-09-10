using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reciver_sellection : MonoBehaviour
{
    public GameObject[] recivers;
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
        if (page * 9 < WC.recevers.Count)
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
            if (WC.recevers.Count >= (9 * page) + i)
            {
                recivers[i].GetComponent<wepon_reciver>().RO = WC.recevers[(9 * page) + i];
                recivers[i].GetComponent<wepon_reciver>().generateRecever();
                recivers[i].gameObject.GetComponent<MeshCollider>().sharedMesh = WC.recevers[(9 * page) + i].mesh;
                recivers[i].SetActive(true);
            }
            else
            {
                recivers[i].SetActive(false);
            }
        }
    }
}

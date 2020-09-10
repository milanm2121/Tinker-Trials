using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class support_sellection : MonoBehaviour
{
    public GameObject[] supports;
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
        if (page * 9 < WC.supports.Count)
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
            if (WC.supports.Count > (9 * page) + i)
            {
                supports[i].GetComponent<wepon_suport>().SO = WC.supports[(9 * page) + i];
                supports[i].GetComponent<wepon_suport>().generateSuport();
                supports[i].gameObject.GetComponent<MeshCollider>().sharedMesh = WC.supports[(9 * page) + i].mesh;
                supports[i].SetActive(true);
            }
            else
            {
                supports[i].SetActive(false);
            }
        }
    }
}

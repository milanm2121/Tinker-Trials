using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scope_selection : MonoBehaviour
{
    public GameObject[] scopes;
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
        if (page * 9 < WC.scopes.Count)
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
            if (WC.scopes.Count > (9 * page) + i)
            {
                scopes[i].GetComponent<wepon_scope>().SO = WC.scopes[(9 * page) + i];
                scopes[i].GetComponent<wepon_scope>().generateScope();
                scopes[i].gameObject.GetComponent<MeshCollider>().sharedMesh = WC.scopes[(9 * page) + i].mesh;
                scopes[i].SetActive(true);
            }
            else
            {
                scopes[i].SetActive(false);
            }
        }
    }
}

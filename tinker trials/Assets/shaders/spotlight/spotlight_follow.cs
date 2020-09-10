using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spotlight_follow : MonoBehaviour
{
    public Material mat;
    public string propertname;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
            mat.SetVector(propertname, player.position);
    }
}

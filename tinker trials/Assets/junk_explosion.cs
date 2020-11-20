using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class junk_explosion : MonoBehaviour
{
    // Start is called before the first frame update
    public bool un_perant;
    void Start()
    {
        if(un_perant)
            transform.DetachChildren();
    }
    
   
}

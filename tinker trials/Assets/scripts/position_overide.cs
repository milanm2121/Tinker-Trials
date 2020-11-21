using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class position_overide : MonoBehaviour
{
    public Transform location;
    public bool copy_rotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = location.position;
        if (copy_rotation == true)
        {
            transform.rotation = location.rotation;
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armour_position : MonoBehaviour
{
    public Transform location;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = location.position;
        transform.rotation = location.rotation;
    }
}

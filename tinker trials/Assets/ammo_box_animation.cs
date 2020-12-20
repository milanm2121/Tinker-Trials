using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammo_box_animation : MonoBehaviour
{
    float start_Y_pos;
    // Start is called before the first frame update
    void Start()
    {
        start_Y_pos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x,start_Y_pos + Mathf.Sin(Time.time*2)/2,transform.position.z);
        transform.Rotate(Vector3.up, 15*Time.deltaTime);
    }
}

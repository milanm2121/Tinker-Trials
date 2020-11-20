using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlerRM : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyInputs.KP.forward))// if the key is called // all basic movemment functions 
        {
            transform.position += Vector3.forward / 2;//moves the player 
        }
         if (Input.GetKey(KeyInputs.KP.backwards))
        {
            transform.position += -Vector3.forward / 2;
        }
         if (Input.GetKey(KeyInputs.KP.left))
        {
            transform.position += Vector3.left / 2;
        }
         if (Input.GetKey(KeyInputs.KP.right))
        {
            transform.position += Vector3.right / 2;
        }
         if (Input.GetKeyDown(KeyInputs.KP.jump))
        {
            transform.position += Vector3.up / 2;
        }
    }
}

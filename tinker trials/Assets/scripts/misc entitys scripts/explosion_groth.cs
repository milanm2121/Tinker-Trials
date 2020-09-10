using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion_groth : MonoBehaviour
{
    public float raidious;
    // Start is called before the first frame update
    void Start()
    {
        
        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(raidious, raidious, raidious) * Time.deltaTime *10;
        if (transform.localScale.x > raidious)
        {
            Destroy(gameObject);
        }
    }
}

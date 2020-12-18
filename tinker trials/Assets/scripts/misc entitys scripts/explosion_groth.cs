using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion_groth : MonoBehaviour
{
    public float raidious;
    public GameObject particals;
    GameObject x;
    // Start is called before the first frame update
    void Start()
    {
        
        transform.localScale = Vector3.zero;
        x=Instantiate(particals,transform.position,transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(raidious, raidious, raidious) * Time.deltaTime *10;
        x.transform.GetChild(0).localScale = transform.localScale;
        x.transform.GetChild(1).transform.localScale = transform.localScale;
        if (transform.localScale.x > raidious)
        {
            
            
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class damage_numbers : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(transform.parent.gameObject,2);
        GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-1, 2), Random.Range(-1, 2), Random.Range(-1, 2));
    }

    // Update is called once per frame
    

    public void damage(int damage,int element)
    {
        GetComponent<TMP_Text>().text = damage.ToString();
        if (element == 0)
        {
            GetComponent<TMP_Text>().color = Color.white;
        }
        if (element == 1)
        {
            GetComponent<TMP_Text>().color = Color.red;
        }
        if (element == 2)
        {
            GetComponent<TMP_Text>().color = Color.blue;
        }
        if (element == 3)
        {
            GetComponent<TMP_Text>().color = Color.green;
        }
        if (element == 4)
        {
            GetComponent<TMP_Text>().color = Color.yellow;
        }
        
        
    }
    private void Update()
    {
        transform.parent.LookAt(Camera.allCameras[0].transform);
    }
}

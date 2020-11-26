using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class interactabel : MonoBehaviour
{
    public bool reload_scean;
    public bool spawn_dummys;
    public bool load_workshop;
    public bool exit;
    public GameObject Text;
    GameObject dummy;
    Transform[] dummyspawns;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        

    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (reload_scean == true)
            {
                SceneManager.LoadScene("Range");
            }
            else if (load_workshop == true)
            {
                SceneManager.LoadScene("workshop form firing range");

            }
            else if (spawn_dummys == true)
            {

            }
            else if (exit == true)
            {
                SceneManager.LoadScene("main menu");

            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            Text.SetActive(true);
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Text.SetActive(false);
        }
    }
}

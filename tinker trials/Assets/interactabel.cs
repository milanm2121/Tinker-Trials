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
    public GameObject dummy;
    public Transform[] dummyspawns;
    public GameObject Rails;
    // Start is called before the first frame update
    void Start()
    {
        Text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        

    }
    private void OnTriggerStay(Collider other)
    {
        if ((other.tag == "player" || other.tag=="Player" )&& Input.GetKeyDown(KeyCode.E))
        {
            Cursor.lockState = CursorLockMode.None;
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
                turnOff();
                //Rails.SetActive(false);// turns off rails when dummys spawn
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
   public void turnOff()
    {
        if (Rails.activeSelf)
        {
            Rails.SetActive(false);// turns off rails when dummys spawn
            
            for (int i = 0; dummyspawns.Length > i; i++)
            {
                Instantiate(dummy, dummyspawns[i]);
            }
        }
        else
        {
            Rails.SetActive(true);
            for (int i = 0; dummyspawns.Length > i; i++)
            {
                if (dummyspawns[i].childCount > 0)
                {
                    Destroy(dummyspawns[i].GetChild(0).gameObject);
                }
            }
        }
       
    }
    
}

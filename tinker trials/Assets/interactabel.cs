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
    public bool rail;
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
        if (other.tag=="Player" && Input.GetKey(KeyCode.E))
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
            else if (spawn_dummys == false)
            {

                //Rails.SetActive(false);// turns off rails when dummys spawn
            }
            else if (exit == true)
            {
                SceneManager.LoadScene("main menu");

            }
            else if (rail == true)
            {
                //Rails.SetActive(true);// turns off rails when dummys spawn
                turnOff();
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
        if(rail == false)
        {
            Rails.SetActive(false);// turns off rails when dummys spawn
        }

       
    }
    
}

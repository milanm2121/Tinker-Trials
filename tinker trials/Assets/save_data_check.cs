using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class save_data_check : MonoBehaviour
{
    public Button[] buttons_to_activate;
    public Button workshop_button;
    public Image arrow;
    public Transform arrow_pos1;
    public Transform arrow_pos2;

    void Start()
    {
        StartCoroutine(wait_for_load());
    }

    // Update is called once per frame
    void Update()
    {
        if (save_system.has_save_data == false)
        {

            ColorBlock x = workshop_button.colors;
            float flash = (Mathf.Sin(Time.time*5) + 1)/2;
            Debug.Log(flash);
            x.normalColor = Color.Lerp(Color.white, Color.yellow, flash);
          //  x.highlightedColor = Color.yellow * Mathf.Sin(Time.deltaTime);
            workshop_button.colors = x;

            arrow.transform.position = Vector3.Lerp(arrow_pos1.position,arrow_pos2.position, flash);
        }
    }
    IEnumerator wait_for_load()
    {
        yield return new WaitForEndOfFrame();
        if (save_system.has_save_data == false)
        {
            for (int i = 0;buttons_to_activate.Length>i ; i++)
            {
                buttons_to_activate[i].interactable = false;
                
            }
            
        }
        else
        {
            for (int i = 0; buttons_to_activate.Length > i; i++)
            {
                buttons_to_activate[i].interactable = true;
            }
            arrow.gameObject.SetActive(false);
        }

        
    }
}

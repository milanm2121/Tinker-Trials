using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class multiplayer_menue_maneger : MonoBehaviourPunCallbacks
{
    public GameObject[] active_on_online_buttons;
    public GameObject connect_button;
    public GameObject main_menu_button;
    public GameObject usernameinputfeild;
    public multiplayer_launcher ML;
    public GameObject join_game_button;

    // Start is called before the first frame update
    void Start()
    {
        ML = GameObject.Find("multiplayer_launcher").GetComponent<multiplayer_launcher>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PhotonNetwork.IsConnectedAndReady == true)
        {
            for(int i=0;active_on_online_buttons.Length>i; i++)
            {
                active_on_online_buttons[i].SetActive(true);
            }
            connect_button.SetActive(false);
            main_menu_button.SetActive(false);
            usernameinputfeild.SetActive(false);
           
            
            if (PhotonNetwork.IsMasterClient == false && PhotonNetwork.CurrentRoom != null)
            {
                join_game_button.SetActive(false);
            }
            else 
            {
                join_game_button.SetActive(true);
            }
        }
        else
        {
            for (int i = 0; active_on_online_buttons.Length > i; i++)
            {
                active_on_online_buttons[i].SetActive(false);
            }
            connect_button.SetActive(true);
            main_menu_button.SetActive(true);
            usernameinputfeild.SetActive(true);
        }

       
    }

    
    
}

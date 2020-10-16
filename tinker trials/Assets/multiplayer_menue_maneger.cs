using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class multiplayer_menue_maneger : MonoBehaviourPunCallbacks
{
    public GameObject[] active_on_online_buttons;
    public GameObject connect_button;
    public multiplayer_maneger MM;


    // Start is called before the first frame update
    void Start()
    {
        MM = GameObject.Find("multiplayer_maneger").GetComponent<multiplayer_maneger>();
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
        }
        else
        {
            for (int i = 0; active_on_online_buttons.Length > i; i++)
            {
                active_on_online_buttons[i].SetActive(false);
            }
            connect_button.SetActive(true);
        }
    }

    
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class multiplayer_lobby_maneger : MonoBehaviourPunCallbacks
{
    public TMP_Text[] playerIDs;


    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PhotonNetwork.CurrentRoom != null)
        {


            for (int i = 0; PhotonNetwork.CurrentRoom.PlayerCount > i; i++)
            {

                playerIDs[i].text = PhotonNetwork.PlayerList[i].NickName;
                if (PhotonNetwork.PlayerList[i].IsMasterClient)
                {
                    playerIDs[i].color = Color.blue;
                }
            }
            for (int i = PhotonNetwork.CurrentRoom.PlayerCount; playerIDs.Length > i; i++)
            {
                playerIDs[i].text = "finding players...";
            }
         
        }
    }
    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        if (PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount>1)
        {
            PhotonNetwork.SetMasterClient(PhotonNetwork.CurrentRoom.Players[2]);
        }
    }

}

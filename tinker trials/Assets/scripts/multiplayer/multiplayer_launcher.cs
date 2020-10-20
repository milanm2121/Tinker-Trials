using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class multiplayer_launcher : MonoBehaviourPunCallbacks
{
    public static multiplayer_launcher instance;
    public string gamevirsion;

    [Tooltip("The maximum number of players per room. When a room is full, it can't be joined by new players, and so new room will be created")]
    [SerializeField]
    private byte maxPlayersPerRoom = 4;

    bool Looking_for_game=false;

    [SerializeField]
    public TMP_Text party_room_ID;
    int PartyID;

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        if (gamevirsion != "")
        {
            PhotonNetwork.GameVersion = gamevirsion;
        }
        else
        {
            PhotonNetwork.GameVersion = "1";
        }
        

    }

    private void Update()
    {

        party_room_ID.text = "Party ID: " + PartyID.ToString();
       
    }


    public void ConnectToMasterServer()
    {
        if (PhotonNetwork.IsConnected)
        {
            Debug.Log("your already connect to the " + PhotonNetwork.CloudRegion + "servers");
        }
        else
        {
            PhotonNetwork.ConnectUsingSettings();
            Debug.Log("connecting...");
        }
    }



    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("you are connected to the " + PhotonNetwork.CloudRegion + " server");
    }
    public void Disconnect()
    {
        if (PhotonNetwork.IsConnected == true)
        {
            PhotonNetwork.Disconnect();
            Debug.Log("disconecting...");
            PartyID = 0;
        }
        else
        {
            Debug.Log("you are already disconnected form any servers");
        }
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        base.OnDisconnected(cause);
        Debug.Log("you have disconected form the server");
    }


    public void Join_Room()
    {
        Looking_for_game = true;
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);
        if (Looking_for_game == true)
        {
            Debug.Log("could not join room, creating room");
            create_room();
        }
        else
        {
            Debug.Log("could not join room, because it dosent exist or is full");
        }
    }

    public void host_Party()
    {
        if (PhotonNetwork.CurrentRoom == null)
        {
            Looking_for_game = false;
            int Party_room_ID_num = Random.Range(0, 10000);
            RoomOptions roomops = new RoomOptions { IsVisible = false, IsOpen = true, MaxPlayers = maxPlayersPerRoom };


            PhotonNetwork.CreateRoom("Party: " + Party_room_ID_num, roomops);
            party_room_ID.text = "Party: " + Party_room_ID_num;
            PartyID = Party_room_ID_num;
        }
        else
        {
            Debug.Log("you are already in a party");
        }

    }

    public void join_party()
    {
        PhotonNetwork.JoinRoom("Party: " + PartyID);
        Debug.Log("joining party");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);
        Debug.Log("failed to join party" + ", Party: " + PartyID);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("joined party");
    }

    public void Set_serch_Party_ID(string value)
    {
        PartyID = int.Parse(value);
    }

    public void create_room()
    {
        int roomnum = Random.Range(0, 10000);
        RoomOptions roomops = new RoomOptions { IsVisible = true, IsOpen = true, MaxPlayers = maxPlayersPerRoom };


        PhotonNetwork.CreateRoom("Room " + roomnum, roomops);

    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        if (Looking_for_game == true)
        {
            create_room();
        }
        else
        {
            host_Party();
        }
        
    }

    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        Debug.Log("Created Room");
        if(Looking_for_game==true)
            PhotonNetwork.LoadLevel("multiplayer_lobby");
    }
}

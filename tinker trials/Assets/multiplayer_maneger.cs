using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class multiplayer_maneger : MonoBehaviourPunCallbacks
{
    public static multiplayer_maneger instance;
    public string gamevirsion;

    [Tooltip("The maximum number of players per room. When a room is full, it can't be joined by new players, and so new room will be created")]
    [SerializeField]
    private byte maxPlayersPerRoom = 4;

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

        DontDestroyOnLoad(this.gameObject);
        if (instance == null)
        {
            instance = this;

        }
        else
        {
            Destroy(this);
        }

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
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);
        Debug.Log("could not join room, creating room");
        create_room();
    }

    public void create_room()
    {
        int roomnum = Random.Range(0, 1000);
        RoomOptions roomops = new RoomOptions { IsVisible = true, IsOpen = true, MaxPlayers = maxPlayersPerRoom };


        PhotonNetwork.CreateRoom("Room "+ roomnum,roomops);

    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        create_room();
    }

    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        Debug.Log("Created Room" );
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

using TMPro;
using Photon.Chat;
using ExitGames.Client.Photon;
using UnityEngine.SceneManagement;

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

    

    //sets the game virsion
    private void Awake()
    {
        bool x = PhotonPeer.RegisterType(typeof(List<player_inventory.saved_object>), (byte)'A', save_system.SeriliseClasses, save_system.DeSeriliseClassesPUN);

        if (x == true)
        {
            Debug.Log("regestered Type");
        }
        else
        {
            Debug.Log("cant regester Type");
        }

        PhotonNetwork.AutomaticallySyncScene = false;
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
        //hides and shows the party id
        if (PhotonNetwork.CurrentRoom != null) {
            party_room_ID.gameObject.SetActive(true);
            party_room_ID.text = "Party ID: " + PartyID.ToString();
        }
        else
        {
            party_room_ID.gameObject.SetActive(false);
        }
        
    }


    //connects you to the master servers
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

    //disconects you from rooms and master server
    public void Disconnect()
    {
        if (PhotonNetwork.IsConnected == true)
        {
            if (PhotonNetwork.CurrentRoom != null)
            {
                PhotonNetwork.LeaveRoom();
            }

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
        //is the player in a party or not
        if (PhotonNetwork.CurrentRoom == null)//not in party
        {
            //quick play
            
            PhotonNetwork.JoinRandomRoom();
        }
        else//is in party
        {
            StartCoroutine(leave_with_party());
        }
    }
    
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);
        if (Looking_for_game == true)
        {
            //creates room if you fail to find one
            Debug.Log("could not join room, creating room");
            create_room();
        }
        else
        {
            Debug.Log("could not join room, because it dosent exist or is full");
        }
    }

    //used to host a party
    public void host_Party()
    {
        if (PhotonNetwork.CurrentRoom == null)
        {
            Looking_for_game = false;
            int Party_room_ID_num = Random.Range(0, 10000);
            RoomOptions roomops = new RoomOptions { IsVisible = false, IsOpen = true, MaxPlayers = maxPlayersPerRoom };
            roomops.PublishUserId = true;

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

    public void leave_party()
    {
        if (PhotonNetwork.CurrentRoom != null)
        {
            PhotonNetwork.LeaveRoom();
            Debug.Log("you have left the party");
        }
        else
        {
            Debug.Log("you are not in a party to leave");
        }
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
        if(!PhotonNetwork.IsMasterClient && Looking_for_game==true)
            PhotonNetwork.LoadLevel("multiplayer_lobby");
    }

    public void Set_serch_Party_ID(string value)
    {
        if(value!="")
            PartyID = int.Parse(value);
    }

    public void create_room()
    {

        //quick play
        int roomnum = Random.Range(0, 10000);
        RoomOptions roomops = new RoomOptions { IsVisible = true, IsOpen = true, MaxPlayers = maxPlayersPerRoom };
        PhotonNetwork.CreateRoom("Room " + roomnum, roomops, null, Get_userIDs());




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

    string[] Get_userIDs()
    {
        string[] userID= new string[0];
        if (PhotonNetwork.CurrentRoom != null)
        {
            userID = new string[multiplayer_party_maneger.MPM.Party_user_id.Length];

            for (int i = 0; multiplayer_party_maneger.MPM.Party_user_id.Length > i; i++)
            {
                if (PhotonNetwork.MasterClient.UserId != multiplayer_party_maneger.MPM.Party_user_id[i].UserId)
                    userID[i] = multiplayer_party_maneger.MPM.Party_user_id[i].UserId;
            }
        }

        return userID;
    }
    IEnumerator leave_with_party()
    {

   
        multiplayer_party_maneger.MPM.started_machmaking = true;
        multiplayer_party_maneger.MPM.callPartyMachmaking();
        yield return new WaitUntil(() => PhotonNetwork.IsConnectedAndReady == true);
        if(PhotonNetwork.CurrentRoom!=null)
            PhotonNetwork.LeaveRoom();
        yield return new WaitUntil(() => PhotonNetwork.IsConnectedAndReady == true);
        PhotonNetwork.JoinRandomRoom(null, maxPlayersPerRoom, MatchmakingMode.FillRoom, null, null, Get_userIDs());
       
       

    }

}

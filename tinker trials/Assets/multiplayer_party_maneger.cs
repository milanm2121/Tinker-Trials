using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Linq;

public class multiplayer_party_maneger : MonoBehaviourPunCallbacks
{
    public Player[] Party_user_id;
    public string[] userID;
    public string partyhost;
    public static multiplayer_party_maneger MPM;

    public bool started_machmaking;

    public PhotonView PV;
    // Start is called before the first frame update
    private void Awake()
    {
        if (MPM == null)
        {        
            DontDestroyOnLoad(this);

            MPM = this;
        }
        else
        {
            Destroy(MPM.gameObject);
        }
        PV = GetComponent<PhotonView>();
    }

    public void callPartyMachmaking()
    {
        PV.RPC("StartPartyMachmaking", RpcTarget.All);
    }
    [PunRPC]
    void StartPartyMachmaking()
    {
        MPM.started_machmaking = true;
        PhotonNetwork.LeaveRoom();
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        partyhost = PhotonNetwork.MasterClient.UserId;
    }

    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        partyhost = PhotonNetwork.NetworkingClient.UserId;
    }


    // Update is called once per frame
    void Update()
    {
        if (started_machmaking == false)
        {
            Party_user_id = PhotonNetwork.PlayerList;

            userID = new string[0];
            if (PhotonNetwork.CurrentRoom != null)
            {
                userID = new string[Party_user_id.Length];


                for (int i = 0; Party_user_id.Length > i; i++)
                {
                    if (PhotonNetwork.MasterClient.UserId != Party_user_id[i].UserId)
                        userID[i] = Party_user_id[i].UserId;
                }
            }

        }
        else
        {
            if(PhotonNetwork.CurrentRoom==null && PhotonNetwork.IsConnectedAndReady && partyhost != PhotonNetwork.NetworkingClient.UserId)
                PhotonNetwork.FindFriends(new string[1] { MPM.partyhost });
        }
    }

    public override void OnFriendListUpdate(List<FriendInfo> friendList)
    {
        base.OnFriendListUpdate(friendList);
        if (partyhost != PhotonNetwork.NetworkingClient.UserId)
        {
            for (int i = 0; i < friendList.Count; i++)
            {
                FriendInfo friend = friendList[i];
                Debug.LogFormat("{0}", friend);
                if (friend.UserId == partyhost && friend.Room != null && PhotonNetwork.IsConnectedAndReady)
                {
                    started_machmaking = false;
                    PhotonNetwork.JoinRoom(friend.Room);

                }
            }
        }
    }

}

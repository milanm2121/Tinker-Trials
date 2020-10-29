using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class gameplay_maneger : MonoBehaviourPunCallbacks
{
    public player_classes_loader PCL;
    public multiplayer_game_maneger MGM;

    public List<multiplayer_teamID> team1;
    public List<multiplayer_teamID> team2;

    public GameObject Player_prefab;

    public int team1_count = 0;
    public  int team2_count = 0;
    public int players_in_game = 0;
    public bool team = false;

    public PhotonView PV; 

    // Start is called before the first frame update
    void Start()
    {
        PCL = GameObject.Find("multiplayer_game_maneger").GetComponent<player_classes_loader>();
        MGM = GameObject.Find("multiplayer_game_maneger").GetComponent<multiplayer_game_maneger>();


        if (PhotonNetwork.IsMasterClient)
        {
            PV.RPC("sort_teams", RpcTarget.AllBufferedViaServer);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [PunRPC]
    public void sort_teams()
    {
        
        for(int i=players_in_game; PhotonNetwork.PlayerList.Length>i; i++)
        {
            if (team)
            {
                GameObject player = PhotonNetwork.Instantiate(this.Player_prefab.name, Vector3.zero + new Vector3(0, 5, 0), Quaternion.identity);
                multiplayer_teamID TID = player.GetComponent<multiplayer_teamID>();
                TID.GPM = this;
                TID.roomID = i;
                TID.team = 1;
                TID.teamID =team1_count;
                TID.name = PhotonNetwork.NickName;
                team1_count++;
            }
            else
            {
                GameObject player = PhotonNetwork.Instantiate(this.Player_prefab.name, Vector3.zero + new Vector3(0, 5, 0), Quaternion.identity);
                multiplayer_teamID TID = player.GetComponent<multiplayer_teamID>();
                TID.GPM = this;
                TID.roomID = i;
                TID.team = 2;
                TID.teamID = team2_count;
                TID.name = PhotonNetwork.NickName;
                team2_count++;
            }
            players_in_game++;
        }
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        PV.RPC("sort_teams", RpcTarget.AllBufferedViaServer);
    }


}

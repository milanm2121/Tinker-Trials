using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class gameplay_maneger : MonoBehaviourPunCallbacks
{
    public player_classes_loader PCL;
    public multiplayer_game_maneger MGM;

    public List<multiplayer_teamID> team1;
    public List<multiplayer_teamID> team2;

    public GameObject Player_prefab;

    public int team1_count = 0;
    public int team2_count = 0;
    public int players_in_game = 0;
    public bool team = false;

    public PhotonView PV;
    bool instantaded_player = false;

    static GameObject localPlayer;
    bool startrespawn;


    public Transform[] spawnpoints_team1;
    public Transform[] spawnpoints_team2;
    // Start is called before the first frame update
    void Start()
    {
        PCL = GameObject.Find("multiplayer_game_maneger").GetComponent<player_classes_loader>();
        MGM = GameObject.Find("multiplayer_game_maneger").GetComponent<multiplayer_game_maneger>();

       
    }
    

    public void instantiatePlayer()
    {
        print("before forloop");
        for (int i = 0; PhotonNetwork.PlayerList.Length > i; i++)
        {//need to fix  
            print("in for loop");


            if (PhotonNetwork.PlayerList[i] == PhotonNetwork.LocalPlayer)
            {
                print("ID match");

                if (team)
                {

                    GameObject player = PhotonNetwork.Instantiate(this.Player_prefab.name, spawnpoints_team1[Random.Range(0, spawnpoints_team1.Length)].position + new Vector3(0, 5, 0), Quaternion.identity);
                    multiplayer_teamID TID = player.GetComponent<multiplayer_teamID>();
                    TID.GPM = this;
                    TID.roomID = i;
                    TID.team = 1;
                    TID.teamID = team1_count;
                    TID.name = PhotonNetwork.NickName;
                    team1_count++;
                    print("instantiated player");
                    localPlayer = player;
                    TID.healthbar.color = Color.blue;
                }
                else if (!team)
                {

                    GameObject player = PhotonNetwork.Instantiate(this.Player_prefab.name, spawnpoints_team2[Random.Range(0, spawnpoints_team2.Length)].position + new Vector3(0, 5, 0), Quaternion.identity);
                    multiplayer_teamID TID = player.GetComponent<multiplayer_teamID>();
                    TID.GPM = this;
                    TID.roomID = i;
                    TID.team = 2;
                    TID.teamID = team2_count;
                    TID.name = PhotonNetwork.NickName;
                    team2_count++;
                    print("instantiated player");
                    localPlayer = player;
                    TID.healthbar.color = Color.red;

                }
                startrespawn = false;
                if (instantaded_player==false)
                    PV.RPC("sort_teams", RpcTarget.MasterClient);
            }

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (instantaded_player==false && localPlayer==null)
        {
            instantaded_player = true;
            instantiatePlayer();
            print("start instantiate");
        }
        if (localPlayer == null)
        {
            if (startrespawn == false)
            {
                Invoke("instantiatePlayer", 2);
                startrespawn = true;
            }
        }
    }

    [PunRPC]
    public void sort_teams()
    {

        if (PhotonNetwork.IsMasterClient)
        {
            players_in_game++;
            if (!team)
            {
                team = true;
                PV.RPC("Update_gameplay_maneger", RpcTarget.AllBuffered, team);
            }
            else
            {
                team = false;
                PV.RPC("Update_gameplay_maneger", RpcTarget.AllBuffered, team);

            }
        }
    }

    [PunRPC]
    void Update_gameplay_maneger(bool Team)
    {
        team = Team;
    }

    
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        //PV.RPC("sort_teams", RpcTarget.AllBufferedViaServer);
    }

}

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
    public  int team2_count = 0;
    public int players_in_game = 0;
    public bool team = false;

    public PhotonView PV;

    bool instantaded_player=false;

    // Start is called before the first frame update
    void Start()
    {
        PCL = GameObject.Find("multiplayer_game_maneger").GetComponent<player_classes_loader>();
        MGM = GameObject.Find("multiplayer_game_maneger").GetComponent<multiplayer_game_maneger>();



        PV.RPC("sort_teams", RpcTarget.All, true);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [PunRPC]
    public void sort_teams(bool initalise)
    {

        print("spawn");

        for (int i = 0; 2 > i; i++)
        {//need to fix

            if (PhotonNetwork.PlayerList[i] == PhotonNetwork.LocalPlayer)
            {

                if (team)
                {

                    instaniate_team1(i);

                }
                else if (!team)
                {

                    instaniate_team2(i);
                }
            }
            if (PhotonNetwork.IsMasterClient)
            {
                players_in_game++;
                if (!team)
                {
                    team = true;
                }
                else
                {
                    team = false;
                }
            }
        }


    }

    IEnumerator instaniate_team1(int i)
    {
       // yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "multiplayer_gameplay_test");
        yield return new WaitUntil(()=> PhotonNetwork.IsConnectedAndReady);
        if (instantaded_player == false)
        {
            GameObject player = PhotonNetwork.Instantiate(this.Player_prefab.name, Vector3.zero + new Vector3(0, 5, 0), Quaternion.identity);
            multiplayer_teamID TID = player.GetComponent<multiplayer_teamID>();
            TID.GPM = this;
            TID.roomID = i;
            TID.team = 1;
            TID.teamID = team1_count;
            TID.name = PhotonNetwork.NickName;
            team1_count++;
            instantaded_player = true;
            print("1spawn");
        }
    }
    IEnumerator instaniate_team2(int i)
    {
      //  yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "multiplayer_gameplay_test");
        yield return new WaitUntil(() => PhotonNetwork.IsConnectedAndReady);

        if (instantaded_player == false) {
            GameObject player = PhotonNetwork.Instantiate(this.Player_prefab.name, Vector3.zero + new Vector3(0, 5, 0), Quaternion.identity);
            multiplayer_teamID TID = player.GetComponent<multiplayer_teamID>();
            TID.GPM = this;
            TID.roomID = i;
            TID.team = 2;
            TID.teamID = team2_count;
            TID.name = PhotonNetwork.NickName;
            team2_count++;
            instantaded_player = true;
            print("1spawn");
        }
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        //PV.RPC("sort_teams", RpcTarget.AllBufferedViaServer);
    }

}

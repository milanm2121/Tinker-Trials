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

    public List<teamID> team1= new List<teamID>();
    public List<teamID> team2=new List<teamID>();

    public GameObject Player_prefab;

    public struct teamID
    {
        public string name;
        public int team;
        public int roomID;
        public int kills;
        public int deaths;
    }
    teamID localTeamInfo;

    public int team1_count = 0;
    public int team2_count = 0;
    public int players_in_game = 0;

    public bool team = false;

    public PhotonView PV;
    bool instantaded_player = false;

    static GameObject localPlayer;
    bool startrespawn=true;
    
    public Transform[] spawnpoints_team1;
    public Transform[] spawnpoints_team2;

    bool pickedteam=false;

    // Start is called before the first frame update
    void Start()
    {
        PCL = GameObject.Find("multiplayer_game_maneger").GetComponent<player_classes_loader>();
        MGM = GameObject.Find("multiplayer_game_maneger").GetComponent<multiplayer_game_maneger>();

        if (PhotonNetwork.IsMasterClient)
        {
            InvokeRepeating("updateGameManegerMaseter", 2, 2);
        }
    }


    public void instantiatePlayer()
    {

        print("ID match");

        if (instantaded_player == false && !localPlayer)
        {
            instantaded_player = true;
            GameObject player = PhotonNetwork.Instantiate(Player_prefab.name, spawnpoints_team1[Random.Range(0, spawnpoints_team1.Length)].position + new Vector3(0, 5, 0), Quaternion.identity);

            if ((bool)PhotonNetwork.LocalPlayer.CustomProperties["Team"])
            {

                multiplayer_teamID TID = player.GetComponent<multiplayer_teamID>();
                TID.GPM = GameObject.Find("gameplay_maneger").GetComponent<gameplay_maneger>();
                TID.shown_name.text = player.GetComponent<PhotonView>().Owner.NickName;
                team1_count++;
                print("instantiated player");
                TID.healthbar.color = Color.blue;
            }
            else if (!(bool)PhotonNetwork.LocalPlayer.CustomProperties["Team"])
            {

                multiplayer_teamID TID = player.GetComponent<multiplayer_teamID>();
                TID.GPM = GameObject.Find("gameplay_maneger").GetComponent<gameplay_maneger>();
                TID.shown_name.text = player.GetComponent<PhotonView>().Owner.NickName;
                team2_count++;
                print("instantiated player");
                TID.healthbar.color = Color.red;

            }
            localPlayer = player;

            pickedteam = true;

            startrespawn = false;

            return;
        }
        else
        {
            if (!localPlayer)
            {
                GameObject player = PhotonNetwork.Instantiate(this.Player_prefab.name, spawnpoints_team1[Random.Range(0, spawnpoints_team1.Length)].position + new Vector3(0, 5, 0), Quaternion.identity);
                multiplayer_teamID TID = player.GetComponent<multiplayer_teamID>();
                TID.GPM = this;
                TID.shown_name.text = player.GetComponent<PhotonView>().Owner.NickName;
                print("instantiated player again");
                localPlayer = player;
               
            }          
            startrespawn = false;

        }


    }

    

    // Update is called once per frame
    void LateUpdate()
    {
   
        if (pickedteam==false && instantaded_player==false && localPlayer==null)
        {
            pickedteam = true;
            StartCoroutine(sort_in_order());
            print("start instantiate");
        }
        else 
        {
            if (pickedteam == true && instantaded_player == true && localPlayer == null)
            {
                if (startrespawn == false)
                {
                    Invoke("instantiatePlayer", 2);
                    startrespawn = true;
                }
            }
        }
    }

    [PunRPC]
    public void sort_teams(int roomdID,string Name)
    {

       
       
        ExitGames.Client.Photon.Hashtable Team = new ExitGames.Client.Photon.Hashtable();
        Team.Add("Team", team);
        Team.Add("Name", Name);
        PhotonNetwork.LocalPlayer.SetCustomProperties(Team);
        

        players_in_game++;
        if (!team)
        {
            localTeamInfo = new teamID { kills = 0, deaths = 0, name = Name, roomID = roomdID, team = 1 };

            team = true;
            team1.Add(localTeamInfo);

        }
        else
        {
            localTeamInfo = new teamID { kills = 0, deaths = 0, name = Name, roomID = roomdID, team = 2 };

            team = false;
            team2.Add(localTeamInfo);


        }

    }


    IEnumerator sort_in_order()
    {
        yield return new WaitForSeconds(0.5f);
        yield return new WaitUntil(() => PhotonNetwork.PlayerList[players_in_game] == PhotonNetwork.LocalPlayer);
        print("started sorting teams");

        object[] x= new object[]{players_in_game,PhotonNetwork.NickName};
        PV.RPC("sort_teams", RpcTarget.AllBuffered,x);

        yield return new WaitUntil(()=>PhotonNetwork.LocalPlayer.CustomProperties.Count!=0);
        instantiatePlayer();
    }

    void updateGameManegerMaseter()
    {
        object[] x = new object[] {players_in_game,team};
        PV.RPC("updateGameManegerClient",RpcTarget.OthersBuffered,x);
    }
    [PunRPC]
    void updateGameManegerClient(int playerInGame,bool Team)
    {
        team = Team;
        players_in_game = playerInGame;
    }



}

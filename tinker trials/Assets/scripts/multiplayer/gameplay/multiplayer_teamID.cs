using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class multiplayer_teamID : MonoBehaviourPunCallbacks
{
    public string name;
    public int team;
    public int teamID;
    public int roomID;
    public gameplay_maneger GPM;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        
    }
    
    [PunRPC]
    void leaveGame()
    {
        GPM.players_in_game--;
        if (team == 1)
        {
            GPM.team1_count--;
            GPM.team1.RemoveAt(teamID);
            for(int i=teamID;GPM.team1.Count>i; i++)
            {
                GPM.team1[i].teamID--;
            }

        }
        else
        {
            GPM.team2_count--;
            GPM.team2.RemoveAt(teamID);
            for (int i = teamID; GPM.team2.Count > i; i++)
            {
                GPM.team2[i].teamID--;
            }
        }

        

        if (GPM.team1.Count > GPM.team2.Count)
        {
            GPM.team = true;
        }
        else
        {
            GPM.team = false;
        }
    }
   
}

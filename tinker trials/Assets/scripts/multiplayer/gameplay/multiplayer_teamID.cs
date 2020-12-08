using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class multiplayer_teamID : MonoBehaviourPunCallbacks
{
    public string name;
    public int team;

    public gameplay_maneger GPM;
    public Image healthbar;
    // Start is called before the first frame update
    void Start()
    {
        if ((bool)photonView.Owner.CustomProperties["Team"])
        {
            team = 1;
            healthbar.color = Color.red;
        }
        else
        {
            team = 2;
            healthbar.color = Color.blue;
        }
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        photonView.RPC("leaveGame", RpcTarget.All);
    }
    
    [PunRPC]
    void leaveGame()
    {
        GPM.players_in_game--;
        if (team == 1)
        {
            GPM.team1_count--;
           

        }
        else
        {
            GPM.team2_count--;
         
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

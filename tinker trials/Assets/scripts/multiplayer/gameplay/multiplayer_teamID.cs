using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;
using TMPro;
using Photon.Realtime;

public class multiplayer_teamID : MonoBehaviourPunCallbacks,IPunObservable
{
    public string _name;
    public int team;
    public TMP_Text shown_name;
    public gameplay_maneger GPM;
    public Image healthbar;
    public Image scoreboard;
    public TMP_Text red_score;
    public TMP_Text blue_score;

    // Start is called before the first frame update
    void Start()
    {
        if ((bool)photonView.Owner.CustomProperties["Team"])
        {
            team = 1;
            healthbar.color = Color.blue;
            scoreboard.color = Color.blue;
        }
        else
        {
            team = 2;
            healthbar.color = Color.red;
            scoreboard.color = Color.red;
        }
        
    }

    private void Update()
    {
        if (photonView.IsMine)
        {
            red_score.text = GPM.team2_score.ToString();
            blue_score.text = GPM.team1_score.ToString();
        }
    }


    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(shown_name.text);
           

        }
        else if (stream.IsReading)
        {
            shown_name.text = (string)stream.ReceiveNext();
        }
    }
}

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
        photonView.RPC("leaveGame", RpcTarget.All);
    }



    [PunRPC]
    void leaveGame()
    {
        
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

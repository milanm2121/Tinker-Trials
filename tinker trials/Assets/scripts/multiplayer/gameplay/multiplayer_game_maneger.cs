using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class multiplayer_game_maneger : MonoBehaviourPunCallbacks
{
    public Button start_game_button;
    public multiplayer_game_maneger MGM;

    private void Awake()
    {
        if (MGM == null)
        {
            DontDestroyOnLoad(this);

            MGM = this;
        }
        else
        {
            Destroy(MGM.gameObject);
        }
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("multiplayer_menu");
        Destroy(this.gameObject);
    }

    public void LeaveLobby()
    {
        PhotonNetwork.LeaveRoom();
        Destroy(multiplayer_party_maneger.MPM.gameObject);
        Destroy(photon_View_intance_maneger.PV.gameObject);
        
    }

    private void Update()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            start_game_button.interactable = true;
        }
        else
        {
            start_game_button.interactable = false;
        }
    }

    public void LoadGame()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            Debug.LogError("PhotonNetwork : Trying to Load a level but we are not the master Client");
        }
        Debug.LogFormat("PhotonNetwork : Loading"+ PhotonNetwork.CurrentRoom.Name);
        PhotonNetwork.LoadLevel("multiplayer_gameplay_test");
    }
}

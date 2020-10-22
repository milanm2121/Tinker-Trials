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

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("multiplayer_menu");
    }

    public void LeaveLobby()
    {
        PhotonNetwork.LeaveRoom();
        Destroy(multiplayer_party_maneger.MPM.gameObject);
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
        PhotonNetwork.LoadLevel("multiplayer_lobby");
    }
}

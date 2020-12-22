using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class multiplayer_game_maneger : MonoBehaviourPunCallbacks, IPunInstantiateMagicCallback
{
    public Button start_game_button;
    public multiplayer_game_maneger MGM;
    public load_scean LS;
    public ExitGames.Client.Photon.Hashtable room_propertys = new ExitGames.Client.Photon.Hashtable();
    public List<GameObject> preloaded_player_objects = new List<GameObject>();

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

    private void Start()
    {
        PhotonNetwork.LocalPlayer.CustomProperties.Clear();
        if (PhotonNetwork.IsMasterClient)
        {
            room_propertys.Add("started_game", false);
            PhotonNetwork.CurrentRoom.SetCustomProperties(room_propertys);
        }
        
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("multiplayer_menu");
        Destroy(this.gameObject);
    }

    public void LeaveLobby()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            PhotonNetwork.LeaveRoom();
            Destroy(multiplayer_party_maneger.MPM.gameObject);
        }
       // Destroy(photon_View_intance_maneger.PV.gameObject);
    }

    

    private void Update()
    {
        if (PhotonNetwork.IsMasterClient && start_game_button!=null)
        {
            start_game_button.interactable = true;
        }
        else if(start_game_button != null)
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
        Debug.LogFormat("PhotonNetwork : Loading" + PhotonNetwork.CurrentRoom.Name);
        room_propertys["started_game"] = true;
        PhotonNetwork.CurrentRoom.SetCustomProperties(room_propertys);
        PhotonNetwork.LoadLevel("multiplayer_gameplay_test");
        
    }

    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        if (SceneManager.GetActiveScene().name != "multiplayer_gameplay_test") {
            GameObject instaniatedplayer = info.photonView.gameObject;
            DontDestroyOnLoad(instaniatedplayer);
            preloaded_player_objects.Add(instaniatedplayer);
            instaniatedplayer.SetActive(false);
        }

    }
    
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class Server_IP_Input_Feild : MonoBehaviour
{
    const string ServerIPPrefKey = "IP";

    public Button connectbutton;


    public TMP_InputField ServerIP;

    public multiplayer_launcher ML;

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log(PhotonNetwork.LocalPlayer.UserId);

        string defaultIP = string.Empty;
        TMP_InputField _inputField = this.GetComponent<TMP_InputField>();
        if (_inputField != null)
        {
            if (PlayerPrefs.HasKey(ServerIPPrefKey))
            {
                defaultIP = PlayerPrefs.GetString(ServerIPPrefKey);
                _inputField.text = PlayerPrefs.GetString(ServerIPPrefKey);
            }
        }
        if (PlayerPrefs.HasKey(ServerIPPrefKey))
        {
            defaultIP = PlayerPrefs.GetString(ServerIPPrefKey);
            ServerIP.text = PlayerPrefs.GetString(ServerIPPrefKey);
        }
        PhotonNetwork.NickName = defaultIP;
    }

    public void SetIPadress(string value)
    {
        // #Important
        if (string.IsNullOrEmpty(value))
        {
            Debug.LogError("Server IP is null or empty");
            return;
        }

        ML.ServerIP = value;

        Debug.Log("server adress " + value);


        PlayerPrefs.SetString(ServerIPPrefKey, value);
    }

    private void Update()
    {
        if (ServerIP.text == "")
        {
            connectbutton.interactable = false;
        }
        else
        {
            connectbutton.interactable = true;
        }

        if (PhotonNetwork.IsConnected)
        {
            ServerIP.interactable = false;
        }
        else
        {
            ServerIP.interactable = true;
        }
    }
}

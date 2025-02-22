﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

[RequireComponent(typeof(TMP_InputField))]
public class PlayerNameInputField : MonoBehaviour
{
    const string playerNamePrefKey = "";

    public Button connectbutton;


    public TMP_InputField inputname;



    // Start is called before the first frame update
    void Start()
    {
       
        Debug.Log(PhotonNetwork.LocalPlayer.UserId);

        string defaultName = string.Empty;
        TMP_InputField _inputField = this.GetComponent<TMP_InputField>();
        if (_inputField != null)
        {
            if (PlayerPrefs.HasKey(playerNamePrefKey))
            {
                defaultName = PlayerPrefs.GetString(playerNamePrefKey);
                _inputField.text = PlayerPrefs.GetString(playerNamePrefKey);
            }
        }
        if (PlayerPrefs.HasKey(playerNamePrefKey))
        {
            defaultName = PlayerPrefs.GetString(playerNamePrefKey);
            inputname.text = PlayerPrefs.GetString(playerNamePrefKey);
        }
        PhotonNetwork.NickName = defaultName;
    }

    public void SetPlayerName(string value)
    {
        // #Important
        if (string.IsNullOrEmpty(value))
        {
            Debug.LogError("Player Name is null or empty");
            return;
        }

        PhotonNetwork.NickName = value;

        Debug.Log("your nick name is " + value);
        

        PlayerPrefs.SetString(playerNamePrefKey, value);
    }

    private void Update()
    {
        if (inputname.text == "")
        {
            connectbutton.interactable = false;
        }
        else
        {
            connectbutton.interactable = true;
        }

        if (PhotonNetwork.IsConnected)
        {
            inputname.interactable = false;
        }
        else
        {
            inputname.interactable = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class player_classes_loader : MonoBehaviourPunCallbacks
{
    public PhotonView PV;

    public static int selected_class=1;

    int loadedclasses=0;
    public struct playerclasses
    {
        public class_class.Class class_1;
        public class_class.Class class_2;
        public class_class.Class class_3;
        public class_class.Class class_4;

    }
    [SerializeField]

    public Dictionary<string, playerclasses> playerClasses= new Dictionary<string, playerclasses>();

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }
    
    [PunRPC]
    void load_classes_RPC(List<player_inventory.saved_object> saved_Objects, string UserID)
    {
        if (playerClasses.ContainsKey(UserID))
        {
            print("class_already_loaded");
        }
        else {
            class_class.Class[] classes = player_inventory.load_classes(saved_Objects);

            playerclasses PlayerClass = new playerclasses
            {
                class_1 = classes[0],
                class_2 = classes[1],
                class_3 = classes[2],
                class_4 = classes[3]
            };
            Debug.Log(UserID);
            playerClasses.Add(UserID, PlayerClass);
            Debug.Log("loadedclasses");
            if (playerClasses.Count > 1)
            {
                print(playerClasses.Count);
            }
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        object[] x = { player_inventory.Class_TO_Saved_object(), PhotonNetwork.LocalPlayer.UserId };
        PV.RPC("load_classes_RPC", RpcTarget.AllBufferedViaServer, x);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerClasses.Count == PhotonNetwork.CurrentRoom.PlayerCount && true == (bool)PhotonNetwork.CurrentRoom.CustomProperties["started_game"] && SceneManager.GetActiveScene().name!= "multiplayer_gameplay_test")
        {
            PhotonNetwork.LoadLevel("multiplayer_gameplay_test");
        }
    }
}

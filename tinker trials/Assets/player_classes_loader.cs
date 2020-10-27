using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class player_classes_loader : MonoBehaviourPunCallbacks
{
    public PhotonView PV;

    public struct playerclasses
    {
        public class_class.Class class_1;
        public class_class.Class class_2;
        public class_class.Class class_3;
        public class_class.Class class_4;

    }
    [SerializeField]
    public Dictionary<int, playerclasses> playerClasses;

    

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        PV.RPC("load_classes_RPC", RpcTarget.AllBufferedViaServer, player_inventory.Class_TO_Saved_object());

    }
    [PunRPC]
    void load_classes_RPC(List<player_inventory.saved_object> saved_Objects)
    {

        class_class.Class[] classes = player_inventory.load_classes(saved_Objects);

        playerclasses PlayerClass = new playerclasses
        {
            class_1 = classes[1],
            class_2 = classes[2],
            class_3 = classes[3],
            class_4 = classes[4]
        };

        playerClasses.Add(PhotonNetwork.LocalPlayer.ActorNumber, PlayerClass);
    }

    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        PhotonPeer.RegisterType(typeof(List<player_inventory.saved_object>), (byte)'A', save_system.SeriliseClasses, save_system.DeSeriliseClassesPUN);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

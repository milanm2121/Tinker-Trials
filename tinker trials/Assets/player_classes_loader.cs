using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class player_classes_loader : MonoBehaviourPunCallbacks
{
    public struct playerclasses
    {
        public class_class.Class class_1;
        public class_class.Class class_2;
        public class_class.Class class_3;
        public class_class.Class class_4;

    }

    public Dictionary<int, playerclasses> playerClasses;

    public delegate byte[] seriliseMethod(List<player_inventory.saved_object> inventory);

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        

    }
    [PunRPC]
    void load_classes()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        seriliseMethod serilise = save_system.SeriliseClasses;

        PhotonPeer.RegisterType(typeof(List<player_inventory.saved_object>), 255, serilise, save_system.DeSeriliseClassesPUN);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

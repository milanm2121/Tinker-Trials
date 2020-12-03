using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.Animations.Rigging;


public class multi_lethal_thrower : MonoBehaviour
{
    public GameObject lethal;
    multi_in_game_leathal IGL;

    public GameObject currentLeathal;

    public bool tapped_lethal;

    public multi_Player_Movement PM;

    public multi_player_stats ps;

    public bool sholder_launcher = false;


    public bool throwing_lethal;

    public Rig right_arm_constaints;
    public PhotonView PV;
    public player_classes_loader PCL;

    // Start is called before the first frame update
    private void Start()
    {
        PV = GetComponent<PhotonView>();
    }


    public void initalise()
    {
        PCL = GameObject.Find("multiplayer_game_maneger").GetComponent<player_classes_loader>();
    }


    public void loadClass(string UserID, int Class)
    {
        object[] x = { UserID, Class };
        PV.RPC("syncClass_call", RpcTarget.AllBuffered, x);
    }


    [PunRPC]
    void syncClass_call(string UserID, int Class)
    {
        StartCoroutine(syncClass(UserID, Class));
    }

    // Update is called once per frame
    void Update()
    {
        if (throwing_lethal == true)
            throwing_lethal = false;

        if (PV.IsMine && Input.GetKeyDown(KeyCode.G) && currentLeathal == null && (PM.running == false || sholder_launcher == true))
        {
            right_arm_constaints.weight = 0;
            StartCoroutine(delaythrow());

            tapped_lethal = true;
            throwing_lethal = true;
        }

        if (PV.IsMine && Input.GetKeyDown(KeyCode.G) && tapped_lethal == false && (PM.running == false || sholder_launcher == true))
        {
            if (currentLeathal != null && IGL.manual == true)
            {
                currentLeathal.GetComponent<multi_in_game_leathal>().primed = true;
                currentLeathal = null;

            }
        }
        tapped_lethal = false;

    }

    void generate_leathal(class_class.Class class_)
    {
        IGL = lethal.GetComponent<multi_in_game_leathal>();
        IGL.primer_script.PO = class_.Lethal.primer;
        IGL.container_script.CO = class_.Lethal.container;
        IGL.payload_script.PO = class_.Lethal.payload;
    }
    IEnumerator syncClass(string UserID, int Class)
    {
        yield return new WaitUntil(() => PCL != null);
        if (Class == 1)
        {
            generate_leathal(PCL.playerClasses[UserID].class_1);
        }
        else if (Class == 2)
        {
            generate_leathal(PCL.playerClasses[UserID].class_2);
        }
        else if (Class == 3)
        {
            generate_leathal(PCL.playerClasses[UserID].class_3);
        }
        else if (Class == 4)
        {
            generate_leathal(PCL.playerClasses[UserID].class_4);
        }
    }
    IEnumerator delaythrow()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject x = PhotonNetwork.InstantiateRoomObject("multi_leathal", transform.position, Quaternion.identity);
        IGL.primed = false;
        x.GetComponent<Rigidbody>().velocity = transform.forward * IGL.container_script.CO.weight * 10;
        x.GetComponent<multi_in_game_leathal>().ps = ps;

        currentLeathal = x;
        right_arm_constaints.weight = 1;
    }
}

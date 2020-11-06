using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;

public class multi_armour_game : MonoBehaviour
{
    public GameObject head_gear;
    public headgear headgear_script;

    public GameObject cheastplate;
    public cheastplate cheastplate_script;

    public GameObject Boots;
    public boots_scripts boots_script;

    public float weight = 0;
    public int deffence;
    public PhotonView PV;

    public player_classes_loader PCL;

    // Start is called before the first frame update
    void Start()
    {
        //adds all of the stats of get a defence value
        PV = GetComponent<PhotonView>();

    }

    public void initalise()
    {
        PCL = GameObject.Find("multiplayer_game_maneger").GetComponent<player_classes_loader>();
    }

    public void loadClass(string UserID, int Class)
    {
        object[] x = { UserID, Class };
        PV.RPC("syncClass", RpcTarget.AllBufferedViaServer,x );
    }

    [PunRPC]
    void syncClass(string UserID, int Class)
    {
        if (Class == 1)
        {
            selectclass(PCL.playerClasses[UserID].class_1);
        }
        else if (Class == 2)
        {
            selectclass(PCL.playerClasses[UserID].class_2);
        }
        else if (Class == 3)
        {
            selectclass(PCL.playerClasses[UserID].class_3);
        }
        else if (Class == 4)
        {
            selectclass(PCL.playerClasses[UserID].class_4);
        }
        weight += headgear_script.HGO.weight;
        weight += cheastplate_script.CPO.weight;
        weight += boots_script.BO.weight;
        deffence += headgear_script.HGO.deffence;
        deffence += cheastplate_script.CPO.deffence;
        deffence += boots_script.BO.deffence;
        deffence = deffence / 3 * 10;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void selectclass(class_class.Class Class_)
    {
        //defalt armour


        headgear_script.HGO = Class_.Armour.headpeice;
        cheastplate_script.CPO = Class_.Armour.chestpeice;
        boots_script.BO = Class_.Armour.boots;

        //generate armour
        headgear_script.Generate_headGear();
        cheastplate_script.gerateCheastPlate();
        boots_script.generateBoots();
    }
}
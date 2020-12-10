using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using UnityEngine.Audio;


public class multi_armour_game : MonoBehaviour
{
    public GameObject head_gear;
    public headgear headgear_script;

    public GameObject cheastplate;
    public cheastplate cheastplate_script;

    public GameObject L_Boots;
    public boots_scripts L_boots_script;

    public GameObject R_Boots;
    public boots_scripts R_boots_script;

    public float weight = 0;
    public int deffence;

    public AudioMixer SFX;
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
        PV.RPC("syncClass_call", RpcTarget.AllBufferedViaServer,x );
    }

    [PunRPC]
    void syncClass_call(string UserID, int Class)
    {
        StartCoroutine(syncClass(UserID, Class));
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
        L_boots_script.BO = Class_.Armour.boots;
        R_boots_script.BO = Class_.Armour.boots;


        //generate armour
        if (!PV.IsMine)
        {
            headgear_script.Generate_headGear();
        }
            cheastplate_script.gerateCheastPlate();
        L_boots_script.generateBoots();
        R_boots_script.BO = Class_.Armour.boots;

        if (headgear_script.HGO.speciality == 2)
        {
            Debug.Log(SFX.SetFloat("SFX Volume", 10));
        }
        else
        {
            Debug.Log(SFX.SetFloat("SFX Volume", 0));
        }

    }
    IEnumerator syncClass(string UserID, int Class)
    {
        yield return new WaitUntil(() => PCL != null);
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
        weight += L_boots_script.BO.weight;
        deffence += headgear_script.HGO.deffence;
        deffence += cheastplate_script.CPO.deffence;
        deffence += L_boots_script.BO.deffence;
        deffence = deffence / 3 *10;
    }
}
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class photon_View_intance_maneger : MonoBehaviour
{
    public static PhotonView PV;

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (PV == null)
        {
            DontDestroyOnLoad(this);

            PV = GetComponent<PhotonView>();
        }
        else
        {
            Destroy(PV.gameObject);
        }
    }

}

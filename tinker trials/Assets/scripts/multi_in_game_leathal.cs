using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class multi_in_game_leathal : MonoBehaviour
{
    public GameObject primer;
    public primer primer_script;

    public GameObject Payload;
    public payload payload_script;

    public GameObject container;
    public container container_script;

    public bool manual = true;
    public bool primed = false;

    public PhotonView PV;

    float fuze = 0;
    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        PV.RPC("generate", RpcTarget.AllBuffered);
        generate();
        if (primer_script.PO.manual == false)
        {
            fuze = primer_script.PO.timer;
            Debug.Log(fuze);
            manual = false;
        }
        else
        {
            manual = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (manual == false)
        {
            fuze -= Time.deltaTime;
        }
        if(fuze>=0 && manual == false)
        {
            StartCoroutine(primerPhase());
        }

        if (fuze <= 0 && manual == false)
        {
            PV.RPC("explode", RpcTarget.All);
            print("boom");
        }
        if (manual == true && primed == true)
        {
            PV.RPC("explode", RpcTarget.All);
            print("boom1");
        }
        
    }
    [PunRPC]
    void generate()
    {
        primer_script.GeneratePrimer();
        payload_script.generatePayload();
        container_script.generateContainer();
    }
    [PunRPC]
    void explode()
    {
        Collider[] col = Physics.OverlapSphere(transform.position, payload_script.PO.radious * 2);
        if (PhotonNetwork.IsMasterClient)
        {
            for (int i = 0; col.Length > i; i++)
            {
                RaycastHit hit;

                Vector3 offset = (col[i].transform.position - transform.position);
                Physics.Raycast(transform.position, offset, out hit);
                if (hit.collider == col[i] && col[i].GetComponent<Rigidbody>() != null)
                {
                    col[i].attachedRigidbody.velocity += 10 * (new Vector3(1, 1, 1) - (offset / offset.magnitude));
                    if (col[i].GetComponent<multi_player_stats>() != null)
                    {
                        col[i].GetComponent<multi_player_stats>().damage_player(payload_script.PO.damage * 100, new Vector2Int(payload_script.PO.element, 0));
                    }
                    if (col[i].gameObject.GetComponent<object_health>() != null)
                    {
                        col[i].gameObject.GetComponent<object_health>().damage_object(payload_script.PO.damage * 10);
                    }
                }
            }
        }

        GameObject x = Instantiate(live_refrence_maneger.Expolsion, transform.position, Quaternion.identity);
        x.GetComponent<explosion_groth>().raidious = payload_script.PO.radious * 2;

        if (payload_script.PO.element == 0)
        {
            x.GetComponent<MeshRenderer>().material = live_refrence_maneger.EXPdefalt;
        }
        else if (payload_script.PO.element == 1)
        {
            x.GetComponent<MeshRenderer>().material = live_refrence_maneger.EXPFire;
        }
        else if (payload_script.PO.element == 2)
        {
            x.GetComponent<MeshRenderer>().material = live_refrence_maneger.EXPice;
        }
        else if (payload_script.PO.element == 3)
        {
            x.GetComponent<MeshRenderer>().material = live_refrence_maneger.EXPearth;
        }
        else if (payload_script.PO.element == 4)
        {
            x.GetComponent<MeshRenderer>().material = live_refrence_maneger.EXPEelctrisity;
        }


        Destroy(gameObject);
    }

    IEnumerator primerPhase()
    {
        if (primer_script.PO.speciality == 1)
        {
            PV.RPC("vortex", RpcTarget.All);
            yield return new WaitForSeconds(2);
            PV.RPC("vortex", RpcTarget.All);
        }
        PV.RPC("explode", RpcTarget.All);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (container_script.CO.sticky == true)
        {
            transform.parent = collision.transform;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }


    void vortex()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            List<Rigidbody> targets = new List<Rigidbody>();
            Collider[] col = Physics.OverlapSphere(transform.position + (-transform.right.normalized * 1), 10);
            for (int i = 0; col.Length > i; i++)
            {
                if (col[i].GetComponent<Rigidbody>() != null && col[i].gameObject.layer == 9)
                    targets.Add(col[i].GetComponent<Rigidbody>());
            }
            for (int i = 0; targets.Count > i; i++)
            {
                Vector3 offest = (transform.position - targets[i].transform.position);
                targets[i].velocity += offest.normalized * (10 * offest.magnitude);
            }
        }
    }

}

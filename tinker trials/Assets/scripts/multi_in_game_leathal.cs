using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class multi_in_game_leathal : MonoBehaviour,IPunObservable
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

    bool player_in_range;

    float fuze = 0;

    public multi_player_stats ps;

    bool exploded;

    GameObject empty;

    public GameObject target;

    Rigidbody rb;

    public GameObject junk_explosion;

    bool stuck = false;
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
        if (primer_script.PO.speciality == 2)
        {
            Collider[] player_Target = Physics.OverlapSphere(transform.position, 5, LayerMask.GetMask("player"));
            for (int i = 0; player_Target.Length > i; i++)
            {
                if (player_Target[i].GetComponent<multi_player_stats>() != ps)
                    player_in_range = true;
            }
            if (player_Target.Length == 0)
            {
                player_in_range = false;
            }
        }

        if (container_script.CO.speciality == 2)
        {
            if (target == null)
            {
                Collider[] player_Target = Physics.OverlapSphere(transform.position, 20, LayerMask.GetMask("player"));
                for (int i = 0; player_Target.Length > i; i++)
                {
                    if (player_Target[i].GetComponent<multi_player_stats>() != ps)
                        target = player_Target[i].gameObject;
                }
            }
            else
            {
                rb.AddForce((target.transform.position - transform.position).normalized * 100);
            }
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

        if (container_script.CO.speciality == 3)
        {
            PhotonNetwork.Instantiate("multi_junk explosion", transform.position, Quaternion.identity);
        }
        if (PV.IsMine)
        {
            if (empty != null)
            {
                PhotonNetwork.Destroy(empty);
            }
            PhotonNetwork.Destroy(gameObject);
        }
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

        if (primer_script.PO.speciality == 2)
        {
            yield return new WaitWhile(() => player_in_range == false);

        }
        explode();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (empty != null)
        {
            Destroy(empty);
        }

        if (container_script.CO.sticky == true && stuck == false)
        {
            stuck = true;
            empty = new GameObject();
            transform.parent = empty.transform;
            empty.transform.parent = collision.transform;
            transform.position = collision.GetContact(0).point;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }

        if (primer_script.PO.speciality == 3)
        {
            StartCoroutine(primerPhase());
        }

        if (container_script.CO.speciality == 1)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("player") && stuck == false)
            {
                stuck = true;
                empty = new GameObject();
                transform.parent = empty.transform;
                empty.transform.parent = collision.transform;
                transform.position = collision.GetContact(0).point;
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

                collision.gameObject.GetComponent<player_stats>().damage_player(50, Vector2Int.zero);
            }
        }
    }

    [PunRPC]
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
                targets[i].velocity += offest.normalized * (offest.magnitude);
            }
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {

            stream.SendNext(transform.position);
            stream.SendNext(rb.velocity);

        }
        else if (stream.IsReading)
        {
            transform.position = (Vector3)stream.ReceiveNext();
            rb.velocity = (Vector3)stream.ReceiveNext();

        }
    }
}

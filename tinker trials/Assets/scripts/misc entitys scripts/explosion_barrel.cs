using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion_barrel : MonoBehaviour
{
    public object_health HP;
    public float radious;
    public int damage;
    public int element;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HP.health <= 0)
        {
            explode();
        }
            
    }
    void explode()
    {
        Collider[] col = Physics.OverlapSphere(transform.position, radious * 2);
        for (int i = 0; col.Length > i; i++)
        {
            RaycastHit hit;

            Vector3 offset = (col[i].transform.position - transform.position);
            Physics.Raycast(transform.position, offset, out hit);
            if (hit.collider == col[i] && col[i].GetComponent<Rigidbody>() != null)
            {
                col[i].attachedRigidbody.velocity += 10 * (offset / offset.magnitude);
                if (col[i].GetComponent<player_stats>() != null)
                {
                    col[i].GetComponent<player_stats>().damage_player(damage * 100, new Vector2Int(element, 0));
                }
                if (col[i].gameObject.GetComponent<object_health>() != null)
                {
                    col[i].gameObject.GetComponent<object_health>().damage_object(damage * 10);
                }
            }
        }

        GameObject x = Instantiate(live_refrence_maneger.Expolsion, transform.position, Quaternion.identity);
        x.GetComponent<explosion_groth>().raidious = radious * 2;

        if (element == 0)
        {
            x.GetComponent<MeshRenderer>().material = live_refrence_maneger.EXPdefalt;
        }
        else if (element == 1)
        {
            x.GetComponent<MeshRenderer>().material = live_refrence_maneger.EXPFire;
        }
        else if (element == 2)
        {
            x.GetComponent<MeshRenderer>().material = live_refrence_maneger.EXPice;
        }
        else if (element == 3)
        {
            x.GetComponent<MeshRenderer>().material = live_refrence_maneger.EXPearth;
        }
        else if (element == 4)
        {
            x.GetComponent<MeshRenderer>().material = live_refrence_maneger.EXPEelctrisity;
        }





        Destroy(gameObject);
    }
}

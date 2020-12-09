using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Rendering;
using Photon.Pun;

public class explosion_growth : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref projectile_explosion explosion, ref Scale scale,ref Translation translation) =>
        {
            explosion.current_size += explosion.blast_radious * Time.deltaTime * 10;
            explosion.current_size = Mathf.Clamp(explosion.current_size, 0, explosion.blast_radious*2);
            scale.Value = explosion.current_size;
            if (explosion.tick == false)
            {
                explosion.tick = true;
                Collider[] hits=Physics.OverlapSphere(translation.Value,explosion.blast_radious);
                for(int i=0;hits.Length>i; i++)
                {
                    GameObject gameobject = hits[i].gameObject;

                    RaycastHit hit;
                    Vector3 offset = (gameobject.transform.position - (Vector3)translation.Value);
                    Physics.Raycast(translation.Value, offset, out hit);

                    if (hit.collider != null && hit.collider.gameObject == gameobject && gameobject.GetComponent<Rigidbody>() != null && (PhotonNetwork.InRoom == false || (PhotonNetwork.InRoom && PhotonNetwork.IsMasterClient)))
                    {

                        if (gameobject.GetComponent<player_stats>())
                        {
                            gameobject.GetComponent<player_stats>().damage_player(explosion.damage, explosion.element);
                        }

                        if (gameobject.GetComponent<multi_player_stats>())
                        {
                            gameobject.GetComponent<multi_player_stats>().damage_player(explosion.damage, explosion.element);
                        }

                        if (gameobject.GetComponent<object_health>() != null)
                        {
                            gameobject.GetComponent<object_health>().damage_object((int)explosion.damage * 10);
                        }

                        if (gameobject.GetComponent<dummy_script>())
                        {
                            gameobject.GetComponent<dummy_script>().damage_player(explosion.damage, explosion.element);
                        }

                        gameobject.GetComponent<Rigidbody>().velocity += (gameobject.transform.position - new Vector3(translation.Value.x, translation.Value.y, translation.Value.z)).normalized * 10;

                    }
                }
            }
        });
    }
}

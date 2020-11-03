/*
by:Milan Manji
script descrition: this script calculates the velosity amd movement of projectiles
And cheaks to see if it colides with anthing it can apply phisics to




NOTE: DO NOT TOUCH THIS SCRIPT PLEASE

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Photon.Pun;
public class projectilemovement : ComponentSystem
{
    protected override void OnUpdate()
    {
        

        Entities.ForEach((ref projectile projectile, ref Translation translation) =>
        {
            if (projectile.Predict_hit == false)
            {
                RaycastHit predictedPath;
                Physics.Raycast(translation.Value, projectile.velosity, out predictedPath, projectile.velosity.magnitude * Time.deltaTime);

                if (predictedPath.collider != null && predictedPath.collider.gameObject.GetComponent<Rigidbody>()!=null)
                {
                    if (predictedPath.collider.gameObject.GetComponent<player_stats>() && ( PhotonNetwork.InRoom==false || (PhotonNetwork.InRoom && PhotonNetwork.IsMasterClient)))
                    {
                        predictedPath.collider.gameObject.GetComponent<player_stats>().damage_player(projectile.REf.damage,projectile.REf.element);
                    }
                    if (predictedPath.collider.gameObject.GetComponent<object_health>() != null && (PhotonNetwork.InRoom == false || (PhotonNetwork.InRoom && PhotonNetwork.IsMasterClient)))
                    {
                        predictedPath.collider.gameObject.GetComponent<object_health>().damage_object(projectile.REf.damage);
                    }

                    if(PhotonNetwork.InRoom == false || (PhotonNetwork.InRoom && PhotonNetwork.IsMasterClient))
                        predictedPath.collider.gameObject.GetComponent<Rigidbody>().velocity += projectile.velosity;

                    projectile.Predict_hit = true;
                }
                else if(predictedPath.collider != null)
                {
                    projectile.Predict_hit = true;
                }
            }

            if (projectile.distance > projectile.REf.range)
            {
                projectile.Predict_hit = true;
            }
        });

        Entities.ForEach((ref projectile projectile, ref Translation translation) =>
        {
            translation.Value.x += projectile.velosity.x * Time.deltaTime;
            translation.Value.y += projectile.velosity.y * Time.deltaTime;
            translation.Value.z += projectile.velosity.z * Time.deltaTime;


            projectile.distance += projectile.velosity.magnitude * Time.deltaTime;

        });
    }
}

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
                Physics.Raycast(translation.Value, projectile.velosity, out predictedPath, projectile.velosity.magnitude * Time.deltaTime*3);
                
                if (predictedPath.collider != null && predictedPath.collider.gameObject.GetComponent<Rigidbody>()!=null)
                {
                    if (predictedPath.collider.gameObject.GetComponent<multi_player_stats>() && (PhotonNetwork.InRoom == false || (PhotonNetwork.InRoom && PhotonNetwork.IsMasterClient)))
                    {
                        predictedPath.collider.gameObject.GetComponent<multi_player_stats>().damage_player(projectile.REf.damage, projectile.REf.element);
                    }
                    if (predictedPath.collider.gameObject.GetComponent<player_stats>() && ( PhotonNetwork.InRoom==false || (PhotonNetwork.InRoom && PhotonNetwork.IsMasterClient)))
                    {
                        predictedPath.collider.gameObject.GetComponent<player_stats>().damage_player(projectile.REf.damage,projectile.REf.element);
                    }
                    if (predictedPath.collider.gameObject.GetComponent<object_health>() != null && (PhotonNetwork.InRoom == false || (PhotonNetwork.InRoom && PhotonNetwork.IsMasterClient)))
                    {
                        predictedPath.collider.gameObject.GetComponent<object_health>().damage_object(projectile.REf.damage);
                    }
                    if (predictedPath.collider.gameObject.GetComponent<dummy_script>() && (PhotonNetwork.InRoom == false || (PhotonNetwork.InRoom && PhotonNetwork.IsMasterClient)))
                    {
                        predictedPath.collider.gameObject.GetComponent<dummy_script>().damage_player(projectile.REf.damage, projectile.REf.element);
                    }

                    if (PhotonNetwork.InRoom == false || (PhotonNetwork.InRoom && PhotonNetwork.IsMasterClient))
                        predictedPath.collider.gameObject.GetComponent<Rigidbody>().velocity += projectile.velosity;

                    projectile.Predict_hit = true;
                    projectile.contact_point = predictedPath.point;
                }
                else if(predictedPath.collider != null)
                {
                    projectile.Predict_hit = true;
                    //metal
                    if (predictedPath.collider.gameObject.layer==11)
                    {
                        Audio_Maneger.create_sound(translation.Value, Audio_Maneger.AM.metalImpactSounsd[Random.Range(0, Audio_Maneger.AM.metalImpactSounsd.Length)]);
                    }
                    //wood
                    if (predictedPath.collider.gameObject.layer == 12)
                    {
                        Audio_Maneger.create_sound(translation.Value, Audio_Maneger.AM.woodImpactSounsd[Random.Range(0, Audio_Maneger.AM.woodImpactSounsd.Length)]);

                    }
                    //stone/concret
                    if (predictedPath.collider.gameObject.layer == 13)
                    {
                        Audio_Maneger.create_sound(translation.Value, Audio_Maneger.AM.stoneImpactSounsd[Random.Range(0, Audio_Maneger.AM.stoneImpactSounsd.Length)]);

                    }
                    projectile.contact_point = predictedPath.point;

                }
            }

            if (projectile.distance > projectile.REf.range)
            {
                projectile.Predict_hit = true;
                projectile.contact_point = translation.Value;

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

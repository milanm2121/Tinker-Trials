/*
by:Milan Manji
script descrition: this script creates projectiels with ECS. so yor gun can go Burrr.




NOTE: DO NOT TOUCH THIS SCRIPT PLEASE

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Rendering;
using Unity.Transforms;
using Unity.Collections;
public class entity_maneger : MonoBehaviour
{
    EntityManager EM;

    EntityArchetype projectileArk;
    EntityArchetype explosion;

    public Mesh explosinMesh;
    public Material explosinMaterial;

    ComponentType[] projectileARKArray;

    // Start is called before the first frame update
    void Start()
    {
        EM = World.Active.EntityManager;
        projectileArk = EM.CreateArchetype(
        typeof(projectile),
        typeof(Translation),
        typeof(Rotation),
        typeof(RenderMesh),
        typeof(LocalToWorld)
        );
        
        explosion = EM.CreateArchetype(
            typeof(Translation),
            typeof(RenderMesh),
            typeof(LocalToWorld),
            typeof(Scale),
            typeof(projectile_explosion)
            );


    }

    // Update is called once per frame
    void Update()
    {
        // destroys a projectile when it hits a target
        EntityQuery EQ = EM.CreateEntityQuery(typeof(projectile));
        var enititys = EQ.ToEntityArray(Allocator.TempJob);

        for (int i = 0; enititys.Length > i; i++)
        {
            if (EM.GetComponentData<projectile>(enititys[i]).Predict_hit == true)
            {
                if (EM.GetComponentData<projectile>(enititys[i]).REf.blast_radious > 0)
                {
                    Entity entity = EM.CreateEntity(explosion);
                    EM.SetComponentData(entity, new Translation { Value = EM.GetComponentData<Translation>(enititys[i]).Value });
                    EM.SetSharedComponentData(entity, new RenderMesh { material = explosinMaterial, mesh = explosinMesh });
                    EM.SetComponentData(entity, new projectile_explosion { tick = false, element = EM.GetComponentData<projectile>(enititys[i]).REf.element, damage = EM.GetComponentData<projectile>(enititys[i]).REf.damage, blast_radious = EM.GetComponentData<projectile>(enititys[i]).REf.blast_radious });

                    StartCoroutine(delayed_destory_entity(entity, 0.2f));
                }

                EM.DestroyEntity(enititys[i]);
            }
        }
            
        
        enititys.Dispose();


    }

    // a public function that is called by a weponTo shoot
    public void shootProjectile(Vector3 pos, Vector3 vol , projectileREf REF, Quaternion rotation, Material mat, Mesh mesh)
    {
        Entity entity = EM.CreateEntity(projectileArk);
        
        EM.SetComponentData(entity, new projectile { velosity = vol, REf=REF, distance=0});
        EM.SetComponentData(entity, new Translation { Value = pos });
        EM.SetSharedComponentData(entity, new RenderMesh { material = mat, mesh = mesh });
        EM.SetComponentData(entity, new Rotation {Value= rotation});
    }

    IEnumerator delayed_destory_entity(Entity entity,float time)
    {
        yield return new WaitForSeconds(time);
        EM.DestroyEntity(entity);
    }
}

/*
by:Milan Manji
script descrition: this script is used to find, refrence and load mesh and materials from an array 

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mesh_material_IDs : MonoBehaviour
{
    public Mesh[] mesh_list;
    public Material[] material_list;


    public static Mesh[] meshes;
    public static Material[] materials;

    private void Awake()
    {
        meshes = mesh_list;
        materials = material_list;

    }


    public struct mesh_and_mat
    {
        public Mesh mesh;
        public Material mat;
    }
    //grabs the mesh and material refrence from a static array
    public static Vector2 getIntID(Mesh mesh,Material mat)
    {
        Vector2 ID = new Vector2();
        for(int i=0;meshes.Length>i; i++)
        {
            if (mesh == meshes[i])
                ID.x = i;
        }

        for (int i = 0; materials.Length > i; i++)
        {
            if (mat == materials[i])
                ID.y = i;
        }

        return ID;
    }
    // grabs a mesh and material from a astatic array usig an int refrence
    public static mesh_and_mat get_mesh_and_mat(int mesh, int mat)
    {
        mesh_and_mat MAT = new mesh_and_mat();
        MAT.mesh = meshes[mesh];
        MAT.mat = materials[mat];

        return MAT;
    }
}

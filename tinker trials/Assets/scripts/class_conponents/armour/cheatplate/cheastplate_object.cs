using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "cheastplate", menuName = "armour/cheastplate", order = 1)]
public class cheastplate_object : ScriptableObject
{
    public int deffence;
    public float weight;
    public int specicality;
    public Mesh mesh;
    public Material material;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "barrel", menuName = "wepon parts/barrel", order = 1)]
public class barrel_object : ScriptableObject
{
    public int lenght;
    public int material;
    public int fit;
   // public Vector3[] attachment_Slots;
    public int specalty;
    public float weight;
    public Mesh mesh;
    public Material mat;
}

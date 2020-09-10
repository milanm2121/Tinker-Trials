using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "scope", menuName = "wepon parts/scope", order = 1)]
public class scope_object : ScriptableObject
{
    public int zoom;
    public bool trhermal;
    public int speciality;
    public float weight;
    public Mesh mesh;
    public Material mat;
}

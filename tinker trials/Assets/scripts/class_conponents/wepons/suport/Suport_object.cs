using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "suport", menuName = "wepon parts/suport", order = 1)]
public class Suport_object : ScriptableObject
{
    public float weight;
    public int speciality;
    public Mesh mesh;
    public Material mat;
}

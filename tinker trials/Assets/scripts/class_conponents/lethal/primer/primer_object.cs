using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "primer", menuName = "leathal/primer", order = 1)]
public class primer_object : ScriptableObject
{
    public bool manual;
    public int timer;
    public int speciality;
    public Mesh mesh;
    public Material mat;
}

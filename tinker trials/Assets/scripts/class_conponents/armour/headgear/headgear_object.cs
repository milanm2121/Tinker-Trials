using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "head_gear", menuName = "armour/headgear", order = 1)]

public class headgear_object : ScriptableObject
{
    public int deffence;
    public float weight;
    public int speciality;
    public Mesh mesh;
    public Material mat;
}

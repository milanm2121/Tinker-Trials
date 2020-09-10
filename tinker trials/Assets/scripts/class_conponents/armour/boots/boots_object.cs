using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "boots", menuName = "armour/boots", order = 1)]
public class boots_object : ScriptableObject
{
    public int deffence;
    public float weight;
    public int speciality;
    public Mesh mesh;
    public Material mat;
}

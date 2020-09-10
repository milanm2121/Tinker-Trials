using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "amunition", menuName = "wepon parts/amunition", order = 1)]
public class amunition_object : ScriptableObject
{
    public int range;
    public int prjectile;
    public int blast_radius;
    public int element;
    public int damage;
    public int speciality;
    public int rounds;
    public float weight;
    public Mesh mesh;
    public Material mat;
}

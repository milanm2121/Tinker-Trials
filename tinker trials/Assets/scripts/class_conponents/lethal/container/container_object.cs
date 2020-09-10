using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "contariner", menuName = "leathal/contariner", order = 1)]
public class container_object : ScriptableObject
{
    public int type;
    public int weight;
    public bool sticky;
    public int speciality;
    public Mesh mesh;
    public Material mat;
}

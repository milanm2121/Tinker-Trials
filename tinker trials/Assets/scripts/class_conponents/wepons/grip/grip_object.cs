using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "grip", menuName = "wepon parts/grip", order = 1)]
public class grip_object : ScriptableObject
{
    public int grip_angle;
    public int speciality;
    public float weight;
    public Mesh meshshape;
    public Material mat;
}

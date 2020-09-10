using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "reciver", menuName = "wepon parts/reciver", order = 1)]
public class weponReciver_object : ScriptableObject
{
    public Vector3 barrel_fit;
    public Vector3 grip_fit;
    public Vector3 scope_fit;
    public Vector3 anumition_fit;
    public Vector3 suport_fit;

    public int wepon_type;
    public int fire_rate;
    public int element;
    public int spciality;
    public int fit;
    public float weight;
    public Mesh mesh;
    public Material mat;
    
}

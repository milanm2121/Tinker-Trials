using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wepon_reciver : MonoBehaviour
{
    public Vector3 barrel_fit;
    public Vector3 grip_fit;
    public Vector3 scope_fit;
    public Vector3 anumition_fit;
    public Vector3 suport_fit;

    public struct reciver{
        public int wepon_type;
        public float fire_rate;
        public int element;
        public int spciality;
        public int fit;
        public float weight;
    };
    public weponReciver_object RO;
    public reciver Reciver;
    public void generateRecever()
    {
        barrel_fit = RO.barrel_fit;
        grip_fit = RO.grip_fit;
        scope_fit = RO.scope_fit;
        anumition_fit = RO.anumition_fit;
        suport_fit = RO.suport_fit;
        Reciver.wepon_type = RO.wepon_type;
        Reciver.fire_rate = RO.fire_rate;
        Reciver.element = RO.element;
        Reciver.spciality = RO.spciality;
        Reciver.fit = RO.fit;
        Reciver.weight = RO.weight;
        GetComponent<MeshFilter>().mesh = RO.mesh;
        
        Material[] x = GetComponent<MeshRenderer>().materials;
        for(int i=0;x.Length>i; i++)
        {
            x[i] = RO.mat;
        }
        GetComponent<MeshRenderer>().materials = x;

    }
    
}

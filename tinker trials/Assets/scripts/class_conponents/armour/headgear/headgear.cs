/*
by:Milan Manji
script descrition: this script is used for generating headgear find refrence to this script in the amunition section because of its basicly the same

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headgear : MonoBehaviour
{
    public struct Headgear
    {
        public int deffence;
        public float weight;
        public int speciality;
    }

    public Headgear HeadGear;
    public headgear_object HGO;

    public void Generate_headGear()
    {
        HeadGear.deffence = HGO.deffence;
        HeadGear.weight = HGO.weight;
        HeadGear.speciality = HGO.speciality;
        GetComponent<MeshFilter>().mesh = HGO.mesh;
        GetComponent<MeshRenderer>().material = HGO.mat;
    }    
}

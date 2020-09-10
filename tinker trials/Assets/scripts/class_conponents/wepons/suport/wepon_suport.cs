using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wepon_suport : MonoBehaviour
{

    public struct wepon_support{
        public float weight;
        public int speciality;
    };
    public wepon_support support;
    public Suport_object SO;
    public void generateSuport()
    {
        support.weight = SO.weight;
        support.speciality = SO.speciality;
        GetComponent<MeshFilter>().mesh = SO.mesh;
        GetComponent<MeshRenderer>().material = SO.mat;
    }
}

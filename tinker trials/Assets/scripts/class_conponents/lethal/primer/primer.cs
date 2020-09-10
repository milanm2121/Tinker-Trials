using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class primer : MonoBehaviour
{
    public struct Primer_
    {
        public bool manual;
        public int timer;
        public int speciality;
    }

    public Primer_ Primer;
    public primer_object PO;

    public void GeneratePrimer()
    {
        Primer.manual = PO.manual;
        Primer.timer = PO.timer;
        Primer.speciality = PO.speciality;
        GetComponent<MeshFilter>().mesh = PO.mesh;
        GetComponent<MeshRenderer>().material = PO.mat;
    }
}

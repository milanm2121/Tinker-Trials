using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wepon_scope : MonoBehaviour
{

    public struct scope
    {
        public int zoom;
        public bool trhermal;
        public int speciality;
        public float weight;
    };
    public scope Scope;
    public scope_object SO;
    public void generateScope()
    {
        Scope.zoom = SO.zoom;
        Scope.trhermal = SO.trhermal;
        Scope.speciality = SO.speciality;
        Scope.weight = SO.weight;
        GetComponent<MeshFilter>().mesh = SO.mesh;
        GetComponent<MeshRenderer>().material = SO.mat;
    }


}

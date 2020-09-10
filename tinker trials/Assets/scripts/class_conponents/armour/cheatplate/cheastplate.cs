/*
by:Milan Manji
script descrition: this script is used for generating chestplates find refrence to this script in the amunition section because of its basicly the same

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cheastplate : MonoBehaviour
{
    public struct Cheastplate
    {
        public int deffence;
        public float weight;
        public int speciality;
    }
    public Cheastplate CheastPlate;
    public cheastplate_object CPO;
    public void gerateCheastPlate()
    {
        CheastPlate.deffence = CPO.deffence;
        CheastPlate.weight = CPO.weight;
        CheastPlate.speciality = CPO.specicality;
        GetComponent<MeshFilter>().mesh = CPO.mesh;
        GetComponent<MeshRenderer>().material = CPO.material;
        
    }

}

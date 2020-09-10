/*
by:Milan Manji
script descrition: this script is used for generating boots find refrence to this script in the amunition section because of its basicly the same

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boots_scripts : MonoBehaviour
{
    // Start is called before the first frame update
    [System.Serializable]
    public struct boots
    {
        public int deffence;
        public float weight;
        public int speciality;
    };
    public boots Boots;
    public boots_object BO;

    // Update is called once per frame
    public void generateBoots()
    {
        Boots.deffence = BO.deffence;
        Boots.weight = BO.weight;
        Boots.speciality = BO.speciality;
        GetComponent<MeshFilter>().mesh = BO.mesh;
        GetComponent<MeshRenderer>().material = BO.mat;
    }
}

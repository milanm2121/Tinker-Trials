using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wepon_barrel : MonoBehaviour
{
    public struct Barrel {
        public int lenght;
        public int material;
        public int fit;
        public Vector3[] attachment_Slots;
        public int specalty;
        public float weight;
    };
    public barrel_object BO;
    public Barrel barrel;
    
    public void generateBarrel()
    {
        barrel.lenght = BO.lenght;
        barrel.material = BO.material;
        barrel.fit = BO.fit;
//        barrel.attachment_Slots = BO.attachment_Slots;
        barrel.specalty = BO.specalty;
        barrel.weight = BO.weight;
        GetComponent<MeshFilter>().mesh= BO.mesh;
        GetComponent<MeshRenderer>().material = BO.mat;
    }
    
}
 
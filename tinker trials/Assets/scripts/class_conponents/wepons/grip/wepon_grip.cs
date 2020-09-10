using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wepon_grip : MonoBehaviour
{

    public struct grip
    {
        public int grip_angle;
        public int speciality;
        public float weight;
        
    };
    public grip Grip;
    public grip_object GO;
    public void generateGip()
    {
        Grip.grip_angle = GO.grip_angle;
        Grip.speciality = GO.speciality;
        Grip.weight = GO.weight;
        GetComponent<MeshFilter>().mesh = GO.meshshape;
        GetComponent<MeshRenderer>().material = GO.mat;
    }
}

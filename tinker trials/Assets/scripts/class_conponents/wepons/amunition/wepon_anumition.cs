/*
by:Milan Manji
script descrition: this script holds the amunition componet basicly a struct and a scriptable object slot,
this is used to generate the object in game

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wepon_anumition : MonoBehaviour
{

    public struct amunition
    {
        public int range;
        public int prjectile;
        public int blast_radius;
        public int element;
        public int damage;
        public int speciality;
        public int rounds;
        public float weight;
        
    };
    public amunition Amunition;
    public amunition_object AO;
    public void generateObject()
    {
        Amunition.range = AO.range;
        Amunition.prjectile = AO.prjectile;
        Amunition.blast_radius = AO.blast_radius;
        Amunition.element = AO.element;
        Amunition.damage = AO.damage;
        Amunition.speciality = AO.speciality;
        Amunition.rounds = AO.rounds;
        Amunition.weight = AO.weight;
        GetComponent<MeshFilter>().mesh = AO.mesh;
        GetComponent<MeshRenderer>().material = AO.mat;

    }
}

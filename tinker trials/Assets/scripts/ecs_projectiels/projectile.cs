/*
by:Milan Manji
script descrition: this script holds the ECS data that makes up the projectile componet



NOTE: DO NOT TOUCH THIS SCRIPT PLEASE

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public struct projectile : IComponentData
{
    public Vector3 velosity;
    public projectileREf REf;
    public float distance;
    public bool Predict_hit;
    public Vector3 contact_point;
}

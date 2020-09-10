using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public struct projectile_explosion : IComponentData
{
    public float damage;
    public float current_size;
    public float blast_radious;
    public Vector2Int element;
    public bool tick;
}

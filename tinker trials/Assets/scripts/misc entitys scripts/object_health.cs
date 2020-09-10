using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class object_health : MonoBehaviour
{
    public int health;
    
    public void damage_object(int damage)
    {
        health -= damage;
    }
    
}

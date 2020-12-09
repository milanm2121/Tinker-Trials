using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class object_health : MonoBehaviour
{
    public int health;
    public GameObject damage_numbers_UI_Canvas;
    public GameObject damage_numbers;

    public void damage_object(int damage)
    {
        health -= (int)damage;
        GameObject UI_can = Instantiate(damage_numbers_UI_Canvas, transform.position + Vector3.up*2, Quaternion.identity);
        GameObject base_damage = Instantiate(damage_numbers, UI_can.transform);
        base_damage.GetComponent<damage_numbers>().damage((int)damage, 0);

        

    }

}

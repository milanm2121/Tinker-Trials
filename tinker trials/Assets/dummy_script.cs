using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dummy_script : MonoBehaviour
{
    public float health;

    public GameObject damage_numbers_UI_Canvas;
    public GameObject damage_numbers;

    public Collider[] ragdoll;
    public Rigidbody[] ragdoll2;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            animator.enabled = false;
            foreach (Collider collider in ragdoll)
            {
                collider.enabled = true;

            }
            foreach (Rigidbody rigidbody in ragdoll2)
            {
                rigidbody.isKinematic = false;
            }
            Destroy(GetComponent<Rigidbody>());
            Destroy(gameObject, 3);



        }
        else
        {
            animator.enabled = true;
            foreach (Collider collider in ragdoll)
            {
                collider.enabled = false;
            }
            // Skeleton.SetActive(false);
        }
    }
    public void damage_player(float damage, Vector2Int element)
    {
        //damage armour calculation
        
        health -= (int)damage;
        GameObject UI_can = Instantiate(damage_numbers_UI_Canvas, transform.position, Quaternion.identity);
        GameObject base_damage = Instantiate(damage_numbers, UI_can.transform);
        base_damage.GetComponent<damage_numbers>().damage((int)damage, 0);

        if (element.x == 1)
        {
            
            GameObject elemental_damage = Instantiate(damage_numbers, UI_can.transform);
            elemental_damage.GetComponent<damage_numbers>().damage((int)damage * 2, 1);
        }
        if (element.x == 2)
        {
            
            GameObject elemental_damage = Instantiate(damage_numbers, UI_can.transform);
            elemental_damage.GetComponent<damage_numbers>().damage((int)damage, 2);
        }
        if (element.x == 3)
        {
            
            GameObject elemental_damage = Instantiate(damage_numbers, UI_can.transform);
            elemental_damage.GetComponent<damage_numbers>().damage((int)damage * 2, 3);
        }
        if (element.x == 4)
        {
            
            GameObject elemental_damage = Instantiate(damage_numbers, UI_can.transform);
            elemental_damage.GetComponent<damage_numbers>().damage((int)damage * 2, 4);
        }


        if (element.y == 1)
        {
            
            GameObject elemental_damage = Instantiate(damage_numbers, UI_can.transform);
            elemental_damage.GetComponent<damage_numbers>().damage((int)damage * 2, 1);
        }
        if (element.y == 2)
        {
            
            GameObject elemental_damage = Instantiate(damage_numbers, UI_can.transform);
            elemental_damage.GetComponent<damage_numbers>().damage((int)damage * 2, 2);
        }
        if (element.y == 3)
        {
            
            GameObject elemental_damage = Instantiate(damage_numbers, UI_can.transform);
            elemental_damage.GetComponent<damage_numbers>().damage((int)damage * 2, 3);
        }
        if (element.y == 4)
        {
            
            GameObject elemental_damage = Instantiate(damage_numbers, UI_can.transform);
            elemental_damage.GetComponent<damage_numbers>().damage((int)damage * 2, 4);
        }

    }
}

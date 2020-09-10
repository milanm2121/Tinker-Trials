/*
by:Milan Manji
script descrition: (unused) dont bother using this script


*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hand_script : MonoBehaviour
{
    GameObject left_Hand;
    Transform left_Hand_Holder;
    GameObject right_Hand;
    Transform right_Hand_Holder;

    public float hand_Speed;
    public float arm_lenght;
    GameObject head;

    public float defalt_Left_Hand_Distance;
    public float defalt_Right_Hand_Distance;

    public float reach_Distance;
    //moves hand
    bool left_Hand_action=false;
    //cheaks if collision/racast hit is true
    bool left_hand_hit = false;

    //moves hand
    bool right_Hand_action = false;
    //cheaks if collision/racast hit is true
    bool right_Hand_Hit = false;

    // Start is called before the first frame update
    void Start()
    {
        left_Hand = gameObject.transform.GetChild(0).gameObject;
        right_Hand = gameObject.transform.GetChild(2).gameObject;
        head = transform.parent.gameObject;


        left_Hand_Holder = gameObject.transform.GetChild(1).transform;
        right_Hand_Holder = gameObject.transform.GetChild(3).transform;
    }

    // Update is called once per frame
    void Update()
    {
        //left hand

        if (Input.GetMouseButtonDown(1))
        {
            left_Hand_action = true;
        }

        if (left_Hand_action == true)
        {
            left_Hand.transform.Translate(Vector3.forward*(hand_Speed/100));
            if (Vector3.Distance(left_Hand.transform.position, left_Hand_Holder.position) > arm_lenght)
            {

                if (Physics.Raycast(head.transform.position, transform.TransformDirection(Vector3.forward), reach_Distance))
                {
                    print("Left hit");
                    left_hand_hit = true;
                }
                left_Hand_action = false;
            }
        }
        if (left_Hand_action == false)
        {
            if (Vector3.Distance(left_Hand.transform.position, left_Hand_Holder.position) >0.2)
                left_Hand.transform.Translate(Vector3.back * (hand_Speed / 100));

            if (Vector3.Distance(left_Hand.transform.position, left_Hand_Holder.position) <= 0.2)
                left_Hand.transform.position = left_Hand_Holder.position;
        }

        //right hand
        if (Input.GetMouseButtonDown(0))
        {
            right_Hand_action = true;
        }

        if (right_Hand_action == true)
        {
            right_Hand.transform.Translate(Vector3.forward * (hand_Speed / 100));
            if (Vector3.Distance(right_Hand.transform.position, right_Hand_Holder.position) > arm_lenght)
            {
                if (Physics.Raycast(head.transform.position, transform.TransformDirection(Vector3.forward), reach_Distance))
                {
                    print("Right hit");
                    right_Hand_Hit = true;
                }
                right_Hand_action = false;
            }
        }
        if (right_Hand_action == false)
        {
            if (Vector3.Distance(right_Hand.transform.position, right_Hand_Holder.position) > 0.2)
                right_Hand.transform.Translate(Vector3.back * (hand_Speed / 100));

            if (Vector3.Distance(right_Hand.transform.position, right_Hand_Holder.position) <= 0.2)
                right_Hand.transform.position = right_Hand_Holder.position;
        }
    }
}

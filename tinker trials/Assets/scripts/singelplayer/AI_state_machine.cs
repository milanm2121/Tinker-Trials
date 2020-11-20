using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_state_machine : MonoBehaviour
{
    public pathfinding pathfinding;
    public player_stats PS;

    public player_Movement PM;
    public GameObject playerSpine;

    public wepon_body_game WBG;

    public Transform pathfindingTarget;

    public player_ID P_ID;

    public GameObject shooting_target;
    public player_stats target_stats;

    public game_maneger GM;

    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
      //  pathfinding.pathfining();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (PS.health > 0)
        {
            if (shooting_target == null || Vector3.Distance(transform.position,shooting_target.transform.position)>10)
            {
                movement();
            }
            shoot();
        }
        else
        {
            WBG.AI_shooting = false;
        }

        if (pathfindingTarget == null)
        {
            if (P_ID.team == 2)
            {
                pathfindingTarget = GM.team1[Random.Range(0, GM.team1.Count)].transform;
            }
            else
            {
                pathfindingTarget = GM.team2[Random.Range(0, GM.team2.Count)].transform;
            }
        }

    }

    private void FixedUpdate()
    {
        time += Time.deltaTime;
        if (time > 3)
        {
            time = 0;

            pathfinding.reset_pathfinding();
            pathfinding.target = pathfindingTarget;
            pathfinding.pathfining();

        }
    }

    void movement()
    {
        

        if (pathfinding.bestPath.Count != 0)
        {
            Vector3 CNPos = pathfinding.bestPath[pathfinding.current_node].pos;
            // transform.LookAt(new Vector3(CNPos.x,transform.position.y,CNPos.z));
            if (Vector3.Distance(transform.position, new Vector3(CNPos.x, transform.position.y, CNPos.z)) < 1)
            {
                pathfinding.current_node++;
            }

            //rotational offset
            float directional_offset_radian = transform.rotation.eulerAngles.y * Mathf.Deg2Rad;
            float directional_offset_degree = transform.rotation.eulerAngles.y;


            Vector2 directional_offset_vecter2 = new Vector2(Mathf.Cos(directional_offset_radian), Mathf.Sin(directional_offset_radian)).normalized;


            //positional offset
            Vector2 pointoffset = (new Vector2(CNPos.x, CNPos.z) - new Vector2(transform.position.x, transform.position.z)).normalized;

            float angel = (Mathf.Atan2(directional_offset_vecter2.y, directional_offset_vecter2.x) + Mathf.Atan2(pointoffset.y, pointoffset.x)) * Mathf.Rad2Deg;

            Vector2 shidted_pointoffset = new Vector2(Mathf.Cos(angel * Mathf.Deg2Rad), Mathf.Sin(angel * Mathf.Deg2Rad)).normalized;


            if (shidted_pointoffset.x > 0.1f)
            {
                PM.AI_right();
            }
            else if (shidted_pointoffset.x < -0.1f)
            {
                PM.AI_left();
            }

            if (shidted_pointoffset.y > 0.1f)
            {
                PM.AI_forward();
            }
            else if (shidted_pointoffset.y < -0.1f)
            {
                PM.AI_back();
            }

            // PM.AI_forward();
            if (pathfinding.current_node == pathfinding.bestPath.Count)
            {
                pathfinding.reset_pathfinding();
                pathfinding.target = pathfindingTarget;
                pathfinding.pathfining();
            }
        }
        
    }

    void shoot()
    {
        if (shooting_target == null)
        {
            WBG.AI_shooting = false;
            Collider[] col = Physics.OverlapSphere(transform.position, 10);
            for (int i = 0; col.Length > i; i++)
            {
                if (col[i].GetComponent<player_ID>() != null && col[i].GetComponent<player_ID>().team != P_ID.team && col[i].GetComponent<player_stats>().health>0)
                {
                    shooting_target = col[i].gameObject;
                    target_stats = shooting_target.GetComponent<player_stats>();
                }
            }

        }
        else
        {
            transform.LookAt(new Vector3(shooting_target.transform.position.x, transform.position.y, shooting_target.transform.position.z));
            playerSpine.gameObject.transform.LookAt(shooting_target.transform.position);

            RaycastHit hit;
            Physics.Raycast(WBG.transform.position,shooting_target.transform.position- WBG.transform.position, out hit);
            if (hit.collider.gameObject == shooting_target)
            {
                WBG.AI_shooting = true;
            }
            else
            {
                WBG.AI_shooting = false;
            }

            if (target_stats.health < 0)
            {
                shooting_target = null;
                target_stats = null;
                pathfindingTarget = null;
            }

        }
    }
}

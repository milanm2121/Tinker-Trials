using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_state_machine : MonoBehaviour
{
    public pathfinding pathfinding;
    public player_stats PS;

    public player_Movement PM;

    public wepon_body_game WBG;

    public Transform pathfindingTarget;

    public player_ID P_ID;

    public GameObject shooting_target;
    public player_stats target_stats;

    public game_maneger GM;

    public GameObject Camera;
    float time = 0;
    public bool use_GM;
    // Start is called before the first frame update
    void Start()
    {
        //  pathfinding.pathfining();
        GM = GameObject.Find("game maneger").GetComponent<game_maneger>();

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (pathfindingTarget!=null && Vector3.Distance(pathfindingTarget.position, gameObject.transform.position) < 100)
        {
            if (PS.health > 0 && pathfindingTarget != null)
            {
                if (shooting_target == null || Vector3.Distance(transform.position, shooting_target.transform.position) > 10)
                {
                    movement();
                    Debug.Log("moving");
                    shooting_target = null;
                }
                shoot();
            }
            else
            {
                WBG.AI_shooting = false;
            }

            if (pathfindingTarget == null && use_GM)
            {
                if (P_ID.team == 2)
                {
                    if (GM.team1[Random.Range(0, GM.team1.Count)] != null)
                        pathfindingTarget = GM.team1[Random.Range(0, GM.team1.Count)].transform;
                }
                else
                {
                    if (GM.team2[Random.Range(0, GM.team2.Count)] != null)
                        pathfindingTarget = GM.team2[Random.Range(0, GM.team2.Count)].transform;
                }
            }
        }
        if (use_GM == false && game_maneger.playerinstance!=null && Vector3.Distance(game_maneger.playerinstance.transform.position, gameObject.transform.position) < 50)
        {
            pathfindingTarget = game_maneger.playerinstance.transform;
        }
    }

    private void FixedUpdate()
    {
        time += Time.deltaTime;
        if (time > 3 && pathfindingTarget!=null && Vector3.Distance(pathfindingTarget.position, gameObject.transform.position)>20)
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
                

                if (use_GM=true && col[i].GetComponent<player_ID>() != null && col[i].GetComponent<player_ID>().team != P_ID.team && col[i].GetComponent<player_stats>().health>0)
                {
                    shooting_target = col[i].gameObject;
                    target_stats = shooting_target.GetComponent<player_stats>();
                }
                else if (col[i].GetComponent<player_ID>() != null && col[i].GetComponent<player_ID>().is_player)
                {
                    shooting_target = col[i].gameObject;
                    target_stats = shooting_target.GetComponent<player_stats>();
                }
            }
            if (pathfinding.current_node != 0)
            {
                Quaternion targetx = Quaternion.LookRotation(-transform.position + new Vector3(pathfinding.bestPath[pathfinding.current_node].pos.x, transform.position.y, pathfinding.bestPath[pathfinding.current_node].pos.z), Vector3.up);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetx, Time.deltaTime * 2);
            }
            if (pathfindingTarget!=null) 
            {
                Quaternion targety = Quaternion.LookRotation(-Camera.transform.position + new Vector3(pathfindingTarget.position.x, pathfindingTarget.position.y, pathfindingTarget.position.z));
                Camera.transform.rotation = Quaternion.Lerp(Camera.transform.rotation, targety, Time.deltaTime * 2);
            }
        }
        else
        {
            Quaternion targetx = Quaternion.LookRotation(-transform.position + new Vector3(shooting_target.transform.position.x, transform.position.y, shooting_target.transform.position.z), Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetx, Time.deltaTime*2);

            Quaternion targety = Quaternion.LookRotation(-Camera.transform.position + new Vector3(shooting_target.transform.position.x, shooting_target.transform.position.y, shooting_target.transform.position.z));
            Camera.transform.rotation = Quaternion.Lerp(Camera.transform.rotation, targety, Time.deltaTime * 2);

            RaycastHit hit;
            Physics.Raycast(WBG.transform.position,-WBG.barrel.transform.right, out hit);
            Debug.DrawRay(WBG.transform.position, -WBG.barrel.transform.right, Color.green,1);
            if (hit.collider!=null && hit.collider.gameObject == shooting_target)
            {
                WBG.AI_shooting = true;
                Debug.Log("shooting");
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

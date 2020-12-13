using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_maneger : MonoBehaviour
{
    public List<player_stats> team1;
    public List<player_stats> team2;
    public GameObject prefabs;

    public Transform[] SpawnRed;
    public Transform[] SpawnBlue;
    public int MaxSpawn;

    public GameObject player;

    public bool spawn_enemy;

    public static GameObject playerinstance;
    // Start is called before the first frame update
    void Start()
    {
        if (spawn_enemy)
        {
            for (int i = 0; MaxSpawn > i; i++)
            {
                Spawn();
            }
        }
        if (team1[0]!=null)
        {
            playerinstance = team1[0].gameObject;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerinstance==null)
        {
            GameObject x= Instantiate(player, SpawnBlue[Random.Range(0, SpawnBlue.Length)].position, Quaternion.identity);
            playerinstance = x;
            team1[0] = x.GetComponent<player_stats>();
        }

        if (spawn_enemy)
        {
            if (team2.Count < MaxSpawn)
            {
                Spawn();
            }
            for (int i = 0; team2.Count > i; i++)
            {

                if (team2[i].health <= 0)
                {
                    team2.RemoveAt(i);
                }
            }
        }
    }

    void Spawn()
    {

        GameObject x = Instantiate(prefabs, SpawnRed[Random.Range(0, SpawnRed.Length)].transform.position, Quaternion.identity);
        team2.Add(x.GetComponent<player_stats>());
        x.GetComponent<AI_state_machine>().GM = this;
    }
}

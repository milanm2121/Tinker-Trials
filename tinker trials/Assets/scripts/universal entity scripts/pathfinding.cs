using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathfinding : MonoBehaviour
{
    public Transform target;

    //A*

    //what has been scaned
    List<node> scaned = new List<node>();
    //what have you come across
    List<node> been_to = new List<node>();
    //were cant u go
    List<Vector3> cant_go = new List<Vector3>();

    List<node> beentoCheack = new List<node>();
    List<List<node>> paths = new List<List<node>>();
    public List<node> bestPath = new List<node>();

    public struct node
    {
        public float value;
        public Vector3 pos;
        public float moves;
    }

    int moves = 0;

    bool reched_target = false;

    bool allPathsCheacked = false;

    bool isPathfinding = false;

    public int current_node = 0;

    int times_pathfinding = 0;

    public GameObject visualnode;
    // Start is called before the first frame update
    void Start()
    {
      //  pathfining();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void reset_pathfinding()
    {
        moves = -1;

        paths.Clear();
        cant_go.Clear();
        bestPath.Clear();
        reched_target = false;

        isPathfinding = false;
        current_node = 0;
    }

    public void pathfining()
    {
        times_pathfinding++;
        //        Debug.Log(times_pathfinding);
        isPathfinding = true;
        //initolize pathfining
        print("pathfinding....");
        bool failed = false;
        Vector3 startingVector = transform.position;
        scaned.Clear();
        been_to.Clear();
        been_to.Add(new node { pos = startingVector, value = getMovementValue(0, startingVector), moves = 0 });
        scaned.Add(been_to[0]);
        beentoCheack.Clear();

        reched_target = false;
        allPathsCheacked = false;

        int cheacks = 0;

        //this loop cheask the node with the lowest value (move + distance) in the boon to list
        while (reched_target == false && cheacks < 100)
        {
            cheacks += 1;
            moves += 1;
            List<node> options_to_add = new List<node>();
            node testedposition = been_to[been_to.Count - 1];

            bool tick = false;
            for (int i = 0; been_to.Count > i; i++)
            {
                //finds the lowest value for scaning
                if (been_to[i].value < testedposition.value && !scaned.Contains(been_to[i]))
                {
                    testedposition = been_to[i];
                }
                else
                {
                    tick = true;
                }

            }
            //       Debug.Log("moves:"+testedposition.moves +", pos: "+testedposition.pos +", value:"+ testedposition.value);
            been_to.AddRange(scanSuroundings(testedposition.moves, testedposition.pos, out failed));
            scaned.Add(testedposition);
            //Instantiate(visualnode, testedposition.pos, Quaternion.identity);


            //last resort
            if (tick == true && scaned.Count >= been_to.Count && been_to.Count != 0 && moves != 0)
            {
                allPathsCheacked = true;
            }

        }
        //resets the pathfiding and grid and values
        if (allPathsCheacked == true || reched_target == false)
        {

            print("can't reach target, moves taken: " + moves);
            reset_pathfinding();

            target = null;


        }
        else
        {
            //finds the best path
            beentoCheack.Clear();

            bestPath.Add(new node { pos = target.transform.position });
            beentoCheack.Add(bestPath[0]);
            for (int i = 0; been_to.Count > i; i++)
            {
                node x;
                if (bestPath.Count == 0)
                {
                    reset_pathfinding();
                    return;
                }

                x = findLowestValueNeighbor(bestPath[bestPath.Count - 1], out failed);

                if (failed == false)
                {
                    bestPath.Add(x);


                    if (bestPath[bestPath.Count - 1].pos == startingVector)
                    {
                        i = been_to.Count;
                    }
                }

            }


            bestPath.Reverse();

            for (int i = 0; bestPath.Count > i; i++)
            {
    //            Instantiate(visualnode, bestPath[i].pos, Quaternion.identity);
            }

        }
    }

    //finds the lowest node value around the surounding node
    node findLowestValueNeighbor(node origonalnode, out bool failed)
    {
        failed = false;

        Vector3 position1 = new Vector3((int)origonalnode.pos.x + 2, (int)origonalnode.pos.y, (int)origonalnode.pos.z);
        Vector3 position2 = new Vector3((int)origonalnode.pos.x - 2, (int)origonalnode.pos.y, (int)origonalnode.pos.z);
        Vector3 position3 = new Vector3((int)origonalnode.pos.x, (int)origonalnode.pos.y, (int)origonalnode.pos.z + 2);
        Vector3 position4 = new Vector3((int)origonalnode.pos.x, (int)origonalnode.pos.y, (int)origonalnode.pos.z - 2);

        Vector3 position5 = new Vector3((int)origonalnode.pos.x + 2, (int)origonalnode.pos.y, (int)origonalnode.pos.z + 2);
        Vector3 position6 = new Vector3((int)origonalnode.pos.x + 2, (int)origonalnode.pos.y, (int)origonalnode.pos.z - 2);
        Vector3 position7 = new Vector3((int)origonalnode.pos.x - 2, (int)origonalnode.pos.y, (int)origonalnode.pos.z + 2);
        Vector3 position8 = new Vector3((int)origonalnode.pos.x - 2, (int)origonalnode.pos.y, (int)origonalnode.pos.z - 2);


        List<node> nodeCheack = new List<node>();

        nodeCheack.Add(testfornode(position1));

        nodeCheack.Add(testfornode(position2));

        nodeCheack.Add(testfornode(position3));

        nodeCheack.Add(testfornode(position4));


        //
        nodeCheack.Add(testfornode(position5));

        nodeCheack.Add(testfornode(position6));

        nodeCheack.Add(testfornode(position7));

        nodeCheack.Add(testfornode(position8));


        node bestnode;


        bestnode = new node { moves = int.MaxValue, value = int.MaxValue };
        bool deadend = true;
        for (int i = 0; nodeCheack.Count > i; i++)
        {
            if (bestnode.moves > nodeCheack[i].moves && !bestPath.Contains(nodeCheack[i]))
            {
                bestnode = nodeCheack[i];
                deadend = false;
            }
        }
        if (deadend == true)
        {
            bestPath.RemoveAt(bestPath.Count - 1);
            failed = true;
        }
        beentoCheack.Add(bestnode);
        return bestnode;


    }


    //scans the suroudung and creates a list of node
    List<node> scanSuroundings(float move, Vector3 position, out bool failed)
    {
        failed = true;

        Vector3 position1 = new Vector3((int)position.x + 2, position.y, (int)position.z);
        Vector3 position2 = new Vector3((int)position.x - 2, position.y, (int)position.z);
        Vector3 position3 = new Vector3((int)position.x, position.y, (int)position.z + 2);
        Vector3 position4 = new Vector3((int)position.x, position.y, (int)position.z - 2);

        Vector3 position5 = new Vector3((int)position.x + 2, position.y, (int)position.z + 2);
        Vector3 position6 = new Vector3((int)position.x + 2, position.y, (int)position.z - 2);
        Vector3 position7 = new Vector3((int)position.x - 2, position.y, (int)position.z + 2);
        Vector3 position8 = new Vector3((int)position.x - 2, position.y, (int)position.z - 2);


        float posvalue1 = 100;
        float posvalue2 = 100;
        float posvalue3 = 100;
        float posvalue4 = 100;

        float posvalue5 = 100;
        float posvalue6 = 100;
        float posvalue7 = 100;
        float posvalue8 = 100;


        if (testposition(position,position1, out position1) == true)
        {
            posvalue1 = getMovementValue(move, position1);
        }
        if (testposition(position,position2, out position2) == true)
        {
            posvalue2 = getMovementValue(move, position2);
        }
        if (testposition(position,position3, out position3) == true)
        {
            posvalue3 = getMovementValue(move, position3);
        }
        if (testposition(position,position4, out position4) == true)
        {
            posvalue4 = getMovementValue(move, position4);
        }
        //diagonal
        if (testposition(position,position5, out position5) == true)
        {
            Vector3 T = position5;
            posvalue5 = getMovementValue(move + 0.4f, position5);


        }
        if (testposition(position,position6, out position6) == true)
        {
            Vector3 T = position6;
            posvalue6 = getMovementValue(move + 0.4f, position6);

        }
        if (testposition(position,position7, out position7) == true)
        {
            Vector3 T = position7;
            posvalue7 = getMovementValue(move + 0.4f, position7);

        }
        if (testposition(position,position8, out position8) == true)
        {
            Vector3 T = position8;
            posvalue8 = getMovementValue(move + 0.4f, position8);

        }

        bool pos1tick = false;
        bool pos2tick = false;
        bool pos3tick = false;
        bool pos4tick = false;

        bool pos5tick = false;
        bool pos6tick = false;
        bool pos7tick = false;
        bool pos8tick = false;


        List<node> possable_nodes = new List<node>();
        for (int i = 0; 100 > i; i++)
        {
            if (posvalue1 <= i && pos1tick == false)
            {
                possable_nodes.Add(new node { pos = position1, value = posvalue1, moves = move + 1 });
                pos1tick = true;
            }
            if (posvalue2 <= i && pos2tick == false)
            {
                possable_nodes.Add(new node { pos = position2, value = posvalue2, moves = move + 1 });
                pos2tick = true;

            }
            if (posvalue3 <= i && pos3tick == false)
            {
                possable_nodes.Add(new node { pos = position3, value = posvalue3, moves = move + 1 });
                pos3tick = true;

            }
            if (posvalue4 <= i && pos4tick == false)
            {
                possable_nodes.Add(new node { pos = position4, value = posvalue4, moves = move + 1 });
                pos4tick = true;

            }

            //////
            if (posvalue5 <= i && pos5tick == false)
            {
                possable_nodes.Add(new node { pos = position5, value = posvalue5, moves = move + 1 });
                pos5tick = true;

            }
            if (posvalue6 <= i && pos6tick == false)
            {
                possable_nodes.Add(new node { pos = position6, value = posvalue6, moves = move + 1 });
                pos6tick = true;

            }
            if (posvalue7 <= i && pos7tick == false)
            {
                possable_nodes.Add(new node { pos = position7, value = posvalue7, moves = move + 1 });
                pos7tick = true;

            }
            if (posvalue8 <= i && pos8tick == false)
            {
                possable_nodes.Add(new node { pos = position8, value = posvalue8, moves = move + 1 });
                pos8tick = true;

            }





        }
        if (possable_nodes.Count != 0)
        {
            failed = false;
            return possable_nodes;
        }




        return possable_nodes;


    }
    //test to see if the postion is viable to go to
    bool testposition(Vector3 origonalPos, Vector3 pos, out Vector3 pos_plus_y)
    {
        bool can_go = false;
        Vector3 testPos = new Vector3((int)pos.x, pos.y + 2, (int)pos.z);
        RaycastHit hit;
        RaycastHit hit1;
        Physics.Raycast(origonalPos, pos-origonalPos, out hit1, 2);

        Physics.Raycast(testPos, Vector3.down, out hit, 5);
        pos_plus_y = pos;

        

        if (hit.collider == null || hit.collider.tag != "ground" || hit1.collider!=null)
        {
            cant_go.Add(pos);
        }
        else
        {
            pos_plus_y = new Vector3(pos.x, hit.point.y, pos.z);
            can_go = true;
            for (int i = 0; been_to.Count > i; i++)
            {
                if ((int)been_to[i].pos.x == (int)pos.x && (been_to[i].pos.y - 0.2f <= pos.y && been_to[i].pos.y + 0.2f >= pos.y) && (int)been_to[i].pos.z == (int)pos.z)

                    can_go = false;

            }
        }
        return can_go;
    }
    //test to see if nod is in the been to list
    node testfornode(Vector3 pos)
    {
        Vector3 testPos = new Vector3((int)pos.x, pos.y + 1, (int)pos.z);
        RaycastHit hit;
        Physics.Raycast(testPos, Vector3.down, out hit, 5);

        pos = new Vector3(pos.x, hit.point.y, pos.z);

        for (int i = 0; been_to.Count > i; i++)
        {
            if ((int)been_to[i].pos.x == (int)pos.x && (been_to[i].pos.y - 5 <= pos.y && been_to[i].pos.y + 5 >= pos.y) && (int)been_to[i].pos.z == (int)pos.z)
            {
                return been_to[i];
            }
        }
        return new node { value = int.MaxValue, moves = int.MaxValue };
    }

    //gets the movement vale
    float getMovementValue(float move, Vector3 pos)
    {

        float distance_from_targt = 0;


        distance_from_targt = Vector3.Distance(pos, target.transform.position);



        //if the target is reached
        if (distance_from_targt <= 2 && reched_target == false)
        {
            reched_target = true;

            print("path:" + paths.Count + " " + "reched target in: " + (moves + 1) + "moves");

            bestPath.Add(new node { pos = pos, moves = move, value = move + (int)distance_from_targt });
            if (moves + 1 == 0)
            {
                allPathsCheacked = true;
            }
        }
        return move + (int)distance_from_targt;
    }

    void pathing_error_reset()
    {
        reset_pathfinding();
        pathfining();
    }
}

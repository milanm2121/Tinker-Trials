using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rope : MonoBehaviour
{
    public struct RopeNode
    {
        public GameObject node;
        public Vector3 Currenntposition;
        public Vector3 Previousposition;
    }

    public float lengt;
    public int nodes;

    public float elstisity;

    float elsticeforce=0;

    public float length_between_nodes;

    public GameObject node;
    public RopeNode[] RNodes;

    public float gravityscale;
    public float rocket_thrust;

    public float dampaning;

    public float mass;

    public bool toggel_rocket;
    public GameObject rocket;
    // Start is called before the first frame update
    void Start()
    {
        
        RNodes = new RopeNode[nodes];

        length_between_nodes = (lengt / nodes);

        //creates the node list
        RNodes[0]=(new RopeNode {node=node,Currenntposition=transform.position, Previousposition = transform.position});
        for(int i=1;nodes>i; i++)
        {
            GameObject x = Instantiate(node, transform.position - new Vector3(0, (lengt/nodes) * i, 0),Quaternion.identity);
            RNodes[i]=new RopeNode { node = x, Currenntposition = transform.position - new Vector3(0, (lengt / nodes) * i,0), Previousposition = transform.position - new Vector3(0, (lengt / nodes) * i,0)};
            x.transform.parent = transform.parent;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0;RNodes.Length>i+1; i++)
        {
            //renderlines
            LineRenderer LR = RNodes[i].node.GetComponent<LineRenderer>();
            LR.SetPosition(1, RNodes[i + 1].node.transform.position);
            LR.SetPosition(0, RNodes[i].node.transform.position);
        }
    }

    private void FixedUpdate()
    {
        float TimeD = Time.deltaTime;

        for (int i = 0; RNodes.Length > i; i++)
        {


            RNodes[i].Currenntposition = RNodes[i].node.transform.position;
            Vector3 new_pos = RNodes[i].Currenntposition;
            Vector3 dir = Vector3.zero;
            Vector3 dampaningVector = Vector3.zero;


            //gravity/velosity

            new_pos = RNodes[i].Currenntposition  + (RNodes[i].Currenntposition - RNodes[i].Previousposition + RNodes[i].node.GetComponent<Rigidbody>().velocity) *TimeD + (Vector3.down * gravityscale * TimeD)*mass;
            
            if (i != 0)
            {
                //elstisity
                elsticeforce = elstisity * (length_between_nodes - Vector3.Distance(RNodes[i].Currenntposition, RNodes[i - 1].Currenntposition));
                dir = (RNodes[i].Currenntposition - RNodes[i - 1].Currenntposition).normalized;

                // dammpaning
                dampaningVector = ((RNodes[i - 1].Currenntposition - RNodes[i - 1].Previousposition) - (RNodes[i].Currenntposition - RNodes[i].Previousposition)) *dampaning *TimeD;



                //node positions
                if (i != 1)
                {
                    RNodes[i - 1].node.transform.position += ((-dir * elsticeforce * TimeD) - dampaningVector);
                }
                else
                {
                    dir *= 2;
                }
               
            }







            //finalize node
           
            new_pos += ((dir * elsticeforce * TimeD) - dampaningVector);


            RNodes[i].node.transform.position = new_pos;
            RNodes[i].Previousposition = RNodes[i].Currenntposition;


            //rocket math
            Vector3 origon = transform.position;
            Vector3 offset = RNodes[nodes - 1].node.transform.position;
            Vector3 rocketDir=Vector3.Cross((origon - offset).normalized,Vector3.forward);


            if (toggel_rocket == true && i == nodes-1)
            {
                RNodes[i].node.transform.position = new_pos + (rocketDir * rocket_thrust * TimeD) * mass;
            }


            if (i == 0)
            {
                RNodes[i].node.transform.position = transform.position;
                RNodes[i].Currenntposition = transform.position;
                RNodes[i].Previousposition = RNodes[i].Currenntposition;
            }


            RNodes[i].node.GetComponent<Rigidbody>().velocity = Vector3.zero;


        }
    }
}

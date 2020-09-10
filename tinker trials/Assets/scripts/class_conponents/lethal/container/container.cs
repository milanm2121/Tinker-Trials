using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class container : MonoBehaviour
{
    public struct Container_
    {
        public int type;
        public int weight;
        public bool sticky;
        public int speciality;
    }
    public Container_ Container;
    public container_object CO;
    public void generateContainer()
    {
        Container.type = CO.type;
        Container.weight = CO.weight;
        Container.sticky = CO.sticky;
        Container.speciality = CO.speciality;
        GetComponent<MeshFilter>().mesh = CO.mesh;
        GetComponent<MeshRenderer>().material = CO.mat;
    }
}

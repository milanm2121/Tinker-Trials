/*
by:Milan Manji
script descrition: a scrit that holds the class template that makes up a class with the leathal wepon and armour componets;

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class class_class : MonoBehaviour
{
    [System.Serializable]
    public struct Class
    {
        public wepon Wepon;
        public armour Armour;
        public lethal Lethal;
        
    };
    [System.Serializable]
    public struct lethal
    {
        public container_object container;
        public payload_object payload;
        public primer_object primer;
    };
    [System.Serializable]
    public struct armour
    {
        public headgear_object headpeice;
        public cheastplate_object chestpeice;
        public boots_object boots;
    };
    [System.Serializable]
    public struct wepon
    {
        public barrel_object barrel;
        public grip_object grip;
        public weponReciver_object reciver;
        public amunition_object amunition;
        public scope_object scope;
        public Suport_object suport;
    };
    
}

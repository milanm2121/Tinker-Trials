using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class payload : MonoBehaviour
{
    public struct Payload_
    {
        public int element;
        public int radious;
        public int damage;
    }
    public Payload_ Payload;
    public payload_object PO;
    public void generatePayload()
    {
        Payload.element = PO.element;
        Payload.radious = PO.radious;
        Payload.damage = PO.damage;
    }
}

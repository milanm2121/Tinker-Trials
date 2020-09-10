using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class live_refrence_maneger : MonoBehaviour
{
    public static GameObject Expolsion;
    public static Material EXPdefalt;
    public static Material EXPFire;
    public static Material EXPice;
    public static Material EXPearth;
    public static Material EXPEelctrisity;

    public GameObject expolsion;
    public Material expDefalt;
    public Material expFire;
    public Material expIce;
    public Material expEarth;
    public Material expEelctrisity;

    private void Awake()
    {
        Expolsion = expolsion;
        EXPdefalt = expDefalt;
        EXPFire = expFire;
        EXPice = expIce;
        EXPearth = expEarth;
        EXPEelctrisity = expEelctrisity;
    }
}


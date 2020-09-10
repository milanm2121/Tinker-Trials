/*
by:Milan Manji
script descrition: used to load data from the start of the main menu

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class load_data : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        print("loading data");
        save_system.LoadSaveData();
        save_system.LoadSavedClasses();
        print("load sucsessful");
    }


}

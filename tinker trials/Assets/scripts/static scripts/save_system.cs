/*
by:Milan Manji
script descrition: this script loads and saves the player inventory to a binary file


*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using static player_inventory;

// the player invetory is stored in the files as list of "saved objects" a serilised scriptable object objects and is loaded in to them as well
//invetery and classes are saved in 2 diffrent files

public class save_system
{
    static string Path = Application.persistentDataPath + "/inventory_Savedata.txt";

    public static void saveData(List<saved_object> invetoty)
    {
        Debug.Log(Path);
        BinaryFormatter formatter = new BinaryFormatter();
        Path = Application.persistentDataPath + "/inventory_Savedata.txt";

        FileStream stream = new FileStream(Path, FileMode.OpenOrCreate);

        formatter.Serialize(stream, invetoty);

        stream.Close();

    }

    public static List<saved_object> LoadSaveData()
    {
        if (!File.Exists(Path))
        {
            Debug.Log("path dosent exist");
            return null;
        }
        else
        {
            Debug.Log("path exist");
        }

        BinaryFormatter formatter = new BinaryFormatter();

        FileStream stream = new FileStream(Path, FileMode.Open);

        List<saved_object> data = formatter.Deserialize(stream) as List<saved_object>;

        stream.Close();

        player_inventory.Load_inventory(data);
        Debug.Log("loaded data");

        return data;


    }


    //___________________________________________________classes



    static string Path2 = Application.persistentDataPath + "/Classes_Savedata.txt";

    public static void saveClases(List<saved_object> invetoty)
    {
        Debug.Log(Path2);
        BinaryFormatter formatter = new BinaryFormatter();
        Path2 = Application.persistentDataPath + "/Classes_Savedata.txt";

        FileStream stream = new FileStream(Path2, FileMode.OpenOrCreate);

        formatter.Serialize(stream, invetoty);

        stream.Close();

    }

    public static List<saved_object> LoadSavedClasses()
    {
        if (!File.Exists(Path2))
        {
            Debug.Log("path dosent exist");
            return null;
        }
        else
        {
            Debug.Log("path exist");
        }

        BinaryFormatter formatter = new BinaryFormatter();

        FileStream stream = new FileStream(Path2, FileMode.Open);

        List<saved_object> data = formatter.Deserialize(stream) as List<saved_object>;

        stream.Close();

        player_inventory.load_classes(data);
        Debug.Log("loaded data");

        return data;


    }
}

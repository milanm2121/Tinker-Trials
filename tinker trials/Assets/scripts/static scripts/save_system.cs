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
using System;
using ExitGames.Client.Photon;
using System.Xml;

// the player invetory is stored in the files as list of "saved objects" a serilised scriptable object objects and is loaded in to them as well
//invetery and classes are saved in 2 diffrent files

public class save_system
{
    static public bool has_save_data =false;
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
            has_save_data = false;
            return null;
           
        }
        else
        {
            Debug.Log("path exist");
            has_save_data = true;

            BinaryFormatter formatter = new BinaryFormatter();

            FileStream stream = new FileStream(Path, FileMode.Open);

            List<saved_object> data = formatter.Deserialize(stream) as List<saved_object>;

            stream.Close();

            player_inventory.Load_inventory(data);
            Debug.Log("loaded data");

            return data;
        }

        


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
            has_save_data = false;
            return null;

        }
        else
        {
            Debug.Log("path exist");
            Debug.Log(Path);
            has_save_data = true;
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream stream = new FileStream(Path2, FileMode.Open);

            List<saved_object> data = formatter.Deserialize(stream) as List<saved_object>;

            stream.Close();

            class_class.Class[] classes = player_inventory.load_classes(data);

            static_classes.Class1 = classes[0];
            static_classes.Class2 = classes[1];
            static_classes.Class3 = classes[2];
            static_classes.Class4 = classes[3];


            Debug.Log("loaded data");

            return data;
        }

        


    }
    //___________________________________________________________________________________________PhotonPUN
    
    public static List<saved_object> DeSeriliseClassesPUN(byte[] serilises_saved_objects)
    {
        BinaryFormatter formatter = new BinaryFormatter();

    //    Stream stream = new FileStream(new MemoryStream( serilises_saved_objects));

        List<saved_object> data = formatter.Deserialize(new MemoryStream(serilises_saved_objects)) as List<saved_object>;

    //    stream.Close();

        player_inventory.load_classes(data);
        Debug.Log("loaded data");

        return data;


    }

    public static byte[] SeriliseClasses(object invetoty)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        MemoryStream stream = new MemoryStream();

        formatter.Serialize(stream, invetoty);

        stream.Close();
        

        return stream.ToArray();
    }


}

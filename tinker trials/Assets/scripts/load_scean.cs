/*
by:Milan Manji
script descrition: this script loads sceans based off the name of a scean


*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class load_scean : MonoBehaviour
{
    public void loadScean(string scean)
    {
        SceneManager.LoadScene(scean);
    }
}

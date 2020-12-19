using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInputs : MonoBehaviour
{
    public static KeyInputs KP; // singleton 
    public KeyCode jump { get; set; }
    public KeyCode forward { get; set; }
    public KeyCode left { get; set; }
    public KeyCode right { get; set; }
    public KeyCode backwards { get; set; }
    public KeyCode melee { get; set; }
    public KeyCode run { get; set; }
    public KeyCode reload { get; set; }
    public KeyCode throw_letal { get; set; }



    void Awake()
    {
        if(KP == null)
        {
            DontDestroyOnLoad(gameObject);
            KP = this;

        }
        else if (KP != this)
        {
            Destroy(gameObject);
        }
        jump = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("jumpKey", "Space"));// casting the assigned keycode to jumpkey and if they player hasnt set it would be jump 
        forward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("forwardKey", "W"));
        left = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftKey", "A"));
        right = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightKey", "D"));
        backwards = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("backwardsKey", "S"));
        melee = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("meleekey", "V"));
        run = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("runkey", "LeftShift"));
        reload = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("reloadkey", "R"));
        throw_letal = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("throwLethalKey", "G"));





    }

}

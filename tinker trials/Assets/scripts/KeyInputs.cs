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





    }
    // Start is called before the first frame update
    void Start()
    {
     
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}

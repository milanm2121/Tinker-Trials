using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyMaping : MonoBehaviour
{
    // use an array for more commands 
    public Transform keyMap;// for the panel 
    Event keyEvent;// detect what key the user is presing 
    Text buttonText;// changing the text compent of button 
    KeyCode customKey;// determine what the new key will be 

    bool waitingForInput;
    public bool lock_menu;

    void Start()
    {
        keyMap = transform.Find("KeyMap");// finding the panel // not quite working 
        //keyMap = transform.Find("KeyMap");
        if (lock_menu == false)
        {
            keyMap.gameObject.SetActive(false); // make sure the panel doenst open 
        }
        waitingForInput = false;

        for(int i = 0; i < 8; i++)
        {
            if (keyMap.GetChild(i).name == "ForwardKey")// finding the namew of the buttons inside the panel obejct
                keyMap.GetChild(i).GetChild(0).GetComponent<Text>().text = KeyInputs.KP.forward.ToString();
            else if (keyMap.GetChild(i).name == "BackwardsKey")
                keyMap.GetChild(i).GetChild(0).GetComponent<Text>().text = KeyInputs.KP.backwards.ToString();
            else if (keyMap.GetChild(i).name == "LeftKey")
                keyMap.GetChild(i).GetChild(0).GetComponent<Text>().text = KeyInputs.KP.left.ToString();
            else if (keyMap.GetChild(i).name == "RightKey")
                keyMap.GetChild(i).GetChild(0).GetComponent<Text>().text = KeyInputs.KP.right.ToString();
            else if (keyMap.GetChild(i).name == "JumpKey")
                keyMap.GetChild(i).GetChild(0).GetComponent<Text>().text = KeyInputs.KP.jump.ToString();
            else if (keyMap.GetChild(i).name == "ReloadKey")
                keyMap.GetChild(i).GetChild(0).GetComponent<Text>().text = KeyInputs.KP.reload.ToString();
            else if (keyMap.GetChild(i).name == "ThrowLeathalKey")
                keyMap.GetChild(i).GetChild(0).GetComponent<Text>().text = KeyInputs.KP.throw_lethal.ToString();
            else if (keyMap.GetChild(i).name == "MeleeKey")
                keyMap.GetChild(i).GetChild(0).GetComponent<Text>().text = KeyInputs.KP.melee.ToString();
        }

    }



    void Update()
    {
        if (lock_menu == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !keyMap.gameObject.activeSelf)// checikng if the panel is active 
                keyMap.gameObject.SetActive(true);
            else if (Input.GetKeyDown(KeyCode.Escape) && keyMap.gameObject.activeSelf)
                keyMap.gameObject.SetActive(false);
        }
    }

    void OnGUI()
    {
        keyEvent = Event.current;// determine every frame to se what event is triggered 
        if(keyEvent.isKey && waitingForInput)
        {
            customKey = keyEvent.keyCode;
            waitingForInput = false;
        }

    }
    public void StartWork(string keyName)
    {
        if (!waitingForInput)
            StartCoroutine(AssignKey(keyName));
    }
    public void SendText(Text text)
    {
        buttonText = text;
    }
    IEnumerator WaitForInput()
    {
        while (!keyEvent.isKey)
            yield return null;
    }
    public IEnumerator AssignKey(string keyName)
    {
        waitingForInput = true;
        yield return WaitForInput();

        switch(keyName)
        {
            case "forward":
                KeyInputs.KP.forward = customKey;
                buttonText.text = KeyInputs.KP.forward.ToString();
                PlayerPrefs.SetString("forwardKey", KeyInputs.KP.forward.ToString());
                break; // trying to save the new key inputs for the player 
            case "backwards":
                KeyInputs.KP.backwards = customKey;
                buttonText.text = KeyInputs.KP.backwards.ToString();
                PlayerPrefs.SetString("backwardsKey", KeyInputs.KP.backwards.ToString());
                break;
            case "left":
                KeyInputs.KP.left = customKey;
                buttonText.text = KeyInputs.KP.left.ToString();
                PlayerPrefs.SetString("leftKey", KeyInputs.KP.left.ToString());
                break;
            case "right":
                KeyInputs.KP.right = customKey;
                buttonText.text = KeyInputs.KP.right.ToString();
                PlayerPrefs.SetString("rightKey", KeyInputs.KP.right.ToString());
                break;
            case "jump":
                KeyInputs.KP.jump = customKey;
                buttonText.text = KeyInputs.KP.jump.ToString();
                PlayerPrefs.SetString("jumpKey", KeyInputs.KP.jump.ToString());
                break;
            case "reload":
                KeyInputs.KP.jump = customKey;
                buttonText.text = KeyInputs.KP.jump.ToString();
                PlayerPrefs.SetString("reloadKey", KeyInputs.KP.jump.ToString());
                break;
            case "throwLethal":
                KeyInputs.KP.jump = customKey;
                buttonText.text = KeyInputs.KP.jump.ToString();
                PlayerPrefs.SetString("throwLeathalKey", KeyInputs.KP.jump.ToString());
                break;
            case "melee":
                KeyInputs.KP.jump = customKey;
                buttonText.text = KeyInputs.KP.jump.ToString();
                PlayerPrefs.SetString("meleelKey", KeyInputs.KP.jump.ToString());
                break;
        }
        yield return null;
    }

    //https://www.youtube.com/watch?v=iSxifRKQKAA&ab_channel=StudicaNews //used to create this scrpit and work 

}

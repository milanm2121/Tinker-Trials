//this is only ment for the first scean
//this script is ment for controller to Computer only not Console
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controler_input_Setup_script : MonoBehaviour
{
    static bool inputTestPhase;
    public static int contorllerType;

    int inputPhaseProgression;
    int inputPhaseRespone1;
    int inputPhaseRespone2;
    int inputPhaseRespone3;

    public Text contollerTestText;

    // Start is called before the first frame update
    void Start()
    {
        int inputPhaseProgression=0;
        inputTestPhase = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (inputTestPhase == false)
        {
            InputPhase();
        }

    }

    void InputPhase()
    {
        if (inputPhaseProgression == 0)
        {
            contollerTestText.text = "plese press (do not hold) the the X button for Playstaion4 Contoller or A button for Xbox one Controller";
            if(Input.GetButtonDown("PSX"))
            {
                inputPhaseRespone1 = 1;
                StartCoroutine(inputTestDelay());
            }
            if (Input.GetButtonDown("XB_A1"))
            {
                inputPhaseRespone1 = 2;
                StartCoroutine(inputTestDelay());
            }
            if (Input.GetButtonDown("XB_A2"))
            {
                inputPhaseRespone1 = 3;
                StartCoroutine(inputTestDelay());
            }
        }
        if (inputPhaseProgression == 1)
        {
            contollerTestText.text = "plese press (do not hold) the the Circlie button for Playstaion4 Contoller or B button for Xbox one Controller";
            if (Input.GetButtonDown("PSCircle"))
            {
                inputPhaseRespone2 = 1;
                StartCoroutine(inputTestDelay());
            }
            if (Input.GetButtonDown("XB_B1"))
            {
                inputPhaseRespone2 = 2;
                StartCoroutine(inputTestDelay());
            }
            if (Input.GetButtonDown("XB_B2"))
            {
                inputPhaseRespone2 = 3;
                StartCoroutine(inputTestDelay());
            }
        }
        if (inputPhaseProgression == 2)
        {
            contollerTestText.text = "plese press (do not hold) the Square button for Playstaion4 Contoller or X button for Xbox one Controller";
            if (Input.GetButtonDown("PSSquare"))
            {
                inputPhaseRespone3 = 1;
                StartCoroutine(inputTestDelay());
            }
            if (Input.GetButtonDown("XB_X1"))
            {
                inputPhaseRespone3 = 2;
                StartCoroutine(inputTestDelay());
            }
            if (Input.GetButtonDown("XB_X2"))
            {
                inputPhaseRespone3 = 3;
                StartCoroutine(inputTestDelay());
            }
        }
        if (inputPhaseProgression == 3)
        {
            if (inputPhaseRespone1 == 1 && inputPhaseRespone2 == 1 && inputPhaseRespone3 == 1)
            {
                contorllerType = 1;
                inputTestPhase = true;
                gameObject.AddComponent<controler_input_manager>();
                Destroy(contollerTestText);
            }

            if (inputPhaseRespone1 == 2 && inputPhaseRespone2 == 2 && inputPhaseRespone3 == 2)
            {
                contorllerType = 2;
                inputTestPhase = true;
                gameObject.AddComponent<controler_input_manager>();
                Destroy(contollerTestText);
            }

            if (inputPhaseRespone1 == 3 && inputPhaseRespone2 == 3 && inputPhaseRespone3 == 3)
            {
                contorllerType = 3;
                inputTestPhase = true;
                gameObject.AddComponent<controler_input_manager>();
                Destroy(contollerTestText);
            }
            else
            {
                contollerTestText.text = "sorry your controller dosent match any known controllers press spcae to try again";
                if (Input.GetKey(KeyCode.Space))
                    inputPhaseProgression = 0;
            }
        }

    }
    IEnumerator inputTestDelay()
    {
        yield return new WaitForSeconds(2);
        inputPhaseProgression += 1;
    }
}

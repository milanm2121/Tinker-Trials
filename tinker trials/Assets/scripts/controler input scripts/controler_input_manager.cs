using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controler_input_manager: MonoBehaviour
{
    //Sticks
    public static Vector2 Left_Stick;
    public static Vector2 Right_Stick;
    //dPad
    public static bool UP_Dpad;
    public static bool Down_Dpad;
    public static bool Right_Dpad;
    public static bool Left_Dpad;
    //Right Buttons
    public static bool Bottom_Button;
    public static bool Bottom_Button_Hold;

    public static bool Left_Button;
    public static bool Left_Button_Hold;

    public static bool Top_Button;
    public static bool Top_Button_Hold;

    public static bool Right_Button;
    public static bool Right_Button_Hold;
    //L
    public static bool L1;
    public static bool L1_Hold;

    public static float L2;
    public static bool L3;
    //R
    public static bool R1;
    public static bool R1_Hold;

    public static float R2;
    public static bool R3;

    // Update is called once per frame
    void Update()
    {

        if (controler_input_Setup_script.contorllerType != 0)
        {
            //Playsation
            if (controler_input_Setup_script.contorllerType == 1)
            {
                //sticks
                Left_Stick = new Vector2(Input.GetAxis("PSLeftStickHorizontal"), -Input.GetAxis("PSLeftStickVertical"));
                Right_Stick = new Vector2(Input.GetAxis("PSRightStickHorizontal"), Input.GetAxis("PSRightStickVertical"));

                //dpad
                if (Input.GetAxis("PSDpadX") < 0)
                {
                    UP_Dpad = true;
                }
                else
                {
                    UP_Dpad = false;
                }
                if (Input.GetAxis("PSDpadX") > 0)
                {
                    Down_Dpad = true;
                }
                else
                {
                    Down_Dpad = false;
                }
                if (Input.GetAxis("PSDpadY") > 0)
                {
                    Left_Dpad = true;
                }
                else
                {
                    Left_Dpad = false;
                }
                if (Input.GetAxis("PSDpadY") < 0)
                {
                    Right_Dpad = true;
                }
                else
                {
                    Right_Dpad = false;
                }


                //buttons
                if (Input.GetButton("PSTriangle"))
                {
                    Top_Button_Hold = true;
                }
                else
                {
                    Top_Button_Hold = false;
                }
                if (Input.GetButtonDown("PSTriangle"))
                {
                    Top_Button = true;
                }
                else
                {
                    Top_Button = false;
                }


                if (Input.GetButton("PSSquare"))
                {
                    Left_Button_Hold = true;
                }
                else
                {
                    Left_Button_Hold = false;
                }
                if (Input.GetButtonDown("PSSquare"))
                {
                    Left_Button = true;
                }
                else
                {
                    Left_Button = false;
                }


                if (Input.GetButton("PSCircle"))
                {
                    Right_Button_Hold = true;
                }
                else
                {
                    Right_Button_Hold = false;
                }
                if (Input.GetButtonDown("PSCircle"))
                {
                    Right_Button = true;
                }
                else
                {
                    Right_Button = false;
                }


                if (Input.GetButton("PSX"))
                {
                    Bottom_Button_Hold = true;
                }
                else
                {
                    Bottom_Button_Hold = false;
                }
                if (Input.GetButtonDown("PSX"))
                {
                    Bottom_Button = true;
                }
                else
                {
                    Bottom_Button = false;
                }

                //L
                if (Input.GetButton("PSL1"))
                {
                    L1_Hold = true;
                }
                else
                {
                    L1_Hold = false;
                }
                if (Input.GetButtonDown("PSL1"))
                {
                    L1 = true;
                }
                else
                {
                    L1 = false;
                }

                L2 = Input.GetAxis("PSL2");

                if (Input.GetButtonDown("PSL3"))
                {
                    L3 = true;
                }
                else
                {
                    L3 = false;
                }
                //R
                if (Input.GetButton("PSR1"))
                {
                    R1_Hold = true;
                }
                else
                {
                    R1_Hold = false;
                }
                if (Input.GetButtonDown("PSR1"))
                {
                    R1 = true;
                }
                else
                {
                    R1 = false;
                }

                R2 = Input.GetAxis("PSR2");

                if (Input.GetButtonDown("PSR3"))
                {
                    R3 = true;
                }
                else
                {
                    R3 = false;
                }
            }
            if (controler_input_Setup_script.contorllerType == 2)
            {
                //sticks
                Left_Stick = new Vector2(Input.GetAxis("XBLeftStickHorizontal1"), -Input.GetAxis("XBLeftStickVertical1"));
                Right_Stick = new Vector2(Input.GetAxis("XBRightStickHorizontal1"), Input.GetAxis("XBRightStickVertical1"));

                //dpad
                if (Input.GetAxis("XBDpadX1") < 0)
                {
                    UP_Dpad = true;
                }
                else
                {
                    UP_Dpad = false;
                }
                if (Input.GetAxis("XBDpadX1") > 0)
                {
                    Down_Dpad = true;
                }
                else
                {
                    Down_Dpad = false;
                }
                if (Input.GetAxis("XBDpadY1") > 0)
                {
                    Left_Dpad = true;
                }
                else
                {
                    Left_Dpad = false;
                }
                if (Input.GetAxis("XBDpadY1") < 0)
                {
                    Right_Dpad = true;
                }
                else
                {
                    Right_Dpad = false;
                }


                //buttons
                if (Input.GetButton("XB_Y1"))
                {
                    Top_Button_Hold = true;
                }
                else
                {
                    Top_Button_Hold = false;
                }
                if (Input.GetButtonDown("XB_Y1"))
                {
                    Top_Button = true;
                }
                else
                {
                    Top_Button = false;
                }


                if (Input.GetButton("XB_X1"))
                {
                    Left_Button_Hold = true;
                }
                else
                {
                    Left_Button_Hold = false;
                }
                if (Input.GetButtonDown("XB_X1"))
                {
                    Left_Button = true;
                }
                else
                {
                    Left_Button = false;
                }


                if (Input.GetButton("XB_B1"))
                {
                    Right_Button_Hold = true;
                }
                else
                {
                    Right_Button_Hold = false;
                }
                if (Input.GetButtonDown("XB_B1"))
                {
                    Right_Button = true;
                }
                else
                {
                    Right_Button = false;
                }


                if (Input.GetButton("XB_A1"))
                {
                    Bottom_Button_Hold = true;
                }
                else
                {
                    Bottom_Button_Hold = false;
                }
                if (Input.GetButtonDown("XB_A1"))
                {
                    Bottom_Button = true;
                }
                else
                {
                    Bottom_Button = false;
                }

                //L
                if (Input.GetButton("XB_Lb1"))
                {
                    L1_Hold = true;
                }
                else
                {
                    L1_Hold = false;
                }
                if (Input.GetButtonDown("XB_Lb1"))
                {
                    L1 = true;
                }
                else
                {
                    L1 = false;
                }

                L2 = Input.GetAxis("XB_Lt1");

                if (Input.GetButtonDown("XB_Ls1"))
                {
                    L3 = true;
                }
                else
                {
                    L3 = false;
                }
                //R
                if (Input.GetButton("XB_Rb1"))
                {
                    R1_Hold = true;
                }
                else
                {
                    R1_Hold = false;
                }
                if (Input.GetButtonDown("XB_Rb1"))
                {
                    R1 = true;
                }
                else
                {
                    R1 = false;
                }

                R2 = Input.GetAxis("XB_Rt1");

                if (Input.GetButtonDown("XB_Rs1"))
                {
                    R3 = true;
                }
                else
                {
                    R3 = false;
                }
            }
            if (controler_input_Setup_script.contorllerType == 3)
            {
                //sticks
                Left_Stick = new Vector2(Input.GetAxis("XBLeftStickHorizontal2"), -Input.GetAxis("XBLeftStickVertical2"));
                Right_Stick = new Vector2(Input.GetAxis("XBRightStickHorizontal2"), Input.GetAxis("XBRightStickVertical2"));

                //dpad
                if (Input.GetButtonDown("XBDpadup2"))
                {
                    UP_Dpad = true;
                }
                else
                {
                    UP_Dpad = false;
                }
                if (Input.GetButtonDown("XBDpadDown2"))
                {
                    Down_Dpad = true;
                }
                else
                {
                    Down_Dpad = false;
                }
                if (Input.GetButtonDown("XBDpadLeft2"))
                {
                    Left_Dpad = true;
                }
                else
                {
                    Left_Dpad = false;
                }
                if (Input.GetButtonDown("XBDpadRight2"))
                {
                    Right_Dpad = true;
                }
                else
                {
                    Right_Dpad = false;
                }


                //buttons
                if (Input.GetButton("XB_Y2"))
                {
                    Top_Button_Hold = true;
                }
                else
                {
                    Top_Button_Hold = false;
                }
                if (Input.GetButtonDown("XB_Y2"))
                {
                    Top_Button = true;
                }
                else
                {
                    Top_Button = false;
                }


                if (Input.GetButton("XB_X2"))
                {
                    Left_Button_Hold = true;
                }
                else
                {
                    Left_Button_Hold = false;
                }
                if (Input.GetButtonDown("XB_X2"))
                {
                    Left_Button = true;
                }
                else
                {
                    Left_Button = false;
                }


                if (Input.GetButton("XB_B2"))
                {
                    Right_Button_Hold = true;
                }
                else
                {
                    Right_Button_Hold = false;
                }
                if (Input.GetButtonDown("XB_B2"))
                {
                    Right_Button = true;
                }
                else
                {
                    Right_Button = false;
                }


                if (Input.GetButton("XB_A2"))
                {
                    Bottom_Button_Hold = true;
                }
                else
                {
                    Bottom_Button_Hold = false;
                }
                if (Input.GetButtonDown("XB_A2"))
                {
                    Bottom_Button = true;
                }
                else
                {
                    Bottom_Button = false;
                }

                //L
                if (Input.GetButton("XB_Lb2"))
                {
                    L1_Hold = true;
                }
                else
                {
                    L1_Hold = false;
                }
                if (Input.GetButtonDown("XB_Lb2"))
                {
                    L1 = true;
                }
                else
                {
                    L1 = false;
                }

                L2 = Input.GetAxis("XB_Lt2");

                if (Input.GetButtonDown("XB_Ls2"))
                {
                    L3 = true;
                }
                else
                {
                    L3 = false;
                }
                //R
                if (Input.GetButton("XB_Rb2"))
                {
                    R1_Hold = true;
                }
                else
                {
                    R1_Hold = false;
                }
                if (Input.GetButtonDown("XB_Rb2"))
                {
                    R1 = true;
                }
                else
                {
                    R1 = false;
                }

                R2 = Input.GetAxis("XB_Rt2");

                if (Input.GetButtonDown("XB_Rs2"))
                {
                    R3 = true;
                }
                else
                {
                    R3 = false;
                }
            }
        }
    }
}

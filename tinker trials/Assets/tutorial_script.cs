using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class tutorial_script : MonoBehaviour
{
    // Start is called before the first frame update
    public Button[] classes;
    public GameObject block_ui;
    float block_ui_slide_rate;
    public TMP_Text turorial_text;
    public GameObject tutorial_text_holder;
    public int tutorial_phase=0;
    public GameObject next_button;

    [TextArea(3,4)]
    public string tutorial_text_1;

    [TextArea(3, 4)]
    public string tutorial_text_2;

    [TextArea(3, 4)]
    public string tutorial_text_3;

    [TextArea(3, 4)]
    public string tutorial_text_4;

    [TextArea(3, 4)]
    public string tutorial_text_5;
    void Start()
    {
        if(save_system.has_save_data == false)
        {
            block_ui.SetActive(true);
        }
        else
        {
            block_ui.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(tutorial_phase <= 5 && save_system.has_save_data == false)
        {
            classes[0].interactable = true;
            classes[1].interactable = false;
            classes[2].interactable = false;
            classes[3].interactable = false;

            tutorial_text_holder.SetActive(true);
            if (tutorial_phase == 0)
            {
                turorial_text.text = tutorial_text_1;
                next_button.SetActive(false);
            }
            else if (tutorial_phase == 1)
            {
                turorial_text.text = tutorial_text_2;
                
                block_ui.GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(transform.position, new Vector3(700, 0, 0),block_ui_slide_rate);
                block_ui_slide_rate = Mathf.Clamp(block_ui_slide_rate + Time.deltaTime, 0, 1);
                next_button.SetActive(false);
            }
            else if(tutorial_phase == 2)
            {
                turorial_text.text = tutorial_text_3;
                next_button.SetActive(true);
            }
            else if(tutorial_phase == 3)
            {
                turorial_text.text = tutorial_text_4;
                next_button.SetActive(true);
            }
            else if(tutorial_phase == 4)
            {
                turorial_text.text = tutorial_text_5;
                next_button.SetActive(true);
            }
            else if (tutorial_phase == 5)
            {
                turorial_text.text = "one your done editing the wepon segment click the 'back' button in the top right, good luck and have fun";
                next_button.SetActive(true);
            }


        }
        else
        {
            tutorial_text_holder.SetActive(false);
            block_ui.SetActive(false);

            classes[0].interactable = true;
            classes[1].interactable = true;
            classes[2].interactable = true;
            classes[3].interactable = true;
        }
    }
    public void next_phase()
    {
        tutorial_phase++;
    }
    public void select_class_phase()
    {
        if (tutorial_phase == 0)
            tutorial_phase++;
    }
    public void select_wepon_phase()
    {
        if (tutorial_phase == 1)
            tutorial_phase++;
    }
}

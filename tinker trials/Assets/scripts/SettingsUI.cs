using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    
    public AudioMixer mixer;
        
    public Slider[] sliderS;

    
    
    public void Update()
    {
        SetMaster();// Slider ofr the master 
        SetMusic();// Slider for the Workshop
        SetSFX();// slider for the level 
    }

   
    public void SetMaster ()
    {
           int sliderNum = 0;
           mixer.SetFloat("MenuVol", Mathf.Log10(sliderS[sliderNum].value) *20);
     
    }

    public void SetMusic ()
    {
        int sliderNum = 1;
        mixer.SetFloat("WorkShoVol", Mathf.Log10(sliderS[sliderNum].value) * 20);
      
    }
    public void SetSFX()
    {
       int sliderNum = 2;
       mixer.SetFloat("LevlVol", Mathf.Log10(sliderS[sliderNum].value) * 20);
      
    }

    public void SetUI()
    {
      //  int sliderNum = 3;
      //  mixer.SetFloat("UI", Mathf.Log10(sliderS[sliderNum].value) * 20);
      //  sceneDataHandler.SaveAudioValue(sliderNum, sliderS[sliderNum].value);
    }

    public void SetAMB()
    {
       // int sliderNum = 4;
       // mixer.SetFloat("AMB", Mathf.Log10(sliderS[sliderNum].value) * 20);
       // sceneDataHandler.SaveAudioValue(sliderNum, sliderS[sliderNum].value);
    }


    public void MuteOFF()
    {
        mixer.SetFloat("Master", -80f);
        Debug.Log("off");

    }

}

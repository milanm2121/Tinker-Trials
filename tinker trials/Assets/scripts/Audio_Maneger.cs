using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Transforms;
using UnityEngine;

public class Audio_Maneger : MonoBehaviour
{
    public AudioClip[] explosionsounds;
    public AudioClip[] metalImpactSounsd;
    public AudioClip[] woodImpactSounsd;
    public AudioClip[] stoneImpactSounsd;
    public static Audio_Maneger AM;
    public static List<AudioSource> AudioSources= new List<AudioSource>();
    public GameObject audio_object;


    // Start is called before the first frame update
    void Start()
    {
        AM = this;
    }

    public static void create_sound(Vector3 position, AudioClip AC, float voliume = 1 )
    {
        GameObject Audio_object=Instantiate(AM.audio_object,position,Quaternion.identity);
        AudioSource AS =Audio_object.GetComponent<AudioSource>();
        AS.clip = AC;
        AS.volume = voliume;
        AS.Play();
        AudioSources.Add(AS);
        AS.loop = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0;AudioSources.Count>i; i++)
        {
            if (AudioSources[i] && AudioSources[i].isPlaying == false)
            {
                AudioSource ObservedAudioSource = AudioSources[i];
                AudioSources.RemoveAt(i);
                Destroy(ObservedAudioSource.gameObject);
            }
        }
    }
}

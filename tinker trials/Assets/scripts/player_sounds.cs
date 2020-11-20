using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_sounds : MonoBehaviour
{

    public bool walking;
    public bool running;

    public AudioSource AS;
    public AudioClip[] playerLanding_sounds;
    public AudioClip[] wallking_sound;
    public AudioClip[] running_Sounds;
   
    public player_Movement PM;
    enum groundType {metal,wood,stone,sand,glass,leaves_sticks,gravel };
    groundType lastGtoundType;

    public bool grounded=true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PM.RB!=null && PM.RB.velocity != Vector3.zero && PM.grounded == true)
        {
            if (PM.running == true)
            {
                if (lastGtoundType == groundType.metal)
                {
                    AS.clip = running_Sounds[0];
                    if (AS.isPlaying == false)
                        AS.Play();
                }
                if (lastGtoundType == groundType.wood)
                {
                    AS.clip = running_Sounds[1];
                    if (AS.isPlaying == false)
                        AS.Play();
                }
                if (lastGtoundType == groundType.stone)
                {
                    AS.clip = running_Sounds[2];
                    if (AS.isPlaying == false)
                        AS.Play();
                }
                if (lastGtoundType == groundType.sand)
                {
                    AS.clip = running_Sounds[3];
                    if (AS.isPlaying == false)
                        AS.Play();
                }
                if (lastGtoundType == groundType.glass)
                {
                    AS.clip = running_Sounds[4];
                    if (AS.isPlaying == false)
                        AS.Play();
                }
                if (lastGtoundType == groundType.leaves_sticks)
                {
                    AS.clip = running_Sounds[5];
                    if (AS.isPlaying == false)
                        AS.Play();
                }
                if (lastGtoundType == groundType.gravel)
                {
                    AS.clip = running_Sounds[6];
                    if (AS.isPlaying == false)
                        AS.Play();
                }

            }
            else
            {
                if (PM.running == false)
                {
                    if (lastGtoundType == groundType.metal)
                    {
                        AS.clip = wallking_sound[0];
                        if (AS.isPlaying == false)
                            AS.Play();
                    }
                    if (lastGtoundType == groundType.wood)
                    {
                        AS.clip = wallking_sound[1];
                        if (AS.isPlaying == false)
                            AS.Play();
                    }
                    if (lastGtoundType == groundType.stone)
                    {
                        AS.clip = wallking_sound[2];
                        if (AS.isPlaying == false)
                            AS.Play();
                    }
                    if (lastGtoundType == groundType.sand)
                    {
                        AS.clip = wallking_sound[3];
                        if (AS.isPlaying == false)
                            AS.Play();
                    }
                    if (lastGtoundType == groundType.glass)
                    {
                        AS.clip = wallking_sound[4];
                        if (AS.isPlaying == false)
                            AS.Play();
                    }
                    if (lastGtoundType == groundType.leaves_sticks)
                    {
                        AS.clip = wallking_sound[5];
                        if (AS.isPlaying == false)
                            AS.Play();
                    }
                    if (lastGtoundType == groundType.gravel)
                    {
                        AS.clip = wallking_sound[6];
                        if (AS.isPlaying == false)
                            AS.Play();
                    }
                }
            }
        }
        else
        {
            AS.Stop();
        }
    }
    private void OnCollisionEnter(Collision col)
    {
        //i know its not in order
        //metal
        if(col.gameObject.tag=="ground" && col.gameObject.layer == 11)
        {
            if (grounded == false)
            {
                Audio_Maneger.create_sound(transform.position, playerLanding_sounds[0]);
                grounded = true;
            }
            lastGtoundType = groundType.metal;
        }
        //wood
        if (col.gameObject.tag == "ground" && col.gameObject.layer == 12)
        {
            if (grounded == false)
            {
                Audio_Maneger.create_sound(transform.position, playerLanding_sounds[1]);
                grounded = true;
            }
            lastGtoundType = groundType.wood;
        }
        //stone
        if (col.gameObject.tag == "ground" && col.gameObject.layer == 13)
        {
            if (grounded == false)
            {
                Audio_Maneger.create_sound(transform.position, playerLanding_sounds[2]);
                grounded = true;
            }
            lastGtoundType = groundType.stone;
        }
        //sand
        if (col.gameObject.tag == "ground" && col.gameObject.layer == 14)
        {
            if (grounded == false)
            {
                Audio_Maneger.create_sound(transform.position, playerLanding_sounds[3]);
                grounded = true;
            }
            lastGtoundType = groundType.sand;
        }
        //glass
        if (col.gameObject.tag == "ground" && col.gameObject.layer == 15)
        {
            if (grounded == false)
            {
                Audio_Maneger.create_sound(transform.position, playerLanding_sounds[4]);
                grounded = true;
            }
            lastGtoundType = groundType.glass;

        }
        //leaves and sticks
        if (col.gameObject.tag == "ground" && col.gameObject.layer == 16)
        {
            if (grounded == false)
            {
                Audio_Maneger.create_sound(transform.position, playerLanding_sounds[5]);
                grounded = true;
            }
            lastGtoundType = groundType.leaves_sticks;
        }
        //gravel
        if (col.gameObject.tag == "ground" && col.gameObject.layer == 17)
        {
            if (grounded == false)
            {
                Audio_Maneger.create_sound(transform.position, playerLanding_sounds[6]);
                grounded = true;
            }
            lastGtoundType = groundType.gravel;
        }
    }
}

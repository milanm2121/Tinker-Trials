using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multi_Elemental_Visual_Effect : MonoBehaviour
{
    public Material material_instance;
    public SkinnedMeshRenderer surface;
    public SkinnedMeshRenderer joints;
    public Shader skinShader;
    public multi_player_stats PS;
    public Color elemental_color;
    public ParticleSystem particlel;
    // Start is called before the first frame update
    void Start()
    {
        material_instance = new Material(skinShader);
        material_instance.CopyPropertiesFromMaterial(surface.material);
        joints.material = material_instance;
        surface.material = material_instance;
    }

    // Update is called once per frame
    void Update()
    {



        elemental_color = Color.Lerp(Color.white, Color.red, PS.fire_meter / 100);
        elemental_color = Color.Lerp(elemental_color, Color.blue, PS.frost_meter / 100);
        elemental_color = Color.Lerp(elemental_color, Color.green, PS.dirt_meter / 100);
        elemental_color = Color.Lerp(elemental_color, Color.yellow, PS.electrucity_meter / 100);
        elemental_color.a = 1;
        material_instance.SetColor("_elementalColor", elemental_color);

        ParticleSystem.MainModule x = particlel.main;
        x.startColor = elemental_color;

        if (!particlel.isPlaying && (PS.fire_meter > 70 || PS.frost_meter > 30 || PS.dirt_meter > 30 || PS.electrucity_meter > 60))
        {
            particlel.Play();
        }
        else if (PS.fire_meter < 70 && PS.frost_meter < 30 && PS.dirt_meter < 30 && PS.electrucity_meter < 60)
        {
            particlel.Stop();
        }


    }
}


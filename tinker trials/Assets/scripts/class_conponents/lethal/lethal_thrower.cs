using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class lethal_thrower : MonoBehaviour
{
    public GameObject lethal;
    in_game_leathal IGL;

    public GameObject currentLeathal;

    public bool tapped_lethal;

    public player_Movement PM;

    public player_stats ps;

    public bool sholder_launcher=false;

    public player_ID PID;

    public bool throwing_lethal;

    public Rig right_arm_constaints;

    // Start is called before the first frame update
    void Start()
    {
        generate_leathal(static_classes.Class1);
    }

    // Update is called once per frame
    void Update()
    {
        if (throwing_lethal == true)
            throwing_lethal = false;

        if (PID.is_player && Input.GetKeyDown(KeyInputs.KP.throw_letal) && currentLeathal == null && (PM.running==false || sholder_launcher==true))
        {
            right_arm_constaints.weight = 0;
            StartCoroutine(delaythrow());
            
            tapped_lethal = true;
            throwing_lethal = true;
        }

        if (PID.is_player && Input.GetKeyDown(KeyInputs.KP.throw_letal) && tapped_lethal== false && (PM.running == false || sholder_launcher == true))
        {
            if (currentLeathal != null && IGL.manual == true)
            {
                currentLeathal.GetComponent<in_game_leathal>().primed = true;
                currentLeathal = null;
               
            }
        }
        tapped_lethal = false;

    }

    void generate_leathal(class_class.Class class_)
    {
        IGL=lethal.GetComponent<in_game_leathal>();
        IGL.primer_script.PO = class_.Lethal.primer;
        IGL.container_script.CO = class_.Lethal.container;
        IGL.payload_script.PO = class_.Lethal.payload;
        
    }
    IEnumerator delaythrow()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject x = Instantiate(lethal, transform.position, Quaternion.identity);
        IGL.primed = false;
        x.GetComponent<Rigidbody>().velocity = transform.forward * IGL.container_script.CO.weight * 10;
        x.GetComponent<in_game_leathal>().ps = ps;

        currentLeathal = x;
        right_arm_constaints.weight = 1;
    }
}

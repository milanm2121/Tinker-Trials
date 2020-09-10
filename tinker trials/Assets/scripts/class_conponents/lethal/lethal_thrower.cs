using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lethal_thrower : MonoBehaviour
{
    public GameObject lethal;
    in_game_leathal IGL;

    public GameObject currentLeathal;

    public bool tapped_lethal;

    // Start is called before the first frame update
    void Start()
    {
        generate_leathal(static_classes.Class1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && currentLeathal == null)
        {
            GameObject x = Instantiate(lethal, transform.position, Quaternion.identity);
            IGL.primed = false;
            x.GetComponent<Rigidbody>().velocity = transform.forward * IGL.container_script.CO.weight*10;
            currentLeathal = x;
            tapped_lethal = true;
        }

        if (Input.GetKeyDown(KeyCode.G) && tapped_lethal==false)
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
    
}

/*
by:Milan Manji
script descrition: this script is the biggest one so far, it is the key vital part to serialise and deserilise scriptable objects
it is also the key componet to hold the players invenerty




NOTE: DO NOT TOUCH THIS SCRIPT PLEASE

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class player_inventory
{
    //wepon
    static public List<barrel_object> barrels = new List<barrel_object>();
    static public List<weponReciver_object> recevers=new List<weponReciver_object>();
    static public List<scope_object> scopes= new List<scope_object>();
    static public List<amunition_object> amunition_types= new List<amunition_object>();
    static public List<grip_object> grips= new List<grip_object>();
    static public List<Suport_object> suports= new List<Suport_object>();
    //armour
    static public List<headgear_object> headgear= new List<headgear_object>();
    static public List<cheastplate_object> cheastplates= new List<cheastplate_object>();
    static public List<boots_object> boots= new List<boots_object>();
    //leathal
    static public List<primer_object> primers= new List<primer_object>();
    static public List<payload_object> payloads= new List<payload_object>();
    static public List<container_object> containers= new List<container_object>();


    // this is the format of a "saved object" the universal serilised form a scriptable object that we use,
    // the key identifer is the type string that tells what type of scriptable obeject should be generated or what it was formed from.
    
    [System.Serializable]
    public struct saved_object
    {
        public string type;

        //other varable that the sciptable compont might have (e.g.firerate)
        public List<int> stats;

        //the objects weight
        public float weight;

        // the name of the object
        public string name;

        //used to represent the positions for a reciver to conect to outher componets
        public List<float[]> fit;

        //now you may be wandering how we serialize the mesh and material  we dont we just het a refrence to the mesh and mat and save that
        //which then we use as a refence to load it's mat and mesh.
        public int mesh;
        public int mat;
    }



    //loads the classes from a list of saved object
    public static class_class.Class[] load_classes(List<saved_object> savedObject)
    {
        
        class_class.Class[] classes = new class_class.Class[4];
        classes[0] = static_classes.Class1;
        classes[1] = static_classes.Class2;
        classes[2] = static_classes.Class3;
        classes[3] = static_classes.Class4;


        for (int i = 0; 4 > i; i++)
        {
            if (savedObject.Count > (12 * i) && savedObject[0 + (12 * i)].name != null)
            {
                if (true)
                {
                    saved_object SO = savedObject[0 + (12 * i)];
                    barrel_object x = ScriptableObject.CreateInstance < barrel_object>();
                    x.name = SO.name;
                    x.weight = SO.weight;
                    x.lenght = SO.stats[0];
                    x.material = SO.stats[1];
                    x.specalty = SO.stats[2];
                    x.mesh = mesh_material_IDs.get_mesh_and_mat(SO.mesh, SO.mat).mesh;
                    x.mat = mesh_material_IDs.get_mesh_and_mat(SO.mesh, SO.mat).mat;
                    classes[i].Wepon.barrel = x;
                }

                if (true)
                {
                    saved_object SO = savedObject[1 + (12 * i)];
                    weponReciver_object x = ScriptableObject.CreateInstance < weponReciver_object>();
                    x.name = SO.name;
                    x.weight = SO.weight;
                    x.anumition_fit = fit_to_vector3(SO.fit[0]);
                    x.barrel_fit = fit_to_vector3(SO.fit[1]);
                    x.grip_fit = fit_to_vector3(SO.fit[2]);
                    x.scope_fit = fit_to_vector3(SO.fit[3]);
                    x.suport_fit = fit_to_vector3(SO.fit[4]);
                    x.fire_rate = SO.stats[0];
                    x.spciality = SO.stats[1];
                    x.element = SO.stats[2];
                    x.wepon_type = SO.stats[3];
                    x.mesh = mesh_material_IDs.get_mesh_and_mat(SO.mesh, SO.mat).mesh;
                    x.mat = mesh_material_IDs.get_mesh_and_mat(SO.mesh, SO.mat).mat;
                    classes[i].Wepon.reciver = x;
                }

                if (true)
                {
                    saved_object SO = savedObject[2 + (12 * i)];
                    scope_object x = ScriptableObject.CreateInstance < scope_object>();
                    x.name = SO.name;
                    x.weight = SO.weight;
                    x.speciality = SO.stats[0];
                    if (SO.stats[1] == 1)
                        x.trhermal = true;
                    x.zoom = SO.stats[2];
                    x.mesh = mesh_material_IDs.get_mesh_and_mat(SO.mesh, SO.mat).mesh;
                    x.mat = mesh_material_IDs.get_mesh_and_mat(SO.mesh, SO.mat).mat;

                    classes[i].Wepon.scope = x;
                }
                if (true)
                {
                    saved_object SO = savedObject[3 + (12 * i)];
                    amunition_object x = ScriptableObject.CreateInstance < amunition_object>();
                    x.name = SO.name;
                    x.weight = SO.weight;
                    x.blast_radius = SO.stats[0];
                    x.element = SO.stats[1];
                    x.prjectile = SO.stats[2];
                    x.range = SO.stats[3];
                    x.rounds = SO.stats[4];
                    x.speciality = SO.stats[5];
                    x.damage = SO.stats[6];
                    //
                    //mesh and material go here
                    //
                    x.mesh = mesh_material_IDs.get_mesh_and_mat(SO.mesh, SO.mat).mesh;
                    x.mat = mesh_material_IDs.get_mesh_and_mat(SO.mesh, SO.mat).mat;

                    classes[i].Wepon.amunition = x;

                }
                if (true)
                {
                    saved_object SO = savedObject[4 + (12 * i)];
                    grip_object x = ScriptableObject.CreateInstance < grip_object>();
                    x.name = SO.name;
                    x.weight = SO.weight;
                    x.grip_angle = SO.stats[0];
                    x.speciality = SO.stats[1];
                    //
                    //mesh and material go here
                    //
                    x.meshshape = mesh_material_IDs.get_mesh_and_mat(SO.mesh, SO.mat).mesh;
                    x.mat = mesh_material_IDs.get_mesh_and_mat(SO.mesh, SO.mat).mat;

                    classes[i].Wepon.grip = x;
                }
                if (true)
                {
                    saved_object SO = savedObject[5 + (12 * i)];
                    Suport_object x = ScriptableObject.CreateInstance < Suport_object>();
                    x.name = SO.name;
                    x.weight = SO.weight;
                    x.speciality = SO.stats[0];
                    //
                    //mesh and material go here
                    //
                    x.mesh = mesh_material_IDs.get_mesh_and_mat(SO.mesh, SO.mat).mesh;
                    x.mat = mesh_material_IDs.get_mesh_and_mat(SO.mesh, SO.mat).mat;

                    classes[i].Wepon.suport = x;
                }

                if (true)
                {
                    saved_object SO = savedObject[6 + (12 * i)];
                    headgear_object x = ScriptableObject.CreateInstance < headgear_object>();
                    x.name = SO.name;
                    x.weight = SO.weight;
                    x.deffence = SO.stats[0];
                    x.speciality = SO.stats[0];
                    //
                    //mesh and material go here
                    //
                    x.mesh = mesh_material_IDs.get_mesh_and_mat(SO.mesh, SO.mat).mesh;
                    x.mat = mesh_material_IDs.get_mesh_and_mat(SO.mesh, SO.mat).mat;

                    classes[i].Armour.headpeice = x;

                }

                if (true)
                {
                    saved_object SO = savedObject[7 + (12 * i)];
                    cheastplate_object x = ScriptableObject.CreateInstance < cheastplate_object>();
                    x.name = SO.name;
                    x.weight = SO.weight;
                    x.deffence = SO.stats[0];
                    x.specicality = SO.stats[0];
                    //
                    //mesh and material go here
                    //
                    x.mesh = mesh_material_IDs.get_mesh_and_mat(SO.mesh, SO.mat).mesh;
                    x.material = mesh_material_IDs.get_mesh_and_mat(SO.mesh, SO.mat).mat;

                    classes[i].Armour.chestpeice = x;

                }

                if (true)
                {
                    saved_object SO = savedObject[8 + (12 * i)];
                    boots_object x = ScriptableObject.CreateInstance < boots_object>();
                    x.name = SO.name;
                    x.weight = SO.weight;
                    x.deffence = SO.stats[0];
                    x.speciality = SO.stats[0];
                    //
                    //mesh and material go here
                    //
                    x.mesh = mesh_material_IDs.get_mesh_and_mat(SO.mesh, SO.mat).mesh;
                    x.mat = mesh_material_IDs.get_mesh_and_mat(SO.mesh, SO.mat).mat;

                    classes[i].Armour.boots = x;

                }

                if (true)
                {
                    saved_object SO = savedObject[9 + (12 * i)];
                    primer_object x = ScriptableObject.CreateInstance < primer_object>();
                    x.name = SO.name;
                    if (SO.stats[0] == 1)
                        x.manual = true;
                    x.speciality = SO.stats[1];
                    x.timer = SO.stats[2];
                    x.mesh = mesh_material_IDs.get_mesh_and_mat(SO.mesh, SO.mat).mesh;
                    x.mat = mesh_material_IDs.get_mesh_and_mat(SO.mesh, SO.mat).mat;

                    classes[i].Lethal.primer = x;
                }

                if (true)
                {
                    saved_object SO = savedObject[10 + (12 * i)];
                    payload_object x = ScriptableObject.CreateInstance < payload_object>();
                    x.name = SO.name;
                    x.damage = SO.stats[0];
                    x.element = SO.stats[1];
                    x.radious = SO.stats[2];

                    classes[i].Lethal.payload = x;
                }

                if (true)
                {
                    saved_object SO = savedObject[11 + (12 * i)];
                    container_object x = ScriptableObject.CreateInstance < container_object>();
                    x.name = SO.name;
                    x.speciality = SO.stats[0];
                    if (SO.stats[1] == 1)
                        x.sticky = true;
                    x.type = SO.stats[2];
                    x.weight = SO.stats[3];
                    //
                    //mesh and material go here
                    //
                    x.mesh = mesh_material_IDs.get_mesh_and_mat(SO.mesh, SO.mat).mesh;
                    x.mat = mesh_material_IDs.get_mesh_and_mat(SO.mesh, SO.mat).mat;

                    classes[i].Lethal.container = x;
                }

            }
        
        }
        
        



        return classes;
    }


    public static void Load_inventory(List<saved_object> savedObjects)
    {
        /*
        barrels.Clear();
        recevers.Clear();
        scopes.Clear();
        amunition_types.Clear();
        grips.Clear();
        suports.Clear();
        headgear.Clear();
        cheastplates.Clear();
        boots.Clear();
        primers.Clear();
        payloads.Clear();
        containers.Clear();
        */


        

        

        for (int i = 0; savedObjects.Count > i; i++)
        {
            //all objects are laded and saved in practicly the same way
            if (savedObjects[i].type == "barrel")
            {
                barrel_object x = ScriptableObject.CreateInstance < barrel_object>();
                x.name = savedObjects[i].name;
                x.weight = savedObjects[i].weight;
                x.lenght = savedObjects[i].stats[0];
                x.material = savedObjects[i].stats[1];
                x.specalty = savedObjects[i].stats[2];
                //
                //mesh and material go here
                //
                x.mesh= mesh_material_IDs.get_mesh_and_mat(savedObjects[i].mesh, savedObjects[i].mat).mesh;
                x.mat= mesh_material_IDs.get_mesh_and_mat(savedObjects[i].mesh, savedObjects[i].mat).mat;
                barrels.Add(x);
            }
            if (savedObjects[i].type == "reciver")
            {
                weponReciver_object x = ScriptableObject.CreateInstance < weponReciver_object>();
                x.name = savedObjects[i].name;
                x.weight = savedObjects[i].weight;
                x.anumition_fit = fit_to_vector3(savedObjects[i].fit[0]);
                x.barrel_fit = fit_to_vector3(savedObjects[i].fit[1]);
                x.grip_fit = fit_to_vector3(savedObjects[i].fit[2]);
                x.scope_fit = fit_to_vector3(savedObjects[i].fit[3]);
                x.suport_fit = fit_to_vector3(savedObjects[i].fit[4]);
                x.fire_rate = savedObjects[i].stats[0];
                x.spciality = savedObjects[i].stats[1];
                x.element=savedObjects[i].stats[2];
                x.wepon_type = savedObjects[i].stats[3];
                //
                //mesh and material go here
                //
                x.mesh = mesh_material_IDs.get_mesh_and_mat(savedObjects[i].mesh, savedObjects[i].mat).mesh;
                x.mat = mesh_material_IDs.get_mesh_and_mat(savedObjects[i].mesh, savedObjects[i].mat).mat;

                recevers.Add(x);
            }
            if (savedObjects[i].type == "scope")
            {
                scope_object x = ScriptableObject.CreateInstance < scope_object>();
                x.name = savedObjects[i].name;
                x.weight = savedObjects[i].weight;
                x.speciality = savedObjects[i].stats[0];
                if (savedObjects[i].stats[1] == 1)
                    x.trhermal = true;
                x.zoom = savedObjects[i].stats[2];
                //
                //mesh and material go here
                //
                x.mesh = mesh_material_IDs.get_mesh_and_mat(savedObjects[i].mesh, savedObjects[i].mat).mesh;
                x.mat = mesh_material_IDs.get_mesh_and_mat(savedObjects[i].mesh, savedObjects[i].mat).mat;

                scopes.Add(x);
            }
            if (savedObjects[i].type == "amunition")
            {
                amunition_object x = ScriptableObject.CreateInstance < amunition_object>();
                x.name = savedObjects[i].name;
                x.weight = savedObjects[i].weight;
                x.blast_radius = savedObjects[i].stats[0];
                x.element = savedObjects[i].stats[1];
                x.prjectile = savedObjects[i].stats[2];
                x.range = savedObjects[i].stats[3];
                x.rounds = savedObjects[i].stats[4];
                x.speciality = savedObjects[i].stats[5];
                x.damage = savedObjects[i].stats[6];
                //
                //mesh and material go here
                //
                x.mesh = mesh_material_IDs.get_mesh_and_mat(savedObjects[i].mesh, savedObjects[i].mat).mesh;
                x.mat = mesh_material_IDs.get_mesh_and_mat(savedObjects[i].mesh, savedObjects[i].mat).mat;

                amunition_types.Add(x);
            }
            if (savedObjects[i].type == "grip")
            {
                grip_object x = ScriptableObject.CreateInstance < grip_object>();
                x.name = savedObjects[i].name;
                x.weight = savedObjects[i].weight;
                x.grip_angle = savedObjects[i].stats[0];
                x.speciality = savedObjects[i].stats[1];
                //
                //mesh and material go here
                //
                x.meshshape = mesh_material_IDs.get_mesh_and_mat(savedObjects[i].mesh, savedObjects[i].mat).mesh;
                x.mat = mesh_material_IDs.get_mesh_and_mat(savedObjects[i].mesh, savedObjects[i].mat).mat;

                grips.Add(x);
            }
            if (savedObjects[i].type == "support")
            {
                Suport_object x = ScriptableObject.CreateInstance < Suport_object>();
                x.name = savedObjects[i].name;
                x.weight = savedObjects[i].weight;
                x.speciality = savedObjects[i].stats[0];
                //
                //mesh and material go here
                //
                x.mesh = mesh_material_IDs.get_mesh_and_mat(savedObjects[i].mesh, savedObjects[i].mat).mesh;
                x.mat = mesh_material_IDs.get_mesh_and_mat(savedObjects[i].mesh, savedObjects[i].mat).mat;

                suports.Add(x);
            }
            if (savedObjects[i].type == "headgear")
            {
                headgear_object x = ScriptableObject.CreateInstance < headgear_object>();
                x.name = savedObjects[i].name;
                x.weight = savedObjects[i].weight;
                x.deffence = savedObjects[i].stats[0];
                x.speciality = savedObjects[i].stats[0];
                //
                //mesh and material go here
                //
                x.mesh = mesh_material_IDs.get_mesh_and_mat(savedObjects[i].mesh, savedObjects[i].mat).mesh;
                x.mat = mesh_material_IDs.get_mesh_and_mat(savedObjects[i].mesh, savedObjects[i].mat).mat;

                headgear.Add(x);
            }
            if (savedObjects[i].type == "cheastplate")
            {
                cheastplate_object x = ScriptableObject.CreateInstance < cheastplate_object>();
                x.name = savedObjects[i].name;
                x.weight = savedObjects[i].weight;
                x.deffence = savedObjects[i].stats[0];
                x.specicality= savedObjects[i].stats[0];
                //
                //mesh and material go here
                //
                x.mesh = mesh_material_IDs.get_mesh_and_mat(savedObjects[i].mesh, savedObjects[i].mat).mesh;
                x.material = mesh_material_IDs.get_mesh_and_mat(savedObjects[i].mesh, savedObjects[i].mat).mat;

                cheastplates.Add(x);
            }
            if (savedObjects[i].type == "boots")
            {
                boots_object x = ScriptableObject.CreateInstance < boots_object>();
                x.name = savedObjects[i].name;
                x.weight = savedObjects[i].weight;
                x.deffence = savedObjects[i].stats[0];
                x.speciality = savedObjects[i].stats[0];
                //
                //mesh and material go here
                //
                x.mesh = mesh_material_IDs.get_mesh_and_mat(savedObjects[i].mesh, savedObjects[i].mat).mesh;
                x.mat = mesh_material_IDs.get_mesh_and_mat(savedObjects[i].mesh, savedObjects[i].mat).mat;

                boots.Add(x);
            }
            if (savedObjects[i].type == "primer")
            {
                primer_object x = ScriptableObject.CreateInstance < primer_object>();
                x.name = savedObjects[i].name;
                if(savedObjects[i].stats[0]==1)
                    x.manual = true;
                x.speciality = savedObjects[i].stats[1];
                x.timer = savedObjects[i].stats[2];
                x.mesh = mesh_material_IDs.get_mesh_and_mat(savedObjects[i].mesh, savedObjects[i].mat).mesh;
                x.mat = mesh_material_IDs.get_mesh_and_mat(savedObjects[i].mesh, savedObjects[i].mat).mat;

                primers.Add(x);
            }
            if (savedObjects[i].type == "payload")
            {
                payload_object x = ScriptableObject.CreateInstance < payload_object>();
                x.name = savedObjects[i].name;
                x.damage = savedObjects[i].stats[0];
                x.element = savedObjects[i].stats[1];
                x.radious = savedObjects[i].stats[2];
                //
                //mesh and material go here
                //
                

                payloads.Add(x);
            }
            if (savedObjects[i].type == "container")
            {
                container_object x = ScriptableObject.CreateInstance < container_object>();
                x.name = savedObjects[i].name;
                x.speciality = savedObjects[i].stats[0];
                if(savedObjects[i].stats[1]==1)
                    x.sticky = true;
                x.type = savedObjects[i].stats[2];
                x.weight = savedObjects[i].stats[3];
                //
                //mesh and material go here
                //
                x.mesh = mesh_material_IDs.get_mesh_and_mat(savedObjects[i].mesh, savedObjects[i].mat).mesh;
                x.mat = mesh_material_IDs.get_mesh_and_mat(savedObjects[i].mesh, savedObjects[i].mat).mat;

                containers.Add(x);
            }
        }
    }

    public static void saveinventory()
    {

        //___________________________________________________classes

        List<class_class.Class> classes= new List<class_class.Class>();
        classes.Add(static_classes.Class1);
        classes.Add(static_classes.Class2);
        classes.Add(static_classes.Class3);
        classes.Add(static_classes.Class4);

        List<saved_object> saved_classes = new List<saved_object>();

        

        for (int i = 0; 4 > i; i++)
        {
            if (classes[i].Wepon.barrel != null)
            {

                //_______________________________________Barrel



                saved_object x = new saved_object { type = "barrel" };
                x.stats = new List<int>();
                x.weight = classes[i].Wepon.barrel.weight;
                x.name = classes[i].Wepon.barrel.name;
                GetStats(x).Add(classes[i].Wepon.barrel.lenght);
                GetStats(x).Add(classes[i].Wepon.barrel.material);
                GetStats(x).Add(classes[i].Wepon.barrel.specalty);

                Vector2 MAM = mesh_material_IDs.getIntID(classes[i].Wepon.barrel.mesh, classes[i].Wepon.barrel.mat);
                x.mesh = (int)MAM.x;
                x.mat = (int)MAM.y;


                saved_classes.Add(x);



                //_______________________________________recever


                x = new saved_object { type = "reciver" };
                x.stats = new List<int>();
                x.fit = new List<float[]>();
                x.name = classes[i].Wepon.reciver.name;
                x.weight = classes[i].Wepon.reciver.weight;
                //reciver fits
                //amunition
                float[] fit = new float[3];
                fit[0] = classes[i].Wepon.reciver.anumition_fit.x;
                fit[1] = classes[i].Wepon.reciver.anumition_fit.y;
                fit[2] = classes[i].Wepon.reciver.anumition_fit.z;
                x.fit.Add(fit);
                fit = new float[3];
                //barrel
                fit[0] = classes[i].Wepon.reciver.barrel_fit.x;
                fit[1] = classes[i].Wepon.reciver.barrel_fit.y;
                fit[2] = classes[i].Wepon.reciver.barrel_fit.z;
                x.fit.Add(fit);
                fit = new float[3];
                //grip
                fit[0] = classes[i].Wepon.reciver.grip_fit.x;
                fit[1] = classes[i].Wepon.reciver.grip_fit.y;
                fit[2] = classes[i].Wepon.reciver.grip_fit.z;
                x.fit.Add(fit);
                fit = new float[3];
                //scope
                fit[0] = classes[i].Wepon.reciver.scope_fit.x;
                fit[1] = classes[i].Wepon.reciver.scope_fit.y;
                fit[2] = classes[i].Wepon.reciver.scope_fit.z;
                x.fit.Add(fit);
                fit = new float[3];
                //support
                fit[0] = classes[i].Wepon.reciver.suport_fit.x;
                fit[1] = classes[i].Wepon.reciver.suport_fit.y;
                fit[2] = classes[i].Wepon.reciver.suport_fit.z;
                x.fit.Add(fit);

                //stats
                GetStats(x).Add(classes[i].Wepon.reciver.fire_rate);
                GetStats(x).Add(classes[i].Wepon.reciver.spciality);
                GetStats(x).Add(classes[i].Wepon.reciver.element);
                GetStats(x).Add(classes[i].Wepon.reciver.wepon_type);


                MAM = mesh_material_IDs.getIntID(classes[i].Wepon.reciver.mesh, classes[i].Wepon.reciver.mat);
                x.mesh = (int)MAM.x;
                x.mat = (int)MAM.y;


                saved_classes.Add(x);

                //_______________________________________scopes


                x = new saved_object { type = "scope" };
                x.stats = new List<int>();
                x.name = classes[i].Wepon.scope.name;
                x.weight = classes[i].Wepon.scope.weight;
                GetStats(x).Add(classes[i].Wepon.scope.speciality);
                if (classes[i].Wepon.scope.trhermal == true)
                {
                    GetStats(x).Add(1);
                }
                else
                {
                    GetStats(x).Add(0);
                }
                GetStats(x).Add(classes[i].Wepon.scope.zoom);


                MAM = mesh_material_IDs.getIntID(classes[i].Wepon.scope.mesh, classes[i].Wepon.scope.mat);
                x.mesh = (int)MAM.x;
                x.mat = (int)MAM.y;


                saved_classes.Add(x);


                //____________________________________________________amunition

                x = new saved_object { type = "amunition" };
                x.stats = new List<int>();
                x.name = classes[i].Wepon.amunition.name;
                x.weight = classes[i].Wepon.amunition.weight;
                GetStats(x).Add(classes[i].Wepon.amunition.blast_radius);
                GetStats(x).Add(classes[i].Wepon.amunition.element);
                GetStats(x).Add(classes[i].Wepon.amunition.prjectile);
                GetStats(x).Add(classes[i].Wepon.amunition.range);
                GetStats(x).Add(classes[i].Wepon.amunition.rounds);
                GetStats(x).Add(classes[i].Wepon.amunition.speciality);
                GetStats(x).Add(classes[i].Wepon.amunition.damage);


                MAM = mesh_material_IDs.getIntID(classes[i].Wepon.amunition.mesh, classes[i].Wepon.amunition.mat);
                x.mesh = (int)MAM.x;
                x.mat = (int)MAM.y;

                saved_classes.Add(x);

                //____________________________________________________grip

                x = new saved_object { type = "grip" };
                x.stats = new List<int>();
                x.name = classes[i].Wepon.grip.name;
                x.weight = classes[i].Wepon.grip.weight;
                GetStats(x).Add(classes[i].Wepon.grip.grip_angle);
                GetStats(x).Add(classes[i].Wepon.grip.speciality);

                MAM = mesh_material_IDs.getIntID(classes[i].Wepon.grip.meshshape, classes[i].Wepon.grip.mat);
                x.mesh = (int)MAM.x;
                x.mat = (int)MAM.y;

                saved_classes.Add(x);

                //____________________________________________________support

                x = new saved_object { type = "support" };
                x.stats = new List<int>();
                x.name = classes[i].Wepon.suport.name;
                x.weight = classes[i].Wepon.suport.weight;
                GetStats(x).Add(classes[i].Wepon.suport.speciality);

                MAM = mesh_material_IDs.getIntID(classes[i].Wepon.suport.mesh, classes[i].Wepon.suport.mat);
                x.mesh = (int)MAM.x;
                x.mat = (int)MAM.y;

                saved_classes.Add(x);

                //____________________________________________________headgear

                x = new saved_object { type = "headgear" };
                x.stats = new List<int>();
                x.name = classes[i].Armour.headpeice.name;
                x.weight = classes[i].Armour.headpeice.weight;
                GetStats(x).Add(classes[i].Armour.headpeice.deffence);
                GetStats(x).Add(classes[i].Armour.headpeice.speciality);

                MAM = mesh_material_IDs.getIntID(classes[i].Armour.headpeice.mesh, classes[i].Armour.headpeice.mat);
                x.mesh = (int)MAM.x;
                x.mat = (int)MAM.y;

                saved_classes.Add(x);

                //____________________________________________________cheastplate
                x = new saved_object { type = "cheastplate" };
                x.stats = new List<int>();
                x.name = classes[i].Armour.chestpeice.name;
                x.weight = classes[i].Armour.chestpeice.weight;
                GetStats(x).Add(classes[i].Armour.chestpeice.deffence);
                GetStats(x).Add(classes[i].Armour.chestpeice.specicality);

                MAM = mesh_material_IDs.getIntID(classes[i].Armour.chestpeice.mesh, classes[i].Armour.chestpeice.material);
                x.mesh = (int)MAM.x;
                x.mat = (int)MAM.y;

                saved_classes.Add(x);

                //____________________________________________________boots
                x = new saved_object { type = "boots" };
                x.stats = new List<int>();
                x.name = classes[i].Armour.boots.name;
                x.weight = classes[i].Armour.boots.weight;
                GetStats(x).Add(classes[i].Armour.boots.deffence);
                GetStats(x).Add(classes[i].Armour.boots.speciality);

                MAM = mesh_material_IDs.getIntID(classes[i].Armour.boots.mesh, classes[i].Armour.boots.mat);
                x.mesh = (int)MAM.x;
                x.mat = (int)MAM.y;

                saved_classes.Add(x);


                //____________________________________________________primer

                x = new saved_object { type = "primer" };
                x.stats = new List<int>();
                x.name = classes[i].Lethal.primer.name;
                if (classes[i].Lethal.primer.manual == true)
                {
                    GetStats(x).Add(1);
                }
                else
                {
                    GetStats(x).Add(0);
                }
                GetStats(x).Add(classes[i].Lethal.primer.speciality);
                GetStats(x).Add(classes[i].Lethal.primer.timer);

                MAM = mesh_material_IDs.getIntID(classes[i].Lethal.primer.mesh, classes[i].Lethal.primer.mat);
                x.mesh = (int)MAM.x;
                x.mat = (int)MAM.y;

                saved_classes.Add(x);

                //____________________________________________________payload
                x = new saved_object { type = "payload" };
                x.stats = new List<int>();
                x.name = classes[i].Lethal.payload.name;
                GetStats(x).Add(classes[i].Lethal.payload.damage);
                GetStats(x).Add(classes[i].Lethal.payload.element);
                GetStats(x).Add(classes[i].Lethal.payload.radious);
                saved_classes.Add(x);


                //____________________________________________________container

                x = new saved_object { type = "container" };
                x.stats = new List<int>();
                x.name = classes[i].Lethal.container.name;
                GetStats(x).Add(classes[i].Lethal.container.speciality);
                if (classes[i].Lethal.container.sticky == true)
                {
                    GetStats(x).Add(1);
                }
                else
                {
                    GetStats(x).Add(0);
                }
                GetStats(x).Add(classes[i].Lethal.container.type);
                GetStats(x).Add(classes[i].Lethal.container.weight);

                MAM = mesh_material_IDs.getIntID(classes[i].Lethal.container.mesh, classes[i].Lethal.container.mat);
                x.mesh = (int)MAM.x;
                x.mat = (int)MAM.y;

                saved_classes.Add(x);
            }
        }
        save_system.saveClases(saved_classes);



        //____________________________________________________inventory
        //
        //
        //                                              wepon
        //
        //
        List<saved_object> saved_Objects=new List<saved_object>();
        for (int i = 0; barrels.Count > i; i++)
        {
            saved_object x = new saved_object { type = "barrel" };
            x.stats = new List<int>();
            x.weight = barrels[i].weight;
            x.name = barrels[i].name;
            GetStats(x).Add(barrels[i].lenght);
            GetStats(x).Add(barrels[i].material);
            GetStats(x).Add(barrels[i].specalty);

            Vector2 MAM = mesh_material_IDs.getIntID(barrels[i].mesh, barrels[i].mat);
            x.mesh = (int)MAM.x;
            x.mat = (int)MAM.y;


            saved_Objects.Add(x);
        }
        for (int i = 0; recevers.Count > i; i++)
        {
            saved_object x = new saved_object { type = "reciver" };
            x.stats = new List<int>();
            x.fit = new List<float[]>();
            x.name = recevers[i].name;
            x.weight = recevers[i].weight;
            //reciver fits
            //amunition
            float[] fit = new float[3];
            fit[0] = recevers[i].anumition_fit.x;
            fit[1] = recevers[i].anumition_fit.y;
            fit[2] = recevers[i].anumition_fit.z;
            x.fit.Add(fit);
            fit = new float[3];
            //barrel
            fit[0] = recevers[i].barrel_fit.x;
            fit[1] = recevers[i].barrel_fit.y;
            fit[2] = recevers[i].barrel_fit.z;
            x.fit.Add(fit);
            fit = new float[3];
            //grip
            fit[0] = recevers[i].grip_fit.x;
            fit[1] = recevers[i].grip_fit.y;
            fit[2] = recevers[i].grip_fit.z;
            x.fit.Add(fit);
            fit = new float[3];
            //scope
            fit[0] = recevers[i].scope_fit.x;
            fit[1] = recevers[i].scope_fit.y;
            fit[2] = recevers[i].scope_fit.z;
            x.fit.Add(fit);
            fit = new float[3];
            //support
            fit[0] = recevers[i].suport_fit.x;
            fit[1] = recevers[i].suport_fit.y;
            fit[2] = recevers[i].suport_fit.z;
            x.fit.Add(fit);
            
            //stats
            GetStats(x).Add(recevers[i].fire_rate);
            GetStats(x).Add(recevers[i].spciality);
            GetStats(x).Add(recevers[i].element);
            GetStats(x).Add(recevers[i].wepon_type);


            Vector2 MAM = mesh_material_IDs.getIntID(recevers[i].mesh, recevers[i].mat);
            x.mesh = (int)MAM.x;
            x.mat = (int)MAM.y;

            saved_Objects.Add(x);
        }
        for(int i=0;scopes.Count>i; i++)
        {
            saved_object x = new saved_object { type = "scope" };
            x.stats = new List<int>();
            x.name = scopes[i].name;
            x.weight = scopes[i].weight;
            GetStats(x).Add(scopes[i].speciality);
            if (scopes[i].trhermal == true)
            {
                GetStats(x).Add(1);
            }
            else
            {
                GetStats(x).Add(0);
            }
            GetStats(x).Add(scopes[i].zoom);


            Vector2 MAM = mesh_material_IDs.getIntID(scopes[i].mesh, scopes[i].mat);
            x.mesh = (int)MAM.x;
            x.mat = (int)MAM.y;

            saved_Objects.Add(x);
        }
        for(int i=0;amunition_types.Count>i; i++)
        {
            saved_object x = new saved_object { type = "amunition" };
            x.stats = new List<int>();
            x.name = amunition_types[i].name;
            x.weight = amunition_types[i].weight;
            GetStats(x).Add(amunition_types[i].blast_radius);
            GetStats(x).Add(amunition_types[i].element);
            GetStats(x).Add(amunition_types[i].prjectile);
            GetStats(x).Add(amunition_types[i].range);
            GetStats(x).Add(amunition_types[i].rounds);
            GetStats(x).Add(amunition_types[i].speciality);
            GetStats(x).Add(amunition_types[i].damage);


            Vector2 MAM = mesh_material_IDs.getIntID(amunition_types[i].mesh, amunition_types[i].mat);
            x.mesh = (int)MAM.x;
            x.mat = (int)MAM.y;

            saved_Objects.Add(x);
        }
        for(int i = 0; grips.Count > i; i++)
        {
            saved_object x = new saved_object { type = "grip" };
            x.stats = new List<int>();
            x.name = grips[i].name;
            x.weight = grips[i].weight;
            GetStats(x).Add(grips[i].grip_angle);
            GetStats(x).Add(grips[i].speciality);

            Vector2 MAM = mesh_material_IDs.getIntID(grips[i].meshshape, grips[i].mat);
            x.mesh = (int)MAM.x;
            x.mat = (int)MAM.y;

            saved_Objects.Add(x);
        }
        for (int i=0;suports.Count>i ;i++)
        {
            saved_object x = new saved_object { type = "support" };
            x.stats = new List<int>();
            x.name = suports[i].name;
            x.weight = suports[i].weight;
            GetStats(x).Add(suports[i].speciality);

            Vector2 MAM = mesh_material_IDs.getIntID(suports[i].mesh, suports[i].mat);
            x.mesh = (int)MAM.x;
            x.mat = (int)MAM.y;

            saved_Objects.Add(x);
        }
        //
        //
        //armour
        //
        //
        for (int i = 0;headgear.Count>i; i++)
        {
            saved_object x = new saved_object { type = "headgear" };
            x.stats = new List<int>();
            x.name = headgear[i].name;
            x.weight = headgear[i].weight;
            GetStats(x).Add(headgear[i].deffence);
            GetStats(x).Add(headgear[i].speciality);

            Vector2 MAM = mesh_material_IDs.getIntID(headgear[i].mesh, headgear[i].mat);
            x.mesh = (int)MAM.x;
            x.mat = (int)MAM.y;

            saved_Objects.Add(x);
        }
        for(int i =0;cheastplates.Count>i; i++)
        {
            saved_object x = new saved_object { type = "cheastplate" };
            x.stats = new List<int>();
            x.name = cheastplates[i].name;
            x.weight = cheastplates[i].weight;
            GetStats(x).Add(cheastplates[i].deffence);
            GetStats(x).Add(cheastplates[i].specicality);

            Vector2 MAM = mesh_material_IDs.getIntID(cheastplates[i].mesh, cheastplates[i].material);
            x.mesh = (int)MAM.x;
            x.mat = (int)MAM.y;

            saved_Objects.Add(x);
        }
        for(int i=0;boots.Count>i; i++)
        {
            saved_object x = new saved_object { type = "boots" };
            x.stats = new List<int>();
            x.name = boots[i].name;
            x.weight = boots[i].weight;
            GetStats(x).Add(boots[i].deffence);
            GetStats(x).Add(boots[i].speciality);

            Vector2 MAM = mesh_material_IDs.getIntID(boots[i].mesh, boots[i].mat);
            x.mesh = (int)MAM.x;
            x.mat = (int)MAM.y;

            saved_Objects.Add(x);
        }
        //
        //
        //leathal
        //
        //
        for(int i=0;primers.Count>i; i++)
        {
            saved_object x = new saved_object { type = "primer" };
            x.stats = new List<int>();
            x.name = primers[i].name;
            if (primers[i].manual == true)
            {
                GetStats(x).Add(1);
            }
            else
            {
                GetStats(x).Add(0);
            }
            GetStats(x).Add(primers[i].speciality);
            GetStats(x).Add(primers[i].timer);

            Vector2 MAM = mesh_material_IDs.getIntID(primers[i].mesh, primers[i].mat);
            x.mesh = (int)MAM.x;
            x.mat = (int)MAM.y;

            saved_Objects.Add(x);
        }
        for(int i=0;payloads.Count>i; i++)
        {
            saved_object x = new saved_object { type = "payload" };
            x.stats = new List<int>();
            x.name = payloads[i].name;
            GetStats(x).Add(payloads[i].damage);
            GetStats(x).Add(payloads[i].element);
            GetStats(x).Add(payloads[i].radious);
            saved_Objects.Add(x);
        }
        for(int i=0;containers.Count>i; i++)
        {
            saved_object x = new saved_object { type = "container" };
            x.stats = new List<int>();
            x.name = containers[i].name;
            GetStats(x).Add(containers[i].speciality);
            if (containers[i].sticky == true)
            {
                GetStats(x).Add(1);
            }
            else
            {
                GetStats(x).Add(0);
            }
            GetStats(x).Add(containers[i].type);
            GetStats(x).Add(containers[i].weight);

            Vector2 MAM = mesh_material_IDs.getIntID(containers[i].mesh, containers[i].mat);
            x.mesh = (int)MAM.x;
            x.mat = (int)MAM.y;

            saved_Objects.Add(x);

            
        }
        save_system.saveData(saved_Objects);
    }

    private static List<int> GetStats(saved_object x)
    {
        return x.stats;
    }

    static Vector3 fit_to_vector3(float[] fit)
    {
        Vector3 x = new Vector3(fit[0], fit[1], fit[2]);

        return x;
    }


    public static List<saved_object> Class_TO_Saved_object()
    {

        List<class_class.Class> classes = new List<class_class.Class>();
        classes.Add(static_classes.Class1);
        classes.Add(static_classes.Class2);
        classes.Add(static_classes.Class3);
        classes.Add(static_classes.Class4);

        List<saved_object> saved_classes = new List<saved_object>();

        for (int i = 0; 4 > i; i++)
        {
            if (classes[i].Wepon.barrel != null)
            {

                //_______________________________________Barrel



                saved_object x = new saved_object { type = "barrel" };
                x.stats = new List<int>();
                x.weight = classes[i].Wepon.barrel.weight;
                x.name = classes[i].Wepon.barrel.name;
                GetStats(x).Add(classes[i].Wepon.barrel.lenght);
                GetStats(x).Add(classes[i].Wepon.barrel.material);
                GetStats(x).Add(classes[i].Wepon.barrel.specalty);

                Vector2 MAM = mesh_material_IDs.getIntID(classes[i].Wepon.barrel.mesh, classes[i].Wepon.barrel.mat);
                x.mesh = (int)MAM.x;
                x.mat = (int)MAM.y;


                saved_classes.Add(x);



                //_______________________________________recever


                x = new saved_object { type = "reciver" };
                x.stats = new List<int>();
                x.fit = new List<float[]>();
                x.name = classes[i].Wepon.reciver.name;
                x.weight = classes[i].Wepon.reciver.weight;
                //reciver fits
                //amunition
                float[] fit = new float[3];
                fit[0] = classes[i].Wepon.reciver.anumition_fit.x;
                fit[1] = classes[i].Wepon.reciver.anumition_fit.y;
                fit[2] = classes[i].Wepon.reciver.anumition_fit.z;
                x.fit.Add(fit);
                fit = new float[3];
                //barrel
                fit[0] = classes[i].Wepon.reciver.barrel_fit.x;
                fit[1] = classes[i].Wepon.reciver.barrel_fit.y;
                fit[2] = classes[i].Wepon.reciver.barrel_fit.z;
                x.fit.Add(fit);
                fit = new float[3];
                //grip
                fit[0] = classes[i].Wepon.reciver.grip_fit.x;
                fit[1] = classes[i].Wepon.reciver.grip_fit.y;
                fit[2] = classes[i].Wepon.reciver.grip_fit.z;
                x.fit.Add(fit);
                fit = new float[3];
                //scope
                fit[0] = classes[i].Wepon.reciver.scope_fit.x;
                fit[1] = classes[i].Wepon.reciver.scope_fit.y;
                fit[2] = classes[i].Wepon.reciver.scope_fit.z;
                x.fit.Add(fit);
                fit = new float[3];
                //support
                fit[0] = classes[i].Wepon.reciver.suport_fit.x;
                fit[1] = classes[i].Wepon.reciver.suport_fit.y;
                fit[2] = classes[i].Wepon.reciver.suport_fit.z;
                x.fit.Add(fit);

                //stats
                GetStats(x).Add(classes[i].Wepon.reciver.fire_rate);
                GetStats(x).Add(classes[i].Wepon.reciver.spciality);
                GetStats(x).Add(classes[i].Wepon.reciver.element);
                GetStats(x).Add(classes[i].Wepon.reciver.wepon_type);


                MAM = mesh_material_IDs.getIntID(classes[i].Wepon.reciver.mesh, classes[i].Wepon.reciver.mat);
                x.mesh = (int)MAM.x;
                x.mat = (int)MAM.y;


                saved_classes.Add(x);

                //_______________________________________scopes


                x = new saved_object { type = "scope" };
                x.stats = new List<int>();
                x.name = classes[i].Wepon.scope.name;
                x.weight = classes[i].Wepon.scope.weight;
                GetStats(x).Add(classes[i].Wepon.scope.speciality);
                if (classes[i].Wepon.scope.trhermal == true)
                {
                    GetStats(x).Add(1);
                }
                else
                {
                    GetStats(x).Add(0);
                }
                GetStats(x).Add(classes[i].Wepon.scope.zoom);


                MAM = mesh_material_IDs.getIntID(classes[i].Wepon.scope.mesh, classes[i].Wepon.scope.mat);
                x.mesh = (int)MAM.x;
                x.mat = (int)MAM.y;


                saved_classes.Add(x);


                //____________________________________________________amunition

                x = new saved_object { type = "amunition" };
                x.stats = new List<int>();
                x.name = classes[i].Wepon.amunition.name;
                x.weight = classes[i].Wepon.amunition.weight;
                GetStats(x).Add(classes[i].Wepon.amunition.blast_radius);
                GetStats(x).Add(classes[i].Wepon.amunition.element);
                GetStats(x).Add(classes[i].Wepon.amunition.prjectile);
                GetStats(x).Add(classes[i].Wepon.amunition.range);
                GetStats(x).Add(classes[i].Wepon.amunition.rounds);
                GetStats(x).Add(classes[i].Wepon.amunition.speciality);
                GetStats(x).Add(classes[i].Wepon.amunition.damage);


                MAM = mesh_material_IDs.getIntID(classes[i].Wepon.amunition.mesh, classes[i].Wepon.amunition.mat);
                x.mesh = (int)MAM.x;
                x.mat = (int)MAM.y;

                saved_classes.Add(x);

                //____________________________________________________grip

                x = new saved_object { type = "grip" };
                x.stats = new List<int>();
                x.name = classes[i].Wepon.grip.name;
                x.weight = classes[i].Wepon.grip.weight;
                GetStats(x).Add(classes[i].Wepon.grip.grip_angle);
                GetStats(x).Add(classes[i].Wepon.grip.speciality);

                MAM = mesh_material_IDs.getIntID(classes[i].Wepon.grip.meshshape, classes[i].Wepon.grip.mat);
                x.mesh = (int)MAM.x;
                x.mat = (int)MAM.y;

                saved_classes.Add(x);

                //____________________________________________________support

                x = new saved_object { type = "support" };
                x.stats = new List<int>();
                x.name = classes[i].Wepon.suport.name;
                x.weight = classes[i].Wepon.suport.weight;
                GetStats(x).Add(classes[i].Wepon.suport.speciality);

                MAM = mesh_material_IDs.getIntID(classes[i].Wepon.suport.mesh, classes[i].Wepon.suport.mat);
                x.mesh = (int)MAM.x;
                x.mat = (int)MAM.y;

                saved_classes.Add(x);

                //____________________________________________________headgear

                x = new saved_object { type = "headgear" };
                x.stats = new List<int>();
                x.name = classes[i].Armour.headpeice.name;
                x.weight = classes[i].Armour.headpeice.weight;
                GetStats(x).Add(classes[i].Armour.headpeice.deffence);
                GetStats(x).Add(classes[i].Armour.headpeice.speciality);

                MAM = mesh_material_IDs.getIntID(classes[i].Armour.headpeice.mesh, classes[i].Armour.headpeice.mat);
                x.mesh = (int)MAM.x;
                x.mat = (int)MAM.y;

                saved_classes.Add(x);

                //____________________________________________________cheastplate
                x = new saved_object { type = "cheastplate" };
                x.stats = new List<int>();
                x.name = classes[i].Armour.chestpeice.name;
                x.weight = classes[i].Armour.chestpeice.weight;
                GetStats(x).Add(classes[i].Armour.chestpeice.deffence);
                GetStats(x).Add(classes[i].Armour.chestpeice.specicality);

                MAM = mesh_material_IDs.getIntID(classes[i].Armour.chestpeice.mesh, classes[i].Armour.chestpeice.material);
                x.mesh = (int)MAM.x;
                x.mat = (int)MAM.y;

                saved_classes.Add(x);

                //____________________________________________________boots
                x = new saved_object { type = "boots" };
                x.stats = new List<int>();
                x.name = classes[i].Armour.boots.name;
                x.weight = classes[i].Armour.boots.weight;
                GetStats(x).Add(classes[i].Armour.boots.deffence);
                GetStats(x).Add(classes[i].Armour.boots.speciality);

                MAM = mesh_material_IDs.getIntID(classes[i].Armour.boots.mesh, classes[i].Armour.boots.mat);
                x.mesh = (int)MAM.x;
                x.mat = (int)MAM.y;

                saved_classes.Add(x);


                //____________________________________________________primer

                x = new saved_object { type = "primer" };
                x.stats = new List<int>();
                x.name = classes[i].Lethal.primer.name;
                if (classes[i].Lethal.primer.manual == true)
                {
                    GetStats(x).Add(1);
                }
                else
                {
                    GetStats(x).Add(0);
                }
                GetStats(x).Add(classes[i].Lethal.primer.speciality);
                GetStats(x).Add(classes[i].Lethal.primer.timer);

                MAM = mesh_material_IDs.getIntID(classes[i].Lethal.primer.mesh, classes[i].Lethal.primer.mat);
                x.mesh = (int)MAM.x;
                x.mat = (int)MAM.y;

                saved_classes.Add(x);

                //____________________________________________________payload
                x = new saved_object { type = "payload" };
                x.stats = new List<int>();
                x.name = classes[i].Lethal.payload.name;
                GetStats(x).Add(classes[i].Lethal.payload.damage);
                GetStats(x).Add(classes[i].Lethal.payload.element);
                GetStats(x).Add(classes[i].Lethal.payload.radious);
                saved_classes.Add(x);


                //____________________________________________________container

                x = new saved_object { type = "container" };
                x.stats = new List<int>();
                x.name = classes[i].Lethal.container.name;
                GetStats(x).Add(classes[i].Lethal.container.speciality);
                if (classes[i].Lethal.container.sticky == true)
                {
                    GetStats(x).Add(1);
                }
                else
                {
                    GetStats(x).Add(0);
                }
                GetStats(x).Add(classes[i].Lethal.container.type);
                GetStats(x).Add(classes[i].Lethal.container.weight);

                MAM = mesh_material_IDs.getIntID(classes[i].Lethal.container.mesh, classes[i].Lethal.container.mat);
                x.mesh = (int)MAM.x;
                x.mat = (int)MAM.y;

                saved_classes.Add(x);
            }
        }
        return(saved_classes);
    }
}

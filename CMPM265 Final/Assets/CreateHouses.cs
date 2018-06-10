using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AX;

public class CreateHouses : MonoBehaviour
{
    public AXModel model;
    //public AXParameter sizeX, sizeY, sizeZ, posX, posY, posZ;
    float randX, dist;
    //RuntimeStuff rts;
    //GameObject[] models;
    //int copies;
    //bool check;

    // Use this for initialization
    void Start()
    {
        //rts = GameObject.Find("Main Camera").GetComponent<RuntimeStuff>();
       // models = GameObject.FindGameObjectsWithTag("Models");

        if (model != null)
        {
            //sizeX = model.getParameter("Full House_Scale_X");
            //sizeY = model.getParameter("Full House_Scale_Y");
            //sizeZ = model.getParameter("Full House_Scale_Z");
            //posX = model.getParameter("Full House_Trans_X");
            //posY = model.getParameter("Full House_Trans_Y");
            //posZ = model.getParameter("Full House_Trans_Z");
        }
        dist = 0;
        randX = 1f; 
        //check = false;
    }

    private void Update()
    {
        //clones a new house with different dimensions 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //int copies = models.Length - 1;
            //Debug.Log(copies);
            float oldRandX = randX;
            randX = Random.Range(.5f, 1.5f);
            dist += (10.2f * randX) + (10.2f * oldRandX);  
            AXModel newModel = Instantiate(model, new Vector3(dist , model.transform.position.y, model.transform.position.z), Quaternion.identity);
            newModel.GetComponent<CreateHouses>().enabled = false;
            //changes the width of the landscape
            newModel.getParameter("Full House_Scale_X").initiateRipple_setFloatValueFromGUIChange(randX);
            //changes the height of the landscape
            newModel.getParameter("Full House_Scale_Y").initiateRipple_setFloatValueFromGUIChange(Random.Range(.5f, 1.5f));
            //changes the length of the landscape
            newModel.getParameter("Full House_Scale_Z").initiateRipple_setFloatValueFromGUIChange(Random.Range(.5f, 1.5f));

            model = newModel;
            model.build();
            Debug.Log(newModel.transform.position);
            //if (copies > 0)
            //{
            //    check = true;
            //}
        }

        //if (check)
        //{
        //    models = GameObject.FindGameObjectsWithTag("Models");
        //    Debug.Log("._>. " + gameObject.name);
        //    if (models.Length - copies > 1)
        //    {
        //        for (int i = models.Length - 2; i >= models.Length - (copies + 1); i--)
        //        {
        //            Destroy(models[i]);
        //        }
        //        check = false;
        //    }
        //}
    }
}



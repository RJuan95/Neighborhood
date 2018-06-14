using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AX;

public class CreateHouses : MonoBehaviour
{
    public Vector2 SizeRange;
    public AXModel model;
    public List<AXGameObject> border;
    public AXGameObject entrance;
    public AXGameObject backEntrance;
    public AXGameObject carEntrance;
    public List<AXGameObject> LongWindows;
    public List<AXGameObject> ShortWindows;
    public AXGameObject house;
    public AXGameObject houseGar;
    public AXGameObject top;
    public AXGameObject topGar;
    public AXGameObject land;
    public AXGameObject swimmingPool;
    public AXGameObject monument;
    private TerrainGenerator field;
    public List<Material> Fence, Door, Backdoor, Garage, BigWindow, LittleWindow, Walls, Roof, Grass, Landscape, Pool, Statue;

    float randX, randY, randZ, posX, distX, distZ;

    // Use this for initialization
    void Start()
    {
        if (model != null)
        {
            randX = model.transform.localScale.x;
            distX = model.transform.position.x;
            posX = distX;
            distZ = model.transform.position.z;
            field = GameObject.Find("Grass").GetComponent<TerrainGenerator>();
            field.bumpiness = .1f;
        }
    }

    private void Update()
    {
        //clones a new house with different dimensions 
        if (Input.GetKeyDown(KeyCode.Space)|| Input.GetKeyDown(KeyCode.Backspace))
        {
            GenerateMaterials();
            GenerateHouse();
        }
    }

    void GenerateHouse()
    {
        //ensures houses are created in a horizontal line
        float oldRandX = randX;
        randX = Random.Range(SizeRange.x, SizeRange.y);
        randY = Random.Range(SizeRange.x, SizeRange.y);
        randZ = Random.Range(SizeRange.x, SizeRange.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            distX += (10.2f * randX) + (10.2f * oldRandX);
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            distX = posX;
            distZ += (27.5f * SizeRange.y);
        }

        //Creates a new house
        AXModel newModel = Instantiate(model, new Vector3(distX, model.transform.position.y, distZ), Quaternion.identity);

        //changes the width of the landscape
        newModel.getParameter("Full House_Scale_X").initiateRipple_setFloatValueFromGUIChange(randX);
        field.scaleX = randX;

        //changes the height of the landscape
        newModel.getParameter("Full House_Scale_Y").initiateRipple_setFloatValueFromGUIChange(randY);
        field.scaleY = randY;

        //changes the length of the landscape
        newModel.getParameter("Full House_Scale_Z").initiateRipple_setFloatValueFromGUIChange(randZ);
        field.scaleZ = randZ;

        GenerateBackyard(newModel);

        newModel.build();
    }

    //changes the materials for each new house
    void GenerateMaterials()
    {
        //changes the fence to a new random material
        int index = Random.Range(0, Fence.Count);
        for (int i = 0; i < border.Count; i++)
        {
            border[i].parametricObject.axMat.mat = Fence[index];
        }

        //changes the door to a new random material
        int index1 = Random.Range(0, Door.Count);
        entrance.parametricObject.axMat.mat = Door[index1];

        
        //changes the backdoor to a new random material
        int index2 = Random.Range(0, Backdoor.Count);
        backEntrance.parametricObject.axMat.mat = Backdoor[index2];

        //changes the garage to a new random material
        int index3 = Random.Range(0, Garage.Count);
        carEntrance.parametricObject.axMat.mat = Garage[index3];

        //changes the big windows to a new random material
        int index4 = Random.Range(0, BigWindow.Count);
        for (int i = 0; i < BigWindow.Count; i++)
        {
            LongWindows[i].parametricObject.axMat.mat = BigWindow[index4];
        }

        //changes the small windows to a new random material
        int index5 = Random.Range(0, LittleWindow.Count);
        for (int i = 0; i < LittleWindow.Count; i++)
        {
            ShortWindows[i].parametricObject.axMat.mat = LittleWindow[index5];
        }

        //changes the house to a new random material
        int index6 = Random.Range(0, Walls.Count);
        house.parametricObject.axMat.mat = Walls[index6];
        houseGar.parametricObject.axMat.mat = Walls[index6];

        //changes the roof to a new random material
        int index7 = Random.Range(0, Roof.Count);
        top.parametricObject.axMat.mat = Roof[index7];
        topGar.parametricObject.axMat.mat = Roof[index7];

        //changes the grass to a new random material
        field.timestamp = Random.Range(0f, 100f);
        field.PerlinScale = Random.Range(700f, 900f);
        //int index8 = Random.Range(0, Grass.Count);
        //field.parametricObject.axMat.mat = Grass[index8];

        //changes the landscape to a new random material
        int index9 = Random.Range(0, Landscape.Count);
        land.parametricObject.axMat.mat = Landscape[index9];
    }

    void GenerateBackyard(AXModel mod)
    {
        //changes the backyard content
        float choice = Random.Range(0f, 1f);
        mod.getParameter("Chair_Enabled").initiateRipple_setBoolValueFromGUIChange(false);
        mod.getParameter("Pool_Enabled").initiateRipple_setBoolValueFromGUIChange(false);
        mod.getParameter("Statue_Enabled").initiateRipple_setBoolValueFromGUIChange(false);

        if (choice < .4f)
        {
            //changes the position of the chair
            mod.getParameter("Chair_Enabled").initiateRipple_setBoolValueFromGUIChange(true);
            mod.getParameter("Chair_Trans_X").initiateRipple_setFloatValueFromGUIChange(Random.Range(-8.5f, 9.5f));
            mod.getParameter("Chair_Trans_Z").initiateRipple_setFloatValueFromGUIChange(Random.Range(-3.5f, 2.5f));
            mod.getParameter("Chair_Rot_Y").initiateRipple_setFloatValueFromGUIChange(Random.Range(0f, 360f));
        }

        else if (choice < .65f)
        {
            //changes the scale of the pool
            mod.getParameter("Pool_Enabled").initiateRipple_setBoolValueFromGUIChange(true);
            mod.getParameter("Pool_Scale_X").initiateRipple_setFloatValueFromGUIChange(Random.Range(0.5f, 2.5f));
            mod.getParameter("Pool_Scale_Y").initiateRipple_setFloatValueFromGUIChange(Random.Range(0.1f, 1.5f));
            mod.getParameter("Pool_Scale_Z").initiateRipple_setFloatValueFromGUIChange(Random.Range(0.1f, 1f));

            //changes the pool to a new random material
            int index = Random.Range(0, Pool.Count);
            swimmingPool.parametricObject.axMat.mat = Pool[index];
        }

        else
        {
            //changes the scale/position of the statue
            float scaleX = Random.Range(0.5f, 4.5f);
            float scaleZ = Random.Range(0.5f, 1.5f);
            mod.getParameter("Statue_Enabled").initiateRipple_setBoolValueFromGUIChange(true);
            mod.getParameter("Statue_Scale_X").initiateRipple_setFloatValueFromGUIChange(scaleX);
            mod.getParameter("Statue_Scale_Z").initiateRipple_setFloatValueFromGUIChange(scaleZ);
            mod.getParameter("Statue_Rot_Y").initiateRipple_setFloatValueFromGUIChange(Random.Range(0f, 360f));
            mod.getParameter("Statue_Trans_X").initiateRipple_setFloatValueFromGUIChange(Random.Range(-10f + scaleX, 10f - scaleX));
            mod.getParameter("Statue_Trans_Z").initiateRipple_setFloatValueFromGUIChange(Random.Range(-3f + scaleX, 3f - scaleX));

            //changes the statue to a new random material
            int index1 = Random.Range(0, Statue.Count);
            monument.parametricObject.axMat.mat = Statue[index1];
        }
    }
}



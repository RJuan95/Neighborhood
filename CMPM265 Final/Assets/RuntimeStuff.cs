using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuntimeStuff : MonoBehaviour {

    public bool fixDup;
    public int num;
    GameObject[] models;

    // Use this for initialization
    void Start () {
        fixDup = false;
        num = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (fixDup)
        {
            models = GameObject.FindGameObjectsWithTag("Models");
            if (models.Length > 1)
            {
                for (int i = models.Length - 1; i > models.Length - 1; i--)
                {
                    Destroy(models[i]);
                }
            }
        }
    }
}

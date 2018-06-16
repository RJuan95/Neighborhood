using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //moves the camera with arrow keys & n/m keys
		if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.position += Vector3.right;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.position -= Vector3.right;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            gameObject.transform.position += Vector3.up;
        }
        if (Input.GetKey(KeyCode.DownArrow) && gameObject.transform.position.y > 0f)
        {
            gameObject.transform.position -= Vector3.up;
        }
        if (Input.GetKey(KeyCode.N))
        {
            gameObject.transform.position -= Vector3.forward;
        }
        if (Input.GetKey(KeyCode.M))
        {
            gameObject.transform.position += Vector3.forward;
        }

        //rotates the camera with the mouse
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.Rotate(Vector3.right * -1f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.Rotate(Vector3.right);
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Rotate(Vector3.up * -1f);
        }
        if (Input.GetKey(KeyCode.D) && gameObject.transform.position.y > 0f)
        {
            gameObject.transform.Rotate(Vector3.up);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            gameObject.transform.Rotate(Vector3.forward * -1f);
        }
        if (Input.GetKey(KeyCode.E))
        {
            gameObject.transform.Rotate(Vector3.forward);
        }
    }
}

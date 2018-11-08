using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    float speed = 400f;

    private void OnMouseDrag()
    {
        float rotx = Input.GetAxis("Mouse X") * speed * Mathf.Deg2Rad;
        transform.Rotate(Vector3.up, -rotx);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

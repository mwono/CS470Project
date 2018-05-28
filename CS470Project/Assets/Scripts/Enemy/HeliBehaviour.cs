using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliBehaviour : MonoBehaviour {
    private float x;
    private float yvel;
    private float flightScale;
    private bool ascend;
    private float spawnHeight;

	// Use this for initialization
	void Start () {
        x = 0.0f;
        flightScale = 3.5f;
        spawnHeight = 2.0f;
        ascend = false;
        yvel = Mathf.Cos(x) * flightScale;
	}
	
	// Update is called once per frame
	void Update () {
        x += 0.02f;
        if (x > (Mathf.PI * 2)) x = 0.0f;
        ascend = (x >= (Mathf.PI));
        
        yvel = Mathf.Cos(x) * flightScale;
        transform.position = new Vector3(transform.position.x, yvel + spawnHeight, transform.position.z);

        Quaternion theRotation = transform.localRotation;

        if(ascend && (theRotation.z > -0.1))
        {
            transform.Rotate(Vector3.forward * -1);
        }
        else if ((theRotation.z < 0.1))
        {
            transform.Rotate(Vector3.forward);
        }
	}
}

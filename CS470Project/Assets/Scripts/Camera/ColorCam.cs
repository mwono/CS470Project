using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCam : MonoBehaviour {
    Camera cCam;

	// Use this for initialization
	void Start () {
        cCam = this.GetComponent<Camera>();
        
        cCam.rect = new Rect(0, 0f, .5f, 1);
    }
	
	// Update is called once per frame
	void Update () {
        
    }
}

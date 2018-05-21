using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonocrhomeCam : MonoBehaviour {
    public Camera cCam;
    Vector2 screenBounds;

    Camera mCam;

	// Use this for initialization
	void Start () {
        mCam = this.GetComponent<Camera>();
        
        mCam.rect = new Rect(.5f, 0, .5f, 1);
    }
	
	// Update is called once per frame
	void Update () {
        screenBounds = cCam.ScreenToWorldPoint(new Vector2(cCam.pixelWidth + cCam.pixelWidth / 2, cCam.pixelHeight));
        this.transform.position = new Vector3(screenBounds.x, cCam.transform.position.y, -20);
    }
}

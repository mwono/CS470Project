using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanupObstacles : MonoBehaviour {

    public BackgroundScroll bgScrollScript;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            bgScrollScript.RemoveObstacle(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }
}

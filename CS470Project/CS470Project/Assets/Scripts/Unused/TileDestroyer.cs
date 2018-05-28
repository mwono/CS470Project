using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDestroyer : MonoBehaviour {

    public GameObject TileDestructionPoint;

	// Use this for initialization
	void Start () {
        TileDestructionPoint = GameObject.Find("TileDestructionPointer");
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < TileDestructionPoint.transform.position.x)
        {
            gameObject.SetActive(false);
        }
	}
}

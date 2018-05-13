using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEMPCharController : MonoBehaviour {
    Rigidbody2D rb;
    //DELETE THIS LATER
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * 2, Input.GetAxis("Vertical") * 2);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEMPCharController : MonoBehaviour {
    //bool canJump = false;

    Rigidbody rb;
    //Collider coll;
    //DELETE THIS LATER
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        //coll = GetComponent<Collider>();
	}

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * 10f, Input.GetAxis("Vertical") * 2.5f);
    }
        /*
        if (canJump && (Input.GetAxis("Vertical") > 0))
        {
            rb.AddForce(new Vector2(rb.velocity.x, 5000));
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = false;
        }
    }*/
}

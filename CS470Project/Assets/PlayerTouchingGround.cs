using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouchingGround : MonoBehaviour {
    public PlayerMovement playerScript;
    public List<GameObject> objectsTouching = new List<GameObject>();
    public AudioSource land;
    
	// Use this for initialization
	void Start () {
        land = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (objectsTouching.Count > 0 && !playerScript.isGrounded())
        {
            playerScript.SetGrounded(true);
            land.Play();
        }
        else if (objectsTouching.Count == 0 && playerScript.isGrounded())
            playerScript.SetGrounded(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        objectsTouching.Add(collision.gameObject);
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        objectsTouching.Remove(collision.gameObject);
    }
}

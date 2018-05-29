using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanupObstacles : MonoBehaviour {

    public BackgroundScroll bgScrollScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            bgScrollScript.RemoveObstacle(collision.gameObject);
            //Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);
        }
    }
}

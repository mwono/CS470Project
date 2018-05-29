using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {
    public BackgroundScroll bgScrollScript;
    public Animator playerAnim;

    float timeToStart = 3f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        timeToStart -= Time.deltaTime;

        if(timeToStart <= 0f)
        {
            bgScrollScript.SetPause(false);
            playerAnim.SetBool("Run", true);
            this.enabled = false;
        }
		
	}

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

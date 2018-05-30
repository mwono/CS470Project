using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerScript : MonoBehaviour {
    public Animator startButton;
    public Animator settingsButton;
    public Animator dialog;
    public Animator creditsBtn;
    public Animator creditsWindow;

    /*
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    */

    public void StartGame()
    {
        SceneManager.LoadScene("SkyJumpingScene");
    }


    public void OpenSettings()
    {
        startButton.SetBool("isHidden", true);
        settingsButton.SetBool("isHidden", true);
        creditsBtn.SetBool("isHidden", true);
        dialog.SetBool("isHidden", false);
    }

    public void CloseSettings()
    {
        startButton.SetBool("isHidden", false);
        settingsButton.SetBool("isHidden", false);
        creditsBtn.SetBool("isHidden", false);
        dialog.SetBool("isHidden", true);
    }

    public void OpenCredits()
    {
        startButton.SetBool("isHidden", true);
        settingsButton.SetBool("isHidden", true);
        creditsBtn.SetBool("isHidden", true);
        creditsWindow.SetBool("isHidden", false);
    }

    public void CloseCredits()
    {
        startButton.SetBool("isHidden", false);
        settingsButton.SetBool("isHidden", false);
        creditsBtn.SetBool("isHidden", false);
        creditsWindow.SetBool("isHidden", true);
    }

}

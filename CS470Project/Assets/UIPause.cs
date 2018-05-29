using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIPause : MonoBehaviour
{
    public Transform canvas;
    public Animator pauseMenu;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.StartPlayback();
            if (canvas.gameObject.activeInHierarchy == false)
            {
                canvas.gameObject.SetActive(true);
                Time.timeScale = 0;
                
                //pauseMenu.StartPlayback();

                Time.timeScale = 0;
            }
            else        //else, pause menu is already active
            {
                Time.timeScale = 1;
                canvas.gameObject.SetActive(false);

            }
        }

    }


    public void ResumeGame()
    {
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}

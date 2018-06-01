using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    public Text score;
    public GameObject GameOver;
    
    int sc;
    float timeToStart = 3f;

    // Update is called once per frame
    void Update () {
        timeToStart -= Time.deltaTime;
    
        if (timeToStart <= 0f && !GameOver.activeInHierarchy)
        {
            sc = int.Parse(score.text);
            sc++;
        }
        score.text = sc.ToString();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle")
        {
            sc = int.Parse(score.text);
            sc += 1000;
            score.text = sc.ToString();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {
    public GameObject[] commonObstaclePrefabs;
    public BackgroundScroll bgScrollScript;

    float timeToSpawn = 3f;
    float curTime = 0;
    Vector3 spawnPos = new Vector3(13f, -2, 0f);
    bool paused = false;
    // Use this for initialization

    void Start () {
        GameEvents.Event_PlayerDie += GameEvents_Event_PlayerDie;
	}

    private void GameEvents_Event_PlayerDie()
    {
        paused = true;
    }

    // Update is called once per frame
    void Update () {

        if (paused) return;

        curTime += Time.deltaTime;

        if(curTime >= timeToSpawn)
        {
            int randIndex = Random.Range(0, commonObstaclePrefabs.Length);
            GameObject obstacle = Instantiate(commonObstaclePrefabs[randIndex], spawnPos,Quaternion.identity);
            if(obstacle.name != "Obstacle2")
                bgScrollScript.AddNewObstacle(obstacle);
            curTime = 0f;
        }


		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour {

    // list of objects that will scroll past the player
    List<GameObject> objectsToScroll = new List<GameObject>();

    // list of objects that will scroll past the player and then be respawned
    // and scroll by again infinitely
    List<GameObject> objectsToScrollAndRepeat = new List<GameObject>();

    // prefab to hold main repeating background
    public GameObject[] repeatedBgPrefabs;//For pools: Pooler[]

    // empty gameobject that holds the backgrounds (for organization)
    public Transform scrollingBgHolder;

    // position to spawn first background element
    Vector3 startPos = new Vector3(0, 0, 0);

    // width of background element
    float repeatedBgWidth = 30f;

    float scrollSpeed = 6.5f;

    bool paused = true;

    // **SKYBOX STUFF**
    // //////
    // Does not affect gameplay, just looks

    public GameObject[] repeatedSkyboxPrefabs;//For pools: Pooler[]
    // list of skybox objects to be scrolling and repeated
    List<GameObject> skyboxToScrollAndRepeat = new List<GameObject>();
    // position to spawn first skybox element
    Vector3 startSkyPos = new Vector3(-26, -14.11f, 13.8f);
    // width of background element
    float repeatedSkyboxWidth = 60f;
    float skyScrollSpeed = 3f;

    /// //////////////////
    /// 
    /// End skybox section

    void Start () {
        GameObject bg1 = SpawnRandomBgObject(startPos);
        GameObject bg2 = SpawnRandomBgObject(new Vector3(startPos.x + repeatedBgWidth, startPos.y, startPos.z));
        objectsToScrollAndRepeat.Add(bg1);
        objectsToScrollAndRepeat.Add(bg2);

        // Skybox stuff (does not affect gameplay)
        GameObject skyBg1 = SpawnRandomSkyboxObject(startSkyPos);
        GameObject skyBg2 = SpawnRandomSkyboxObject(new Vector3(startSkyPos.x + repeatedSkyboxWidth, startSkyPos.y, startSkyPos.z));
        skyboxToScrollAndRepeat.Add(skyBg1);
        skyboxToScrollAndRepeat.Add(skyBg2);
        // end skybox section

        GameEvents.Event_PlayerDie += GameEvents_Event_PlayerDie;

    }

    private void GameEvents_Event_PlayerDie()
    {
        paused = true;
    }

    // Update is called once per frame
    void Update () {

        // do not run if paused
        if (paused) return;

        // for repeating objects, scroll them and the repeat them
        // once they go off screen
        for(int i = objectsToScrollAndRepeat.Count-1;i>=0;i--)
        {
            GameObject go = objectsToScrollAndRepeat[i];
            //if(!go.activeInHierarchy)
            if(go == null)
            {
                objectsToScrollAndRepeat.Remove(go);
                continue;
            }
            go.transform.Translate(Vector3.left * Time.deltaTime * scrollSpeed);
            if (go.transform.position.x <= -repeatedBgWidth)
            {
                go.transform.Translate(Vector3.zero);
                //go.gameObject.SetActive(false);
                Destroy(go);
                go = SpawnRandomBgObject(new Vector3(startPos.x + repeatedBgWidth, startPos.y, startPos.z));
                objectsToScrollAndRepeat.Add(go);
            }
        }

        // for non repeating objects just scroll them and remove them once
        // they go off screen
        // (they are removed when they collide with offscreen object named ObstacleDestroyer)
        foreach(GameObject go in objectsToScroll)
        {
            go.transform.Translate(Vector3.left * Time.deltaTime * scrollSpeed);
            go.SetActive(true);
        }





        // skybox scrolling (does not affect gameplay)

        // for repeating objects, scroll them and the repeat them
        // once they go off screen
        float skyScrollFactor = 0.46f;
        skyScrollSpeed = scrollSpeed * skyScrollFactor;
        for (int i = skyboxToScrollAndRepeat.Count - 1; i >= 0; i--)
        {
            GameObject go = skyboxToScrollAndRepeat[i];
            //if(!go.activeInHierarchy)
            if (go == null)
            {
                skyboxToScrollAndRepeat.Remove(go);
                continue;
            }
            go.transform.Translate(Vector3.left * Time.deltaTime * skyScrollSpeed);
            if (go.transform.position.x <= -repeatedSkyboxWidth - 23f)
            {
                go.transform.Translate(Vector3.zero);
                //go.gameObject.SetActive(false);
                Destroy(go);
                go = SpawnRandomSkyboxObject(new Vector3(startSkyPos.x + repeatedSkyboxWidth, startSkyPos.y, startSkyPos.z));
                skyboxToScrollAndRepeat.Add(go);
            }
        }



    }

    public void SetPause(bool f)
    {
        paused = f;
    }

    public bool IsPaused()
    {
        return paused;
    }

    public void AddNewObstacle(GameObject go)
    {
        objectsToScroll.Add(go);
    }
    public void RemoveObstacle(GameObject go)
    {
        objectsToScroll.Remove(go);
    }

    public void SetSpeed(float f)
    {
        scrollSpeed = f;
    }
    public float GetSpeed()
    {
        return scrollSpeed;
    }

    GameObject SpawnRandomBgObject(Vector3 position)
    {
        int randIndex = Random.Range(0, repeatedBgPrefabs.Length);
        //GameObject repeatedBG = repeatedBgPrefabs[randIndex].getPooledTile();
        //repeatedBG.transform.position = position;
        //repeatedBG.SetActive(true);
        //return repeatedBG;
        return Instantiate(repeatedBgPrefabs[randIndex], position, Quaternion.identity, scrollingBgHolder);
    }

    GameObject SpawnRandomSkyboxObject(Vector3 position)
    {
        int randIndex = Random.Range(0, repeatedSkyboxPrefabs.Length);
        //GameObject repeatedBG = repeatedBgPrefabs[randIndex].getPooledTile();
        //repeatedBG.transform.position = position;
        //repeatedBG.SetActive(true);
        //return repeatedBG;
        return Instantiate(repeatedSkyboxPrefabs[randIndex], position, Quaternion.identity, scrollingBgHolder);
    }
}

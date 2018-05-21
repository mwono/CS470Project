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
    public GameObject repeatedBgPrefab;

    // empty gameobject that holds the backgrounds (for organization)
    public Transform scrollingBgHolder;

    // position to spawn first background element
    Vector3 startPos = new Vector3(0, 0, 0);

    // width of background element
    float repeatedBgWidth = 30f;

    float scrollSpeed = 6.5f;

    bool paused = true;

	void Start () {
        GameObject bg1 = Instantiate(repeatedBgPrefab, startPos, Quaternion.identity, scrollingBgHolder);
        GameObject bg2 = Instantiate(repeatedBgPrefab, new Vector3(startPos.x+repeatedBgWidth,startPos.y,startPos.z), Quaternion.identity, scrollingBgHolder);
        objectsToScrollAndRepeat.Add(bg1);
        objectsToScrollAndRepeat.Add(bg2);

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
        foreach(GameObject go in objectsToScrollAndRepeat)
        {
            go.transform.Translate(Vector3.left * Time.deltaTime * scrollSpeed);
            if (go.transform.position.x <= -repeatedBgWidth)
                go.transform.position = new Vector3(startPos.x + repeatedBgWidth, startPos.y, startPos.z);
        }

        // for non repeating objects just scroll them and remove them once
        // they go off screen
        foreach(GameObject go in objectsToScroll)
        {
            go.transform.Translate(Vector3.left * Time.deltaTime * scrollSpeed);
        }


		
	}

    public void SetPause(bool f)
    {
        paused = f;
    }

    public void AddNewObstacle(GameObject go)
    {
        objectsToScroll.Add(go);
    }
    public void RemoveObstacle(GameObject go)
    {
        objectsToScroll.Remove(go);
    }
}

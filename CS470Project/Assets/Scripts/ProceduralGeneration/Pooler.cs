using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour {

    public GameObject obj;
    public int pooledAmt;

    List<GameObject> pool;

	// Use this for initialization
	void Start () {
        pool = new List<GameObject>();

        for (int i = 0; i < pooledAmt; i++)
        {
            GameObject temp = (GameObject)Instantiate(obj);
            temp.SetActive(false);
            pool.Add(temp);
        }
	}
	
	public GameObject getPooledTile()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                return pool[i];
            }
        }

        GameObject temp = (GameObject)Instantiate(obj);
        temp.SetActive(false);
        pool.Add(temp);

        return temp;
    }
}

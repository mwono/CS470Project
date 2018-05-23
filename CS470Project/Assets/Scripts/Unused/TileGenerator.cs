using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour {
    public Pooler[] tilePools;
    public Transform genPoint;
    public int minDist;
    public int maxDist;

    float[] tileWidths;
    int tilePtr;

	// Use this for initialization
	void Start () {
        tileWidths = new float[tilePools.Length];

        for (int i = 0; i < tilePools.Length; i++)
        {
            tileWidths[i] = tilePools[i].obj.GetComponent<BoxCollider>().size.x;
        }
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < genPoint.position.x)
        {
            int randDist = Random.Range(minDist, maxDist);
            tilePtr = Random.Range(0, tilePools.Length);

            transform.position = new Vector3(transform.position.x + tileWidths[tilePtr] + randDist,
                transform.position.y, transform.position.z);

            GameObject newTile = tilePools[tilePtr].getPooledTile();

            newTile.transform.position = transform.position;
            newTile.transform.rotation = transform.rotation;
            newTile.SetActive(true);
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    public List<GameObject> listOfPlatforms;
    public int numberOfPlatform = 200;
    public float levelWidth = 3;
    public float minY = .2f;
    public float maxY = 1.5f;
    private PlatformSelector platformSelector = new PlatformSelector();

	// Use this for initialization
	void Start () {
        Vector3 spawnPosition = new Vector3();

        for (int i = 0; i < numberOfPlatform; i++)
        {
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x += Random.Range(-levelWidth, levelWidth);
            spawnPosition.z = 10;
            Instantiate(platformSelector.getPlatform(listOfPlatforms), spawnPosition, Quaternion.identity);
        }
	}
}

public class PlatformSelector {
    public GameObject getPlatform(List<GameObject> listOfPlatforms) {
        return listOfPlatforms[0];
    }
}

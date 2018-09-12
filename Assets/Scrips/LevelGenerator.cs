using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    public List<GameObject> listOfPlatforms;
    public List<float> listOfProbabilities;
    private List<PlatformWithProbability> platformWithProbabilities;

    public GameObject camera;
    private float minX = 0;
    private float maxX = 0;
    private float maxPoint = 0;

	void Start () {
        minX = camera.transform.position.x - 3.3f;
        maxX = camera.transform.position.x + 3.3f;

        platformWithProbabilities = new List<PlatformWithProbability>();
        platformWithProbabilities.Add(new PlatformWithProbability(listOfPlatforms[0], 70));
        platformWithProbabilities.Add(new PlatformWithProbability(listOfPlatforms[1], 15));
        platformWithProbabilities.Add(new PlatformWithProbability(listOfPlatforms[2], 15));
    }

    private void Update(){
        GeneratePlatforms();
    }

    private void GeneratePlatforms(){
        float cameraPositionY = camera.transform.position.y;

        if (cameraPositionY >= maxPoint){
            for (float i = cameraPositionY; i <= (maxPoint + 50); i++)
            {
                GeneratePlatformsPerBlock(i);
            }
            maxPoint += 50;
        }
        
    }

    private void GeneratePlatformsPerBlock(float positionY){
        float newPositionX = Random.Range(minX, maxX);
        Vector3 platformPosition = new Vector3(newPositionX, positionY, 10);
        Instantiate(GetPlatform(), platformPosition, Quaternion.identity);
    }

    private GameObject GetPlatform()
    {
        float random = Random.Range(0, 100);
        float lastValue = 0;
        GameObject platformSelected = null;

        foreach(PlatformWithProbability p in platformWithProbabilities){
            lastValue += p.getProbability();
            if (random <= lastValue){
                platformSelected = p.getPlatform();
                break;
            }
        }

        return platformSelected; 
    }


}

public class PlatformWithProbability {
    private GameObject platform;
    private float probability;

    public PlatformWithProbability(GameObject newPlatform, float newProbability){
        platform = newPlatform;
        probability = newProbability;
    }

    public void setProbability(float newProbability){
        probability = newProbability;
    }

    public float getProbability(){
        return probability;
    }

    public GameObject getPlatform(){
        return platform;
    }
}

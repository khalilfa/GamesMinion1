using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRules : MonoBehaviour {

    public TextMeshProUGUI scoreCount;
    public string loseScene;
    private GameObject player;
    private GameObject camera;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        camera = GameObject.Find("MainCamera");
	}

    // Update is called once per frame
    void Update () {
        PlayerLose();
        CountScore();
	}

    void CountScore()
    {
        float cameraPositionY = camera.transform.position.y;
        int score = (int)cameraPositionY;
        scoreCount.SetText(score.ToString());
    }

    void PlayerLose()
    {
        if (player != null)
        {
            Vector3 playerPos = player.transform.position;
            Vector3 cameraPos = camera.transform.position;

            if (playerPos.y < cameraPos.y - 6.5)
            {
                DestroyImmediate(player);
                SceneManager.LoadScene(loseScene);
            }
        }
    }
}

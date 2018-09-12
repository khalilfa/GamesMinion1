using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour {

	public void ChangeScene(string nameScene) {
        print("Change scene to: " + nameScene);
        SceneManager.LoadScene(nameScene);
    }

    public void Exit()
    {
        print("Exit");
        Application.Quit();
    }
}

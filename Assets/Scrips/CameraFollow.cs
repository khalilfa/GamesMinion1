using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Transform target;

	// Use this for initialization
	void Start () {
        GameObject player = GameObject.Find("Player");
        target = player.transform;
	}

    private void LateUpdate()
    {
        if (target != null)
        {
            if (target.position.y > transform.position.y)
            {
                Vector3 newPos = new Vector3(transform.position.x, target.position.y, transform.position.z);
                transform.position = newPos;
            }
        }
        
    }
}

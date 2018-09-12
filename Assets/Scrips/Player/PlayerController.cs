using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {
    public GameObject camera;
    public float movementSpeed = 10;
    private Rigidbody2D rb;
    private float movement = 0;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        camera = GameObject.Find("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
        movement = Input.GetAxis("Horizontal") * movementSpeed;
	}

    private void FixedUpdate()
    {
        PlayerMovement();
        WallChanging();
    }

    private void PlayerMovement()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;
    }

    private void WallChanging()
    {
        float playerPositionX = transform.position.x;
        float cameraPositionX = camera.transform.position.x;
        if( playerPositionX > (cameraPositionX + 4.5) ){
            Vector3 newPlayerPositionX = new Vector3(cameraPositionX - 4.5f, transform.position.y, transform.position.z);
            transform.SetPositionAndRotation(newPlayerPositionX, Quaternion.identity);
        }
        if (playerPositionX < (cameraPositionX - 4.5))
        {
            Vector3 newPlayerPositionX = new Vector3(cameraPositionX + 4.5f, transform.position.y, transform.position.z);
            transform.SetPositionAndRotation(newPlayerPositionX, Quaternion.identity);
        }
    }
}

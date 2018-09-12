using UnityEngine;

public class PlatformController : MonoBehaviour {

    public float jumpForce = 10;
    private GameObject mainCamera;

    private void Start()
    {
        mainCamera = GameObject.Find("MainCamera");
    }

    private void Update()
    {
        DestroyPlatform();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        JumpPlayer(collision);
    }

    private void JumpPlayer(Collider2D collider)
    {
        Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
        if (rb.velocity.y <= 0)
        {
            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
            }
        }
    }

    private void DestroyPlatform()
    {
        float cameraPositionY = mainCamera.transform.position.y - 6.5f;

        if (transform.position.y <= cameraPositionY)
        {
            DestroyImmediate(this.gameObject);
        }
    }
}

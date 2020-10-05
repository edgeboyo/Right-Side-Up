using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Composition")]
    public Rigidbody2D rb;

    [Header("Gameplay Values")]
    public float horizontalAcceleration;
    public float maxHorizontalVelocity;
    public float stopModifier;
    //public float jumpForce;

    //[Header("Other Values")]
    //public float sceneBorder;


    private bool _touching;
    private bool _stop;


    void Start()
    {
        
    }

    void Update()
    {
        // Jumping
        /*
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
        */
    }

    private void FixedUpdate()
    {
        Camera cam = Camera.main;
        var vertExtent = cam.orthographicSize;
        var horzExtent = vertExtent * Screen.width / Screen.height;

        // Change sides if off screen from right
        if (transform.position.x > cam.transform.position.x + horzExtent)
            transform.position = new Vector2(transform.position.x - 2*horzExtent, transform.position.y);

        // Change sides if off screen from left
        if (transform.position.x < cam.transform.position.x - horzExtent)
            transform.position = new Vector2(transform.position.x + 2 * horzExtent, transform.position.y);

        // Accelerate horizontally
        if (_touching && SceneControl.Instance.IsSceneActive() && !_stop)
            rb.AddForce(Vector2.right * horizontalAcceleration * Time.fixedDeltaTime);

        // stop if stopping
        if (_stop)
            rb.velocity = rb.velocity * stopModifier;

        // Drop to max velocity
        rb.velocity = new Vector2(Mathf.Min(rb.velocity.x, maxHorizontalVelocity), rb.velocity.y);
    }


    public void Stop()
    {
        _stop = true;
    }


    public void OnCollisionStay2D(Collision2D collision)
    {
        GameObject col = collision.gameObject;

        if (col.CompareTag("Terrain"))
        {
            _touching = true;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        GameObject col = collision.gameObject;

        if (col.CompareTag("Terrain"))
        {
            _touching = false;
        }

    }

}

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
    public float jumpForce;

    [Header("Other Values")]
    public float sceneBorder;


    private bool _touching;


    void Start()
    {
        
    }

    void Update()
    {
        // Jumping
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
    }

    private void FixedUpdate()
    {

        // Change sides if off screen
        if (transform.position.x > sceneBorder || transform.position.x < -sceneBorder)
            transform.position = new Vector2(-transform.position.x, transform.position.y);

        // Accelerate horizontally
        if(_touching)
            rb.AddForce(Vector2.right * horizontalAcceleration * Time.fixedDeltaTime);

        // Drop to max velocity
        rb.velocity = new Vector2(Mathf.Min(rb.velocity.x, maxHorizontalVelocity), rb.velocity.y);
        Debug.Log(rb.velocity.magnitude);
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        _touching = true;
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        _touching = false;
    }

}

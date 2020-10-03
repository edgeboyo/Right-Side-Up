using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Composition")]
    public Rigidbody2D rb;

    [Header("Gameplay Values")]
    public float horizontalAcceleration;
    public float maxVelocity;

    [Header("Other Values")]
    public float sceneBorder;
    


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        // Change sides if off screen
        if (transform.position.x > sceneBorder || transform.position.x < -sceneBorder)
            transform.position = new Vector2(-transform.position.x, transform.position.y);

        // Accelerate horizontally
        rb.AddForce(Vector2.right * horizontalAcceleration * Time.fixedDeltaTime);

        // Drop to max velocity
        rb.velocity = rb.velocity.normalized * Mathf.Min(rb.velocity.magnitude, maxVelocity);
        Debug.Log(rb.velocity.magnitude);
    }

}

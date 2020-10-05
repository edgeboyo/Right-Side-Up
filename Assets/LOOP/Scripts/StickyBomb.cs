using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyBomb : MonoBehaviour
{
    public Rigidbody2D rb;


    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject col = collision.gameObject;

        if (col.CompareTag("Terrain"))
        {
            rb.isKinematic = true;
            rb.velocity = Vector2.zero;
            rb.freezeRotation = true;
        }
    }
}

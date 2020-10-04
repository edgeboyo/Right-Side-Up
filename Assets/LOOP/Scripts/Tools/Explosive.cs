using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour
{
    public Rigidbody2D rb;
    public Tool tool;

    public float explosionForce;
    public float explosionRange;
    public float upwardsMod;

    public List<string> triggers;

    public GameObject explosionPrefab;


    public void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject col = collision.gameObject;

        // Check for trigger
        bool triggered = false;
        foreach(string trigger in triggers)
        {
            if (col.CompareTag(trigger))
            {
                triggered = true;
            }
        }

        // Explode on collision
        if (triggered)
        {
            PhysicsManager.Instance.CreateExplosion(rb.position, explosionForce, explosionRange, upwardsMod);
            Instantiate(explosionPrefab, rb.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
    }

}

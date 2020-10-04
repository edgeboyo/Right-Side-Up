using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public Rigidbody2D rb;
    public Tool tool;

    public float explosionForce;
    public float explosionRange;
    public float upwardsMod;


    public void OnCollisionEnter2D(Collision2D collision)
    {
        // Explode on collision

        PhysicsManager.Instance.CreateExplosion(rb.position, explosionForce, explosionRange, upwardsMod);

        Destroy(gameObject);
    }

}

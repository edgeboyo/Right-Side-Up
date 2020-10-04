using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public Rigidbody2D rb;

    public float explosionForce;
    public float explosionRange;
    public float upwardsMod;


    public void OnCollisionEnter2D(Collision2D collision)
    {
        // Explode

        var targets = PhysicsManager.Instance.GetRigidbodiesInRange(rb.position, explosionRange);

        foreach(Rigidbody2D r in targets)
        {
            if (!r.gameObject.Equals(gameObject))
            {
                r.AddExplosionForce(explosionForce, rb.position, explosionRange, upwardsMod);
            }
        }

        Destroy(gameObject);
    }

}

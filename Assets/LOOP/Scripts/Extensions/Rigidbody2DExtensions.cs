using UnityEngine;

public static class Rigidbody2DExtentions
{

    public static void AddExplosionForce(this Rigidbody2D rb, float force, Vector2 position, float range, float upwardsModifier = 0.0F)
    {
        Vector2 explosionVect = rb.position - position;
        Vector2 explosionDir = explosionVect.normalized;

        float dist = Mathf.Max(1f, explosionVect.magnitude);        // effective distance cannot be less than 1f - too much force applied
        float explosionMod = 1 - dist / range;

        explosionDir.y += upwardsModifier;
        explosionDir.Normalize();


        float noTorqueMod = 0.9f;   // only a part of the force is applied at position (with torque)
        float torqueMod = 0.1f;

        rb.AddForce(Mathf.Lerp(0, force, explosionMod) * explosionDir * noTorqueMod);                       // no torque applied
        rb.AddForceAtPosition(Mathf.Lerp(0, force, explosionMod) * explosionDir * torqueMod, position);     // torque applied
    }
}
using UnityEngine;

public static class Rigidbody2DExtentions
{

    public static void AddExplosionForce(this Rigidbody2D rb, float force, Vector2 position, float range, float upwardsModifier = 0.0F)
    {
        Vector2 explosionVect = rb.position - position;
        Vector2 explosionDir = explosionVect.normalized;

        float explosionMod = 1 - explosionVect.magnitude / range;

        explosionDir.y += upwardsModifier;
        explosionDir.Normalize();

        rb.AddForce(Mathf.Lerp(0, force, explosionMod) * explosionDir);
    }
}
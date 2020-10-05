using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    public SpriteRenderer sr;
    public Rigidbody2D rb;
    public Collider2D coll;

    public float holdingForce;
    public float holdingTorqueApplied;
    public float throwForce;

    public float heldDrag;
    public float thrownDrag;

    public AudioClip throwSound;

    public EventHandler Thrown;


    private const float destroyHeight = -10f;

    private bool _used;
    private Vector2 _prevVel;


    private void Awake()
    {
        coll.enabled = false;

        rb.drag = heldDrag;
    }





    private void FixedUpdate()
    {
        if (!_used)
        {
            float velDiff = (rb.velocity - _prevVel).magnitude;

            rb.AddForce((ThrowManager.Instance.GetWorldMousePos() - (Vector2)transform.position) * holdingForce);

            rb.AddTorque(Vector2.SignedAngle(rb.velocity, _prevVel) * velDiff * holdingTorqueApplied);

            _prevVel = rb.velocity;
        }

        if(rb.position.y < destroyHeight)
        {
            Destroy(gameObject);
        }
    }


    public void Throw()
    {
        _used = true;

        //transform.parent = PhysicsManager.Instance.GetParent();

        coll.enabled = true;

        rb.drag = thrownDrag;

        AudioSource.PlayClipAtPoint(throwSound, Vector2.zero);

        OnThrown();
    }

    public void OnThrown()
    {
        Thrown?.Invoke(this, new EventArgs());
    }
}

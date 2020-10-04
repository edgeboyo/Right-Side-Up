using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    public Rigidbody2D rb;
    public Collider2D coll;

    public float holdingForce;
    public float throwForce;

    public float heldDrag;
    public float thrownDrag;

    public EventHandler Thrown;

    private bool _used;




    void Start()
    {
        coll.enabled = false;

        rb.drag = heldDrag;
    }


    void Update()
    {
        if (!_used)
        {
            rb.AddForce((ThrowManager.Instance.GetWorldMousePos() - (Vector2)transform.position) * holdingForce);
        }
    }

    public void Throw()
    {
        _used = true;

        transform.parent = PhysicsManager.Instance.GetParent();

        coll.enabled = true;

        rb.drag = thrownDrag;

        //rb.AddForce(ThrowManager.Instance.GetThrowForce() * throwForce);

        OnThrown();
    }

    public void OnThrown()
    {
        Thrown?.Invoke(this, new EventArgs());
    }
}

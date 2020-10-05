using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public Transform stick;
    public bool startingOn;

    public float turnAngle;

    public EventHandler LeverOff;
    public EventHandler LeverOn;

    private bool _on;



    void Start()
    {
        _on = startingOn;
    }


    void Update()
    {
        float stickAngle = stick.localRotation.eulerAngles.z;
        if (stickAngle > 180) stickAngle = stickAngle - 360;

        if(!_on && stickAngle > turnAngle)
        {
            // Turn on

            _on = true;
            LeverOn?.Invoke(this, new EventArgs());
            //Debug.Log("Lever ON");
        }

        else if(_on && stickAngle < -turnAngle)
        {
            // Turn off

            _on = false;
            LeverOff?.Invoke(this, new EventArgs());
            //Debug.Log("Lever OFF");
        }

    }
}

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

        float startAngle;
        if (startingOn)
        {
            _on = true;
            startAngle = turnAngle;
        }
        else
        {
            _on = false;
            startAngle = -turnAngle;
        }
        stick.rotation = Quaternion.Euler(new Vector3(0, 0, startAngle));
    }


    void Update()
    {
        float stickAngle = stick.rotation.eulerAngles.z;

        if(!_on && stickAngle > turnAngle)
        {
            // Turn on

            _on = true;
            LeverOn?.Invoke(this, new EventArgs());
        }

        else if(_on && stickAngle < -turnAngle)
        {
            // Turn off

            _on = false;
            LeverOff?.Invoke(this, new EventArgs());
        }
    }
}

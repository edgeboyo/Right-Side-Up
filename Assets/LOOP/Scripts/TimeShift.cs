using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeShift : MonoBehaviour
{

    enum State {idle, running, cooldown};
    State current = State.idle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (current)
        {
            case (State.idle):
                if (Input.GetKeyDown(KeyCode.F))
                    SlowMo();
                break;
            case (State.running):
                if (Input.GetKeyDown(KeyCode.F))
                    NoMoSlowMo();
                break;
            default:
                break;
                

        }
    }

    void SlowMo()
    {
        current = State.running;
        Time.timeScale = 0.5f;
    }

    void NoMoSlowMo()
    {
        current = State.idle;
        Time.timeScale = 1.0f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeShift : MonoBehaviour
{
    public float coolDownTime = 5;
    float coolDown = 0;

    public float abilityTime = 1;
    float remaining = 0;

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
                remaining -= Time.deltaTime;
                if (remaining <= 0)
                    NoMoSlowMo();
                break;
            case (State.cooldown):
                coolDown -= Time.deltaTime;
                if (coolDown <= 0)
                    current = State.idle;
                break;
            default:
                break;
                

        }
    }

    void SlowMo()
    {
        current = State.running;
        remaining = abilityTime;
        Time.timeScale = 0.5f;
    }

    void NoMoSlowMo()
    {
        current = State.cooldown;
        coolDown = coolDownTime;
        Time.timeScale = 1.0f;
    }
}

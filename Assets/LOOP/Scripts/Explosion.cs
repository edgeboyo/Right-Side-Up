using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    public float lifeTime;

    private float _timer;

    void Start()
    {
        _timer = 0;
    }

    void Update()
    {
        _timer += Time.deltaTime;

        if(_timer > lifeTime)
        {
            Destroy(gameObject);
        }
    }
}

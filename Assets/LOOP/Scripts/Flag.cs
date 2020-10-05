using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{

    private bool _end;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject col = collision.gameObject;

        if (!_end && col.CompareTag("Player"))
        {
            // Player reached the flag

            _end = true;
            SceneControl.Instance.Exit();
            var p = col.GetComponent<Player>();
            p.Stop();
        }
    }


}

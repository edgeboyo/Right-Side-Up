using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour
{
    public Tool tool;

    public Sprite activatedSprite;

    public float explosionForce;
    public float explosionRange;
    public float upwardsMod;

    public List<string> activationTriggers;
    public List<string> explosionTriggers;

    public GameObject explosionPrefab;


    private bool _active;


    private void Start()
    {
        _active = false;

        // Activate if no activation triggers
        if(activationTriggers.Count == 0)
        {
            Activate();
        }
    }


    private void Activate()
    {
        _active = true;
        tool.sr.sprite = activatedSprite;
    }

    private void Explode()
    {
        PhysicsManager.Instance.CreateExplosion(tool.rb.position, explosionForce, explosionRange, upwardsMod);
        Instantiate(explosionPrefab, tool.rb.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject col = collision.gameObject;

        // Check for activation trigger
        foreach (string trigger in activationTriggers)
        {
            if (col.CompareTag(trigger))
            {
                Activate();
            }
        }

        // Check for explosion trigger
        if (_active)
        {
            foreach (string trigger in explosionTriggers)
            {
                if (col.CompareTag(trigger))
                {
                    Explode();
                }
            }
        }
        
        
    }

}

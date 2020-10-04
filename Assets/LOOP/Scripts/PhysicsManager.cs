using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsManager : MonoBehaviour
{

    public Transform parent;


    public static PhysicsManager Instance { get; private set; } 


    private List<Rigidbody2D> rigidbodies;


    private void Awake()
    {
        Instance = this;

        rigidbodies = new List<Rigidbody2D>();
    }

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void Refresh()
    {
        parent.GetComponentsInChildren(rigidbodies);
    }


    public Transform GetParent()
    {
        return parent;
    }

    public List<Rigidbody2D> GetRigidbodies()
    {
        Refresh();
        var r = new List<Rigidbody2D>(rigidbodies);
        return r;
    }

    public List<Rigidbody2D> GetRigidbodiesInRange(Vector2 pos, float range)
    {
        Refresh();
        var r = rigidbodies
            .FindAll(a => ((Vector2)a.transform.position - pos).magnitude < range);
        return r;
    }
}

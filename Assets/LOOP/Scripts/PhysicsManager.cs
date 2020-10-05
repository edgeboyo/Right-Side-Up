using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("Tool"))
        {
            if(go.GetComponent<Rigidbody2D>() != null)
            {
                rigidbodies.Add(go.GetComponent<Rigidbody2D>());
            }
        }
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

    public void CreateExplosion(Vector2 pos, float force, float range, float upwards)
    {
        var targets = GetRigidbodiesInRange(pos, range);

        foreach (Rigidbody2D r in targets)
        {
            Debug.Log(r);
            
            if (!r.gameObject.Equals(gameObject))
            {
                if (r.gameObject.GetComponent<Explosive>() != null)
                {
                    Debug.Log("Shit should work!");
                    Explosive explode = r.gameObject.GetComponent<Explosive>();
                    if(!explode.isDone() && explode.isActive())
                        explode.Explode();
                }
                else
                    r.AddExplosionForce(force, pos, range, upwards);
            }
        }
    }
}

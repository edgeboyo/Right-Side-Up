using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowManager : MonoBehaviour
{

    public Transform throwMarker;
    
    public float mouseMovementDynamic;
    public float mouseMovementBraking;
    //public float maxMouseMovement;

    public static ThrowManager Instance;

    private Vector2 _mouseMovement;
    private Vector2 _prevMouseMovement;
    private Vector2 _prevMousePos;



    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        _prevMousePos = GetMousePos();
        _prevMouseMovement = Vector2.zero;
    }

    
    void FixedUpdate()
    {
        // Calculate mouse movement

        Vector2 newMouseMovement = GetMousePos() - _prevMousePos;
        _mouseMovement = Vector2.Lerp(_prevMouseMovement + newMouseMovement * mouseMovementDynamic, Vector2.zero, mouseMovementBraking * Time.fixedDeltaTime);
        //_mouseMovement = _mouseMovement.normalized * Mathf.Min(_mouseMovement.magnitude, maxMouseMovement);

        throwMarker.position = GetWorldMousePos();
        throwMarker.rotation = Quaternion.LookRotation(Vector3.forward, _mouseMovement.normalized);
        throwMarker.localScale = new Vector2(throwMarker.localScale.x, _mouseMovement.magnitude / 50);


        _prevMouseMovement = _mouseMovement;
        _prevMousePos = GetMousePos();
    }



    public Vector2 GetMousePos()
    {
        return Input.mousePosition;
    }

    public Vector2 GetWorldMousePos()
    {
        return Camera.main.ScreenToWorldPoint(GetMousePos());
    }

    public Vector2 GetThrowForce()
    {
        return _mouseMovement;
    }
}

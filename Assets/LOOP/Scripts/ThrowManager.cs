using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowManager : MonoBehaviour
{

    public float mouseMovementDynamic;
    public float mouseMovementBraking;
    public float maxThrowForce;

    public static ThrowManager Instance;

    private Vector2 _mouseMovement;



    private void Awake()
    {
        Instance = this;
    }


    public Vector2 GetMousePos()
    {
        return Input.mousePosition;
    }

    public Vector2 GetWorldMousePos()
    {
        return Camera.main.ScreenToWorldPoint(GetMousePos());
    }
}

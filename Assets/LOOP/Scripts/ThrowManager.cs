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
        Vector2 mousePos = Input.mousePosition;

        Vector2 lockedPos = new Vector2(
            Mathf.Clamp(mousePos.x, 0, Camera.main.pixelWidth),
            Mathf.Clamp(mousePos.y, 0, Camera.main.pixelHeight));

        return lockedPos;
    }

    public Vector2 GetWorldMousePos()
    {
        return Camera.main.ScreenToWorldPoint(GetMousePos());
    }
}

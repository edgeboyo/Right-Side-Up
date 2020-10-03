using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    [Header("References")]
    public Transform player;

    [Header("Values")]
    public float posYAbovePlayer;
    public float aimSpeed;

    private float _aimPosY;


    void Start()
    {
        
    }


    private void FixedUpdate()
    {
        // get aim height
        _aimPosY = player.transform.position.y + posYAbovePlayer;

        // move to the position
        transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, _aimPosY, aimSpeed * Time.fixedDeltaTime), transform.position.z);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    [Header("References")]
    public Player player;

    [Header("Values")]
    public float posYAbovePlayer;
    public float aimSpeed;
    public float velocityMod;
    public float _bottomY;

    private float _aimPosY;


    void Start()
    {
        
    }


    private void Update()
    {
        // get aim height
        _aimPosY = Mathf.Max(player.transform.position.y + posYAbovePlayer + player.rb.velocity.y * velocityMod, _bottomY);

        // move to the position
        transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, _aimPosY, aimSpeed * Time.deltaTime), transform.position.z);
    }
}

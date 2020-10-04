using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    [Header("References")]
    public GameObject player;

    [Header("Values")]
    public float posYAbovePlayer;
    public float aimSpeed;
    public float velocityMod;
    public float _bottomY;

    private float _aimPosY;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    private void Update()
    {
        float vertExtent = Camera.main.orthographicSize;
        //var horzExtent = vertExtent * Screen.width / Screen.height;

        float py = player.transform.position.y;


        if (py >= (transform.position.y + vertExtent/4))
            transform.position = new Vector3(transform.position.x, transform.position.y + (py - (transform.position.y + vertExtent / 4)), transform.position.z);

        if (py <= (transform.position.y - vertExtent / 4))
            transform.position = new Vector3(transform.position.x, transform.position.y - ((transform.position.y - vertExtent / 4) - py), transform.position.z);
        /**
        // get aim height
        _aimPosY = Mathf.Max(player.transform.position.y + posYAbovePlayer + player.rb.velocity.y * velocityMod, _bottomY);

        // move to the position
        transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, _aimPosY, aimSpeed * Time.deltaTime), transform.position.z);
        **/
    }
}

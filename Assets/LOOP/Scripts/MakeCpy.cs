using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeCpy : MonoBehaviour
{
    public Rigidbody2D rb2;
    public SpriteRenderer sb;

    GameObject player;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        cam = Camera.main;

        sb.sprite = ((SpriteRenderer)player.GetComponent("SpriteRenderer") as SpriteRenderer).sprite;
        this.transform.position = new Vector2(player.transform.position.x, player.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        var vertExtent = cam.orthographicSize;
        var horzExtent = vertExtent * Screen.width / Screen.height;


        float x = player.transform.position.x, y = player.transform.position.y;

        if (player.transform.position.x > cam.transform.position.x)
        {
            x = (player.transform.position.x - cam.transform.position.x) - 2 * horzExtent;
        }
        else
        {
            x = (player.transform.position.x - cam.transform.position.x) + 2 * horzExtent;
        }
        this.transform.position = new Vector2(x, y);
    }
}

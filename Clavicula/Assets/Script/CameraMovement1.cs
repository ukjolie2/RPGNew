using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement1 : MonoBehaviour
{
    public GameObject player;
    private float distanceX;
    private float distanceY;
    private float posY;
    private float posX;
    private bool hitWallX;
    private bool hitWallY;
    void Start()
    {
        //Ignore collisions between the player and the camera box colliders
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        //Gets the current distance between the camera and the player
        //This is to make sure the distance between the camera and the player stays the same
        distanceX = transform.position.x - player.transform.position.x;
        distanceY = transform.position.y - player.transform.position.y;
        //For wall checks and changing the position of the camera
        posY = transform.position.y;
        posX = transform.position.x;
    }
    private void FixedUpdate()
    {
        if (!hitWallX)
        {
            posX = player.transform.position.x + distanceX;
        }
        if (!hitWallY)
        {
            posY = player.transform.position.y + distanceY;
        }
        transform.position = new Vector3(posX, posY, transform.position.z);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "leftWall":
                hitWallX = true;
                break;
            case "rightWall":
                hitWallX = true;
                break;
            case "topWall":
                hitWallY = true;
                break;
            case "bottomWall":
                hitWallY = true;
                break;
            default:
                print("default");
                break;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "leftWall":
                if (player.transform.position.x >= posX)
                {
                    hitWallX = false;
                }
                break;
            case "rightWall":
                if (player.transform.position.x <= posX)
                {
                    hitWallX = false;
                }
                break;
            case "topWall":
                if (player.transform.position.y <= posY)
                {
                    hitWallY = false;
                }
                break;
            case "bottomWall":
                if (player.transform.position.y >= posY)
                {
                    hitWallY = false;
                }
                break;
            default:
                print("default");
                break;
        }
    }
}

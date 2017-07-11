using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    public float walkSpeed = 10;
    private int direction = 0;
    private Rigidbody2D player;
    private AnimationController2D animate;
	// Use this for initialization
	void Start ()
    {
        player = gameObject.GetComponent<Rigidbody2D>();
        animate = gameObject.GetComponent<AnimationController2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Vector2 velocity = player.velocity;
        if(Input.GetAxis("Horizontal") < 0)
        {
            velocity.x = -walkSpeed;
            if (!Input.GetButton("Vertical"))
            {
                animate.setAnimation("WalkLeft");
                direction = 1;
            }
        }
        else if(Input.GetAxis("Horizontal") > 0)
        {
            velocity.x = walkSpeed;
            if (!Input.GetButton("Vertical"))
            {
                animate.setAnimation("WalkRight");
                direction = 3;
            }
        }
        if(Input.GetAxis("Vertical") > 0)
        {
            velocity.y = walkSpeed;
            animate.setAnimation("WalkUp");
            direction = 2;
        }
        else if(Input.GetAxis("Vertical") < 0)
        {
            velocity.y = -walkSpeed;
            animate.setAnimation("WalkDown");
            direction = 0;
        }
        velocity.x *= 0.6f;
        velocity.y *= 0.6f;
        if (velocity.x < 2 && velocity.y < 2 && velocity.x > -2 && velocity.y > -2)
        {
            switch (direction)
            {
                case 0:
                    animate.setAnimation("IdleDown");
                    break;
                case 1:
                    animate.setAnimation("IdleLeft");
                    break;
                case 2:
                    animate.setAnimation("IdleUp");
                    break;
                case 3:
                    animate.setAnimation("IdleRight");
                    break;
            }
        }
        player.velocity = velocity;
	}
    private void OnCollisionEnter2D(Collision2D collision)
    { 
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //print("exit");
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
    }
}

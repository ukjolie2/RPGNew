using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    public float walkSpeed = 3;
    private CharacterController player;
    private AnimationController2D animate;
	// Use this for initialization
	void Start ()
    {
        player = gameObject.GetComponent<CharacterController>();
        animate = gameObject.GetComponent<AnimationController2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 velocity = player.velocity;
        if(Input.GetAxis("Horizontal") < 0)
        {
            velocity.x = -walkSpeed;
            if (!Input.GetButton("Vertical"))
            {
                animate.setAnimation("WalkLeft");
            }
        }
        else if(Input.GetAxis("Horizontal") > 0)
        {
            velocity.x = walkSpeed;
            if (!Input.GetButton("Vertical"))
            {
                animate.setAnimation("WalkRight");
            }
        }
        if(Input.GetAxis("Vertical") > 0)
        {
            velocity.y = walkSpeed;
            animate.setAnimation("WalkUp");
        }
        else if(Input.GetAxis("Vertical") < 0)
        {
            velocity.y = -walkSpeed;
            animate.setAnimation("WalkDown");
        }
        velocity.x *= 0.85f;
        velocity.y *= 0.85f;
        player.Move(velocity * Time.deltaTime);
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {

    } 
}

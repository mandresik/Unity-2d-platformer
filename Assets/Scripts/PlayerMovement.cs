using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private SpriteRenderer sprite;
    private Animator animator;
    private new BoxCollider2D collider;

    private float dirX = 0f;
    private float eps = 0.1f;

    private bool hasDoubleJump;
    private bool isDoubleJumping;

    [SerializeField] private float jumpHeight;
    [SerializeField] private float speed;

    [SerializeField] private LayerMask layerGround;

    private enum Movement { idle, running, jumping, falling, doubleJumping }

    [SerializeField] private AudioSource soundJump;

    // Start is called before the first frame update
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();    
        animator = GetComponent<Animator>();

        hasDoubleJump = true;
        isDoubleJumping = false;
    }

    // Update is called once per frame
    private void Update()
    {
        // handles running of player
        HorizontalMovement();

        // handles jumping of player
        VerticalMovement();

        // update player's animation
        AnimationUpdate();
    }

    // sets velocity in x axis
    private void HorizontalMovement()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rigidBody.velocity = new Vector2(dirX * speed, rigidBody.velocity.y);
    }

    // sets velocity in y axis
    private void VerticalMovement()
    {
        // vertical upward movement 
        // player must use Jump button + one of two following conditions must be met
        // 1) AND is grounded
        // or
        // 2) AND has jumped but not double jumped and is still in jumping movement (not falling movement)
        if (Input.GetButtonDown("Jump") && (IsGrounded() || (hasDoubleJump && rigidBody.velocity.y > eps)))
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpHeight);

            soundJump.Play();

            // whenever grounded, player can double jump after jumping
            // but isDoubleJumping is set to false for the jumping animation
            if (IsGrounded())
            {
                hasDoubleJump = true;
                isDoubleJumping = false;
            }
            
            // player has already jumped and has one more jump ... double jumping  
            if( ! IsGrounded() && hasDoubleJump)
            {           
                hasDoubleJump = false;
                isDoubleJumping = true;
            }
        }
    }

    // updates animation of player
    private void AnimationUpdate()
    {
        Movement movement;

        if (dirX > eps)
        {
            // running to the right
            movement = Movement.running;
            sprite.flipX = false;
        }
        else if (dirX < -eps)
        {
            // running to the left
            movement = Movement.running;
            sprite.flipX = true;
        }
        else
        {
            // idle state
            movement = Movement.idle;
        }

        if(rigidBody.velocity.y > eps)
        {
            // upwards jumping or double jumping movement
            movement = isDoubleJumping ? Movement.doubleJumping : Movement.jumping;
        }
        else if(rigidBody.velocity.y < -eps)
        {
            // falling movement
            movement = Movement.falling;
        }

        animator.SetInteger("movement", (int) movement);
    }

    // returns true if player collides with ground
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, eps, layerGround);
    }
}

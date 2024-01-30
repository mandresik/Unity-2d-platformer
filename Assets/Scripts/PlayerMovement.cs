using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private SpriteRenderer sprite;
    private Animator animator;
    private new BoxCollider2D collider;

    private float dirX = 0f;
    private float eps = 0.1f;

    [SerializeField] private float jumpHeight;
    [SerializeField] private float speed;

    [SerializeField] private LayerMask layerGround;

    private enum Movement { idle, running, jumping, falling }

    // Start is called before the first frame update
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();    
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rigidBody.velocity = new Vector2(dirX * speed, rigidBody.velocity.y);

        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpHeight);
        }

        // update animation
        AnimationUpdate();
    }

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
            // jumping movement
            movement = Movement.jumping;
        }
        else if(rigidBody.velocity.y < -eps)
        {
            // falling movement
            movement = Movement.falling;
        }

        animator.SetInteger("movement", (int) movement);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, eps, layerGround);
    }
}

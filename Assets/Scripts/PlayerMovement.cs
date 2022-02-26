using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rbody;
    private BoxCollider2D coll;
    private Animator anim;

    [SerializeField]private LayerMask jumpableGround;
    private SpriteRenderer sprite;
    private float moveX;
    private float jumpForce = 7f;
    private float moveSpeed = 5f;

    private enum MovementState{idel, jump ,runing, falling}

    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
       
        // It's work on unity input Manager 
        moveX = Input.GetAxisRaw("Horizontal"); //if we don't want to slide so then we use raw
        rbody.velocity = new Vector2(moveX * moveSpeed, rbody.velocity.y);


        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play();
            rbody.velocity = new Vector2(rbody.velocity.x, jumpForce);
           
        }

        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        MovementState state;
        if (moveX > 0f)
        {
            state = MovementState.runing;
            sprite.flipX = false;
        }
        else if (moveX < 0f)
        {
            state = MovementState.runing;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idel;
        }
        if(rbody.velocity.y > .1f)
        {
            state = MovementState.jump;
        }
        else if(rbody.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
       return  Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f,jumpableGround );
    }
}

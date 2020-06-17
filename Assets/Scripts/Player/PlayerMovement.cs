using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public int JumpForce;
    public float speed;
    public bool isGrounded;
    public LayerMask isGroundLayer;
    public Transform groundCheck;
    public float groundCheckRadius;
    public SpriteRenderer marioSprite;

    Animator anim;
    Rigidbody2D myRigidBody;

    private bool isFacingLeft = false;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        if (speed <= 0)
        {
            speed = 5.0f;
        }

        if (JumpForce <= 0)
        {
            JumpForce = 5;
        }

        if (!groundCheck)
        {
            Debug.Log("Groundcheck is not found. Please assign an object to be the groundcheck");
        }

        if (groundCheckRadius <= 0)
        {
            groundCheckRadius = 0.2f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGroundLayer);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            myRigidBody.velocity = Vector2.zero;

            myRigidBody.AddForce(Vector2.up * JumpForce);
        }

        myRigidBody.velocity = new Vector2(horizontalInput * speed, myRigidBody.velocity.y);

        anim.SetFloat("horizontalInput", Mathf.Abs(horizontalInput));
        anim.SetBool("Jump", !isGrounded);

        if (horizontalInput > 0 && isFacingLeft || horizontalInput < 0 && !isFacingLeft)
        {
            isFacingLeft = !isFacingLeft;
            marioSprite.flipX = isFacingLeft;
        }
    }
}

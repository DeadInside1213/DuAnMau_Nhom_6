using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Grab references for rigibody and animator from object
    [SerializeField] private float sp;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D box;
    [SerializeField] private LayerMask groundPlayer;
    [SerializeField] private LayerMask wallPlayer;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * sp, body.velocity.y);

        //Flip player when moving left \ right 
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;

        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        if (Input.GetKey(KeyCode.Space) && isGrounded())
            Jump();

        // set animator parameters
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());

        print(onWall());

    }
    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, sp);
        anim.SetTrigger("jump");
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
    }
   private bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0, Vector2.down, 0.1f, groundPlayer);
        return hit.collider != null;
    }
    private bool onWall()
    {
        RaycastHit2D hit = Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0, new Vector2(transform.localScale.x,0), 0.1f, wallPlayer);
        return hit.collider != null;
    }
}
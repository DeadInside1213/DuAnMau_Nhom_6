using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Grab references for rigibody and animator from object
    [SerializeField] private float sp;
    [SerializeField] private float jumpForce;
    [SerializeField] private GameObject arrow;
    [SerializeField] private Transform hand;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D box;
    [SerializeField] private LayerMask groundPlayer;
    [SerializeField] private LayerMask wallPlayer;

    private AudioSource audi;

    [SerializeField] AudioClip shot;
    [SerializeField] AudioClip dead;
    [SerializeField] AudioSource move;
    [SerializeField] AudioClip jump;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
        audi = GetComponent<AudioSource>();
    }
    private void Update()
    {

       
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * sp, body.velocity.y);

        //Flip player when moving left \ right 
        if (horizontalInput > 0.01f)
        {
            move.Play();
            transform.localScale = Vector3.one;
        }
            

        else if (horizontalInput < -0.01f)
        {
            move.Play();
            transform.localScale = new Vector3(-1, 1, 1);
        }
            
        if (horizontalInput == 0) move.Stop();

        if (Input.GetKey(KeyCode.Space) && isGrounded())
            Jump();

        // set animator parameters
        anim.SetFloat("run", Mathf.Abs(horizontalInput));
        anim.SetBool("grounded", isGrounded());

        if (Input.GetKeyDown(KeyCode.F))
        {
            
            var bullet = Instantiate(arrow , hand.position, Quaternion.identity);

            var velocity = new Vector3(50f, 0, 0);

            if (transform.localScale.x <0)
            {
                velocity.x *= -1;
            }

            audi.PlayOneShot(shot);
            bullet.GetComponent<Rigidbody2D>().velocity = velocity;
            Destroy(bullet, 2f);
            anim.SetTrigger("shoot");
        }

        print(onWall());

    }
    private void Jump()
    {
        audi.PlayOneShot(jump);
        body.velocity = new Vector2(body.velocity.x, jumpForce);
        anim.SetTrigger("jump");
       
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
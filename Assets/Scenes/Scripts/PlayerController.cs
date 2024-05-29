using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [Header("References")]
    private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private int healthPoints = 100;
    [SerializeField] private float jumpForce = 2f;
    // Update is called once per frame
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        
    }
    void Update()
    {
        Move();
    }
    private void Move()
    {
        var move = Input.GetAxisRaw("HorizontalInput");
        
    }
}

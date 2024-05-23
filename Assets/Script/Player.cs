using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _playerSpeed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Vector2 _pleyerDirectionY;
    [SerializeField] private Vector2 _pleyerDirectionX;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical");
        _pleyerDirectionY = new Vector2(0, directionY).normalized;

        float directionX = Input.GetAxisRaw("Horizontal");
        _pleyerDirectionX = new Vector2(directionX, 0).normalized;
    }

    void FixedUpdate()
    {
        Vector2 velocity = new Vector2(_pleyerDirectionX.x * _playerSpeed, _pleyerDirectionY.y * _playerSpeed);
        rb.velocity = velocity;
    }

}

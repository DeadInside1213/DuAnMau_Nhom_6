using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1f;
    [SerializeField]
    private float _rightBound;
    [SerializeField]
    private float _leftBound;

    private bool _isMovingRight;
    private AudioSource _audioSource;

    [SerializeField] AudioClip _deadSound;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        var currentPosision = transform.localPosition;

        if (currentPosision.x > _rightBound)
        {
            _isMovingRight = false;
        }
        else if (currentPosision.x < _leftBound)
        {
            _isMovingRight = true;
        }



        // move by direction
        var direction = Vector3.right;
        if (_isMovingRight == false)
        {
            direction = Vector3.left;
        }

        direction = direction * moveSpeed * Time.deltaTime;
        transform.Translate(direction);

        transform.localScale = _isMovingRight ?
         new Vector3(-1, 1, 0) : new Vector3(1, 1, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Arrow"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}

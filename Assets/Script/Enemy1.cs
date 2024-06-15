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

    UIManager _uiManager;

    [SerializeField] AudioClip _deadSound;
    // Start is called before the first frame update
    void Start()
    {

        _uiManager = FindAnyObjectByType<UIManager>();

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
         new Vector3(1, 1, 0) : new Vector3(-1, 1, 0);
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _uiManager.HPUpdate();
        }

        if (collision.gameObject.CompareTag("Arrow"))
        {
            _uiManager.ScoreUpdate(1000);

            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{

    [SerializeField] GameObject _max;
    [SerializeField] GameObject _min;
    [SerializeField] float _speed;
    [SerializeField] bool _isMovingUp;


    // Update is called once per frame
    void Update()
    {
        var currentPosision = transform.localPosition;

        if (currentPosision.y > _max.transform.position.y)
        {
            _isMovingUp = false;
        }
        else if (currentPosision.y < _min.transform.position.y)
        {
            _isMovingUp = true;
        }


        var direction = Vector3.up;
        if (_isMovingUp == false)
        {
            direction = Vector3.down;
        }

        direction = direction * _speed * Time.deltaTime;
        transform.Translate(direction);
    }


}

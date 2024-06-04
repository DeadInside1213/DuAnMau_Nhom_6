using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

    [SerializeField] GameObject _key;
    // Update is called once per frame
    void Update()
    {
        if (_key == null)
        {
            Destroy(gameObject);
        }
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{

    string[] itemTag = { "Item", "Coin" };
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            SendMessage("UpdateScore", 1000);
            Destroy(collision.gameObject);

        }
        if (collision.tag == "Key")
        {
            Destroy(collision.gameObject);
        }
    }
}

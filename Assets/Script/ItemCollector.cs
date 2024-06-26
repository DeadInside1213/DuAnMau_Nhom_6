using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{

    string[] itemTag = { "Item", "Coin" };
    [SerializeField] AudioClip collect;
    AudioSource audi;


    UIManager _uiManager;

    // Start is called before the first frame update
    void Start()
    {
        _uiManager = FindAnyObjectByType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            _uiManager.ScoreUpdate(1000);
            Destroy(collision.gameObject);

            audi = GetComponent<AudioSource>();
            audi.PlayOneShot(collect);
        }
        if (collision.tag == "Key")
        {
            Destroy(collision.gameObject);
            audi = GetComponent<AudioSource>();
            audi.PlayOneShot(collect);
        }
    }
}

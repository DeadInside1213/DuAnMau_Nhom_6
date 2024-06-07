using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public GameObject gameOverObject;
    [SerializeField] GameObject player;
    [SerializeField] GameObject respawn;

    UIManager _uIManager;

    private void Start()
    {
        _uIManager = FindObjectOfType<UIManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _uIManager.HPUpdate();
            player.transform.localPosition = respawn.transform.localPosition;
        }
    }
}

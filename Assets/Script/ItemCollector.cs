using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI scoreText;

    [Header("Attributes")]
    [SerializeField] private int score;

    string[] itemTag = { "Item", "Coin" };

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText();
    }

    // Update the score text in the UI
    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    // This method is called when the collider enters a trigger collider
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            score += 1000;
            UpdateScoreText();
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "Key")
        {
            Destroy(collision.gameObject);
        }
    }
}

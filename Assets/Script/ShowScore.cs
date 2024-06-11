using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _score;
    private void Start()
    {
        _score.text = "Score: " + PlayerPrefs.GetInt("Score").ToString();
    }
}

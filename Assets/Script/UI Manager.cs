using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    int Score;  
    int HP;

    [SerializeField] GameObject GameOver;
    [SerializeField] TextMeshProUGUI _scoreText;
    [SerializeField] GameObject[] _heart;
    



    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        HP = 3;
        Score = PlayerPrefs.GetInt("Score");
    }

    // Update is called once per frame
    void Update()

    {

        for (int i = 0; i < 3; i++)
        {
            _heart[i].SetActive(false);
        }


        _scoreText.text = "Score: " + PlayerPrefs.GetInt("Score").ToString();
        for (int i = 0; i < HP; i++)
        {
            _heart[i].SetActive(true);
        }

        Dead();
    }

    public void HPUpdate()
    {
        HP = HP - 1;
    }   


    public void ScoreUpdate(int value)
    {
        Score += value;
        PlayerPrefs.SetInt("Score", Score); 
    }

    public void Dead()
    {
        if (HP <= 0)
        {
            GameOver.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}

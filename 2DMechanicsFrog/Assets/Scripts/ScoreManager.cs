using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour
{
   public static ScoreManager instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI scoreoverText;

    public TextMeshProUGUI continueScoreText;

    public int coins = 0;
    public float score = 0;
    public float scorePerSecond=0.5f;
    public float highscore;
    public float continueScore=0;

    [HideInInspector]
    public bool gameon;
    public bool conti = false;
    private void Awake()
    {
        instance = this;
    }

    private void Start() 
    {
        coins = PlayerPrefs.GetInt("Coin",0);
        highscore = PlayerPrefs.GetFloat("HighScore",0);
        coinText.text = "" + coins;
        scoreText.text = ""+ score;
        continueScore = PlayerPrefs.GetFloat("Score", score);
    }

    private void Update()
    {
        if (gameon)
        {
            coinText.text = "" + coins;

            score += scorePerSecond * Time.deltaTime;
            scoreText.text = "" + Mathf.Round(score);
            highscoreText.text = "" + Mathf.Round(highscore);
            scoreoverText.text = "" + Mathf.Round(score);

            if (score > highscore)
            {
                highscore = score;
                PlayerPrefs.SetFloat("HighScore", highscore);
            }
            PlayerPrefs.SetInt("Coin", coins);
        }
    }


    public void CoinIncrement(int i)
    {
        coins+=i;
        coinText.text = "" + coins;
    }

    public void ContinueScore()
    {   continueScoreText.text = "" + score;
        PlayerPrefs.SetFloat("Score", score);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text scoreText;
    public Text highscoreText;
    public Text coinText;
    public Text coinsTotalText;

    public int coins = 0;
    public int coinsTotal;
    public float score = 0;
    public int scorePerSecond=1;
    public float highscore;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        highscore = PlayerPrefs.GetFloat("HighScore");
        coins = PlayerPrefs.GetInt("CoinPoint");
    }

    private void Update()
    {
        coinText.text = "" + coins;
        coinsTotalText.text = "CoinsTotal: " + coinsTotal;

        score += scorePerSecond * Time.deltaTime;
        scoreText.text = "Score: " +  Mathf.Round( score);
        highscoreText.text = "HighScore: " + Mathf.Round(highscore);
        
        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetFloat("HighScore", highscore);
        }
        if (coins > coinsTotal)
        {
            coinsTotal = coins;
             PlayerPrefs.SetInt("CoinPoint", coinsTotal);
        }
    }

    private void OnTriggerEnter2D(Collider2D Coin)
    {
        if (Coin.tag == "coins")
        {
            coins++;
            Destroy(Coin.gameObject);
            scoreText.text = "Coins: " + coins;
        }
            
    }

}

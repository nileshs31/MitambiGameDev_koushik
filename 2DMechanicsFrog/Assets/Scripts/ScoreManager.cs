using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text scoreText;
    public Text coinText;
    public Text highscoreText;

    public float score;
    public int coinscore;
    public int scorePerSecond=1;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        coinText.text = "Coins: " + coinscore;
        score += scorePerSecond * Time.deltaTime;
        scoreText.text = "Score: " +Mathf.Round( score);
    }

    private void OnTriggerEnter2D(Collider2D Coin)
    {
        if (Coin.tag == "coins")
        {
            coinscore += 5;
            Destroy(Coin.gameObject);
            scoreText.text = "Coins: " + coinscore;
        }
    }

}

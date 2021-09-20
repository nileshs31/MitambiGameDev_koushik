using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreManager : MonoBehaviour
{
   public static ScoreManager instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI scoreoverText;

    public int coins = 0;
    public float score = 0;
    public float scorePerSecond=0.5f;
    public float highscore;

    [HideInInspector]
    public bool gameon;

    private void Awake()
  {
      instance = this;
  }

    private void Start() 
    {
        coins = PlayerPrefs.GetInt("CoinPoint",0);
        highscore = PlayerPrefs.GetFloat("HighScore",0);
        //score = PlayerPrefs.GetFloat("Score", 0);
        coinText.text = "" + coins;
        scoreText.text = ""+ score;
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
            PlayerPrefs.SetInt("CoinPoint", coins);
            //PlayerPrefs.SetFloat("Score", score);
        }
    }

    public void CoinIncrement(int i)
    {
        coins+=i;
        coinText.text = "" + coins;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPannel,hudCanvasPannel,adsToContinuePannel,adsToPlayPannel;

    public Slider slidercount;
    private int stars = 0;
    private float score = 0;
    private float highscore = 0;
    public float timeLeftToDie;
    public float timeToDie;

    public TextMeshProUGUI scoreStarText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI scoreOverText;

    public bool promtToContinue = false;
    private void Start()
    {
        stars = PlayerPrefs.GetInt("Star", 0);
        scoreStarText.text = "" + stars;

        score = PlayerPrefs.GetInt("score",0);
        scoreText.text = "" + score;

        highscore = PlayerPrefs.GetFloat("highscore", 0);
        highScoreText.text = "" + highscore;
    }

    private void Update()
    {
        score += 0.5f * Time.deltaTime;
        scoreText.text = "" + (int)score;
        highScoreText.text = "" + (int)highscore;
        scoreOverText.text = "" + (int)score;
        if(score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetFloat("highscore", highscore);
        }

        if (promtToContinue)
        {
            if(timeLeftToDie > 0)
            {
                slidercount.value = timeLeftToDie;
                timeLeftToDie -= Time.unscaledDeltaTime;
            }
            else
            {
                promtToContinue = false;
                GameOver();
            }
        }
    }

    public void ShowAddsPannel()
    {
        adsToContinuePannel.SetActive(true);
        timeToDie = 5;
        timeLeftToDie = timeToDie;
        slidercount.maxValue = timeToDie;
        promtToContinue = true;
        Time.timeScale = 0f;
    }

    public void continueWithCoins()
    {

    }

    //score
    public void StarsIncrement(int count)
    {
        stars += count;
        PlayerPrefs.SetInt("Star", stars);
        scoreStarText.text = "" + stars;
    }

  /*  public void GameOverPannel()
    {
        Time.timeScale = 0f;
        gameOverPannel.SetActive(true);
        hudCanvasPannel.SetActive(false);
     }*/

  public void GameOver()
  {
        gameOverPannel.SetActive(true);
        Time.timeScale = 0f;
        adsToContinuePannel.SetActive(false);
        hudCanvasPannel.SetActive(false);
  } 
    public void HomeButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    //ads
    public void OnFinishedAds()
    {
        promtToContinue = false;
        Time.timeScale = 0f;
        adsToContinuePannel.SetActive(false);
        gameOverPannel.SetActive(false);
        adsToPlayPannel.SetActive(true);
    }
    public void OnSkippedAds()
    {
        Debug.Log("No reward");
    }
    public void OnFailedAds()
    {
        Debug.Log("Ads failed to load");
    }
}

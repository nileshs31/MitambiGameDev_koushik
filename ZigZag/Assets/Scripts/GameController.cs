using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public bool gameon;
    bool promtToContinue;
    private int diamonds = 0;
    private float score = 0;
    private float highscore;
    public float timeLeftToDie = 1f;
    public float timeToDie = 5f;
    [SerializeField] TextMeshProUGUI diamondsText,scoreText,scoreOverText,highScoreText;
    [SerializeField] GameObject adsToContinuePannel,gameOverPannel;

    public Slider slidercount;
    private void Start()
    {
        diamonds = PlayerPrefs.GetInt("Diamond", 0);
        diamondsText.text = "" + diamonds;

        score = PlayerPrefs.GetInt("Score", 0);
        scoreText.text = "" + score;

        highscore = PlayerPrefs.GetFloat("highscore", 0);
        highScoreText.text = "" + highscore;
    }

    private void Update()
    {
        if (gameon)
        {
            score += 0.5f * Time.deltaTime;
        }
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
            if (timeLeftToDie > 0)
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

    public void ShowAdsPannel()
    {
        adsToContinuePannel.SetActive(true);
        timeLeftToDie = timeToDie;
        slidercount.maxValue = timeToDie;
        promtToContinue = true;
        Time.timeScale = 0f;

    }
    public void ContinueWithCoins()
    {
        if (diamonds >= 1)
        {
            diamonds -= 1;
            PlayerPrefs.SetInt("diamonds", diamonds);
            diamondsText.text = diamonds + "";
            Continue2();
        }
        else
        {
            Debug.Log("no coins");
        }
    }

    public void Continue2()
    {
        PlayerPrefs.SetInt("score", (int)score);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void ContinueVideo()
    {
        PlayerPrefs.SetInt("score", (int)score);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        /*PlayerPrefs.SetInt("score", 0);*/
        Time.timeScale = 1f;

    }

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void DiamondCount(int count)
    {
        diamonds += count;
        PlayerPrefs.SetInt("Diamond", diamonds);
        diamondsText.text = "" + diamonds;
    }

    public void ScoreCount(float c)
    {

    }

    public void GameOver()
    {
        adsToContinuePannel.SetActive(false);
        gameOverPannel.SetActive(true);
    }
}

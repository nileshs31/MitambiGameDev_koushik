using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject pausePannel, gameOverPannel, hudCanvasPannel, adsToContinuePannel, adsToPlayPannel;

    public Slider slidercount;
    private int diamond = 0;
    private float score = 0;
    private float Highscore = 0;
    public float timeLeftToDie;
    public float timeToDie;
    private string scorePrefs = "Score";
    private string highScorePrefs= "HighScore";
    private string diamondPrefs = "Diamond";

    bool tap = true;

    public TextMeshProUGUI scoreStarText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI scoreOverText;

    public bool promtToContinue = false;
    private void Start()
    {
        diamond = PlayerPrefs.GetInt(diamondPrefs, 0);
        scoreStarText.text = "" + diamond;

        score = PlayerPrefs.GetInt(scorePrefs, 0);
        scoreText.text = "" + score;

        Highscore = PlayerPrefs.GetFloat(highScorePrefs,0);
        highScoreText.text = "" + Highscore;
    }

    private void Update()
    {
        score += 0.5f * Time.deltaTime;

        scoreText.text = "" + (int)score;
        highScoreText.text = "" + (int)Highscore;
        scoreOverText.text = "" + (int)score;
        if (score > Highscore)
        {
            Highscore = score;
            PlayerPrefs.SetFloat(highScorePrefs, Highscore);
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

        //if (!EventSystem.current.IsPointerOverGameObject(0) && Input.GetMouseButtonDown(0))


        //PAUSE
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausePannel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void ShowAddsPannel()
    {
        adsToContinuePannel.SetActive(true);
        hudCanvasPannel.SetActive(false);
        timeToDie = 5;
        timeLeftToDie = timeToDie;
        slidercount.maxValue = timeToDie;
        promtToContinue = true;
        Time.timeScale = 0f;
    }

    public void PausePannel(int choice)
    {

        if (choice == 0)
        {
            Time.timeScale = 0f;
            pausePannel.SetActive(true);
        }
        else
        {
            pausePannel.SetActive(false);
            Time.timeScale = 1f;
        }

    }

    public void continueWithCoins()
    {
        if (diamond >= 1)
        {
            diamond -= 1;
            PlayerPrefs.SetInt(diamondPrefs, diamond);
            scoreStarText.text = diamond + "";
            Continue2();
        }
        else
        {
            Debug.Log("no coins");
        }
    }

    public void Continue2()
    {
        PlayerPrefs.SetInt(scorePrefs, (int)score);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    //score
    public void DiamondIncrement(int count)
    {
        diamond += count;
        PlayerPrefs.SetInt(diamondPrefs, diamond);
        scoreStarText.text = "" + diamond;
    }

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
        PlayerPrefs.SetInt(scorePrefs, 0);
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

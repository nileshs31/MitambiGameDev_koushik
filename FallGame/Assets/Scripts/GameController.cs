using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject pausePannel,gameOverPannel,hudCanvasPannel,adsToContinuePannel,adsToPlayPannel,VolumeOffButton, VolumeOnButton;

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

        var vol = PlayerPrefs.GetInt("Volume", 1);
        AudioListener.volume = vol;
        if (AudioListener.volume == 0f)
        {
            VolumeOffButton.SetActive(false);
            VolumeOnButton.SetActive(true);
        }
        else
        {
            VolumeOffButton.SetActive(true);
            VolumeOnButton.SetActive(false);
        }
    }

    public void VolOn()
    {
        VolumeOffButton.SetActive(true);
        VolumeOnButton.SetActive(false);
        AudioListener.volume = 1f;
        PlayerPrefs.SetInt("Volume", 1);

    }

    public void VolOff()
    {
        VolumeOffButton.SetActive(false);
        VolumeOnButton.SetActive(true);
        AudioListener.volume = 0f;
        PlayerPrefs.SetInt("Volume", 0);

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
        if (stars >= 1)
        {
            stars -= 1;
            PlayerPrefs.SetInt("Star",stars);
            scoreStarText.text = stars + "";
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

    //score
    public void StarsIncrement(int count)
    {
        stars += count;
        PlayerPrefs.SetInt("Star", stars);
        scoreStarText.text = "" + stars;
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
        PlayerPrefs.SetInt("score", 0);
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

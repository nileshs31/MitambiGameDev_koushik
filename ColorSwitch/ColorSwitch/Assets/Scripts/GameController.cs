using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour
{
    [SerializeField] MemeController MemeController;
    [SerializeField] private GameObject pausePannel, gameOverPannel, hudCanvasPannel, adsToContinuePannel, adsToPlayPannel , VolumeOffButton , VolumeOnButton;
    public GameObject pauseButton;
    public Slider slidercount;
    public Tweener textPopup;
    private int diamond = 0;
    public float score = 0;
    private float Highscore = 0;
    public float timer = 0;
    public float timeLeftToDie;
    public float timeToDie;
    private string scorePrefs = "Score";
    private string highScorePrefs= "HighScore";
    private string diamondPrefs = "Diamond";

    //bool tap = true;

    public TextMeshProUGUI scoreStarText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI scoreOverText;
    public TextMeshProUGUI popUpText;


    public bool promtToContinue = false;
    private void Start()
    {
        diamond = PlayerPrefs.GetInt(diamondPrefs, 0);
        scoreStarText.text = "" + diamond;

        score = PlayerPrefs.GetInt(scorePrefs, 0);
        scoreText.text = "" + score;

        Highscore = PlayerPrefs.GetFloat(highScorePrefs,0);
        highScoreText.text = "" + Highscore;

        MemeController.Soundobj = GameObject.FindGameObjectWithTag("Backgroundmusic").GetComponent<AudioSource>();

        if (PlayerPrefs.GetInt("continue", 0) == 0)
        {
            //var x = MemeController.PlayMidSounds();
            var x = MemeController.PlayGameStartMeme();
        }
        else
        {
            var x = MemeController.PlayAfterAdsMemes();
        }
    }

    private void Update()
    {
        score += 0.5f * Time.deltaTime;

        scoreText.text = "" + (int)score;
        highScoreText.text = "" + (int)Highscore;
        scoreOverText.text = "" + (int)score;

        timer += Time.deltaTime;
        if (timer >= Random.Range(8f, 12f))
        {
            MemeController.PlayMidSounds();
            timer = 0;
        }

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

        //PAUSE
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausePannel.SetActive(true);
            Time.timeScale = 0f;
        }

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
            pauseButton.SetActive(false);
            
        }
        else
        {
            pausePannel.SetActive(false);
            Time.timeScale = 1f;
        }

    }

    public void continueWithCoins()
    {
        if (diamond >= 10)
        {
            diamond -= 10;
            PlayerPrefs.SetInt(diamondPrefs, diamond);
            scoreStarText.text = diamond + "";
            Continue2();
        }
        else
        {
            popUpText.text = "Not Enough Coins";
            textPopup.Show(textPopup.CloseAfter);
            var x = MemeController.PlayNoMoneyMemes();
            StopAllCoroutines();
            promtToContinue = false;
            StartCoroutine(continuePromt(x));
        }
    }

    IEnumerator continuePromt(float waitTime)
    {
        yield return new WaitForSecondsRealtime(waitTime);
        promtToContinue = true;
    }

    public void Continue2()
    {
        PlayerPrefs.SetInt(scorePrefs, (int)score);
        PlayerPrefs.SetInt("continue", 1);
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
        var x = MemeController.PlayGameEndMemes();
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
        PlayerPrefs.SetInt("continue", 0);
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
        popUpText.text = "Please Watch the Whole Ad!";
        textPopup.Show(textPopup.CloseAfter);
    }
    public void OnFailedAds()
    {
        Debug.Log("Ads failed to load");
        popUpText.text = "Ads Loading...";
        textPopup.Show(textPopup.CloseAfter);
    }
}

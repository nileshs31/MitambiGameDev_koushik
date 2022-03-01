using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamecontroller : MonoBehaviour {
    public ScoreManager scoreMan;
    public Player playerCon;
    public MemeController MemeController;

    public move camMover;
    public Animator[] animators;
    public Slider sliderCont;
    public Tweener textPopup;

    [SerializeField]private UnityAds UnityAds;
    [SerializeField] 
    GameObject pausePanel,addstoContinuePannel,adsToPlayPannel, gameOverPanel , hudCanvas ,quitPannel;
    public GameObject VolumeOffButton, VolumeOnButton;
    [SerializeField]float timeLeftToDie;
    [SerializeField]float timeToDie;
    bool promtToContinue = false;

    private float score = 0;
    private float highscore = 0;
    private int coins = 0;
    public float timer = 0;
    public TextMeshProUGUI popUpText;
    public TextMeshProUGUI CoinsText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI scoreOverText;

    private void Start()
    {
        StartGame();

        coins = PlayerPrefs.GetInt("Coin", 0);
        CoinsText.text = "" + coins;

        score = PlayerPrefs.GetInt("score", 0);
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

        MemeController.Soundobj = GameObject.FindGameObjectWithTag("Backgroundmusic").GetComponent<AudioSource>();

        if (PlayerPrefs.GetInt("continue", 0) == 0)
        {
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
        highScoreText.text = "" + (int)highscore;
        scoreOverText.text = "" + (int)score;

        timer += Time.deltaTime;
        if (timer >= Random.Range(8f, 12f))
        {
            MemeController.PlayMidSounds();
            timer = 0;
        }

        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetFloat("highscore", highscore);
        }

        if (promtToContinue)
        {
            if(timeLeftToDie > 0)
            {
                sliderCont.value = timeLeftToDie;
                timeLeftToDie -= Time.unscaledDeltaTime;
            }
            else
            {
                promtToContinue = false;
                GameOver();
            }
        }
    }

    internal void CoinIncrement(int v)
    {
        coins += v;
        PlayerPrefs.SetInt("Coin", coins);
        CoinsText.text = "" + coins;
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

    public void StartGame()
    {
        Time.timeScale = 1f;
        camMover.speed = 2f;
        playerCon.gameon = true;
        foreach (Animator bgAnim in animators)
        {
            bgAnim.enabled = true;
        }
       /* PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("continue", 0);*/

    }

    public void GameOver()
    {
        var x = MemeController.PlayGameEndMemes();
        camMover.speed = 0f;
        gameOverPanel.SetActive(true);
        foreach (Animator bgAnim in animators)
        {
            bgAnim.enabled = false;
        }
        playerCon.gameon = false;
        scoreMan.gameon = false;
        hudCanvas.SetActive(false);
        addstoContinuePannel.SetActive(false);
    }

    public void ContinueWithCoins()
    {
       if(coins >= 10)
       {
            coins -= 10;
            PlayerPrefs.SetInt("Coin", coins);
            CoinsText.text = "" + coins;
            ContinueGame();
       }
        else
        {
            Debug.Log("Not enought coins");
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

    public void ContinueGame()
    {
        PlayerPrefs.SetInt("score", (int)score);
        PlayerPrefs.SetInt("continue", 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void Retry()
    {
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.SetInt("continue", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
    
    public void Home()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void ShowAddsPannel()
    {
        addstoContinuePannel.SetActive(true);
        playerCon.gameObject.SetActive(false);
        timeToDie = 5;
        timeLeftToDie = timeToDie;
        sliderCont.maxValue = timeToDie;
        promtToContinue = true;
        Time.timeScale = 0f;
    }

    //ads
    public void OnFinishedAds()
    {
        promtToContinue = false;
        Time.timeScale = 0f;
        addstoContinuePannel.SetActive(false);
        gameOverPanel.SetActive(false);
        adsToPlayPannel.SetActive(true);
    }
    public void OnSkippedAds()
    {
        popUpText.text = "Please Watch the Whole Ad!";
        textPopup.Show(textPopup.CloseAfter);
    }
    public void OnFailedAds()
    {
        popUpText.text = "Ads Loading...";
        textPopup.Show(textPopup.CloseAfter);
    }
}

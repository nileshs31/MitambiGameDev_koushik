using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamecontroller : MonoBehaviour {
    public ScoreManager scoreMan;
    public Player playerCon;
    public move camMover;
    [SerializeField] 
    GameObject pausePanel,addstoContinuePannel, gameOverPanel , hudCanvas ,quitPannel;

    public GameObject VolumeOffButton, VolumeOnButton;
    public float timeLeftToDie;
    public float timeToDie;
    public bool promtToContinue = false;
    public bool continueScore = false;
    public Animator[] animators;
    public Slider sliderCont;

    private void Start()
    {
        StartGame();
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
        //promtToContinue = false;
    }

    private void Update()
    {
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
        if (continueScore)
        {

        }
    }

    public void ResumeScore()
    {
        scoreMan.continueScore = PlayerPrefs.GetFloat("conScore", scoreMan.score);
        scoreMan.scoreText.text = "" + Mathf.Round(scoreMan.continueScore);
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
        scoreMan.scoreText.text = scoreMan.score + "";
        camMover.speed = Random.Range(1.25f,2f);
        playerCon.gameon = true;
        scoreMan.gameon = true;
        foreach (Animator bgAnim in animators)
        {
            bgAnim.enabled = true;
        }
    }

    public void GameOver()
    {
        camMover.speed = 0;
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

    public void CoinIncrement(int coinCount)
    {
        scoreMan.CoinIncrement(coinCount);
    }

    public void ContinueWithAd()
    {
        //adcon.ShowVideoBasedRewarded();
    }

    public void ContinueWithCoins()
    {
       if( scoreMan.coins >= 5)
       {
            scoreMan.coins -= 5;
            PlayerPrefs.SetInt("CoinPoint", scoreMan.coins);
            scoreMan.coinText.text = scoreMan.coins + "";
            ContinueGame();
       }
        else
        {
            Debug.Log("Not enought coins");
        }
    }

    public void ContinueGame()
    {
        Time.timeScale = 1f;
        addstoContinuePannel.SetActive(false);
        promtToContinue = false;
        timeToDie = 5;
        timeLeftToDie = timeToDie;

        SceneManager.LoadScene("GP");
        Debug.Log("Continue");
        
    }

    public void Retry()
    { 
        Debug.Log("Player Respawn");
        SceneManager.LoadScene("GP");
        Time.timeScale = 1f;
    }
    
    public void Home()
    {
        SceneManager.LoadScene("Menu");
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

    public void QuitPannel()
    {
        quitPannel.SetActive(true);
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

    public void CloseAddsPannel()
    {
        addstoContinuePannel.SetActive(false);
        GameOver();
    }
}

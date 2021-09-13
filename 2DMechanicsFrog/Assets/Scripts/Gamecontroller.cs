using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Gamecontroller : MonoBehaviour {
    public ScoreManager scoreMan;
    public Player playerCon;
    [SerializeField] 
    GameObject menuPanel, inGamePanel, pausePanel, gameOverPanel;
    public move camMover;
    public Animator[] animators;
    public GameObject HomeVolumeOff;
    public GameObject HomeVolumeOn;

    public GameObject PauseSoundOff;
    public GameObject PauseSoundOn;


    public AudioSource HomeBackground;
    public AudioSource Playbackground;

    private void Start()
    {
        foreach(Animator bgAnim in animators)
        {
            bgAnim.enabled = false;
        }

        if(AudioListener.volume == 0)
        {
            HomeVolumeOff.SetActive(true);
            HomeVolumeOn.SetActive(false);
        }
        else
        {
            HomeVolumeOff.SetActive(true);
            HomeVolumeOn.SetActive(false);
        }


        if(AudioListener.volume == 0)
        {
            PauseSoundOff.SetActive(true);
            PauseSoundOn.SetActive(false);
        }
        else
        {
            PauseSoundOff.SetActive(false);
            PauseSoundOn.SetActive(true);
        }

    }
    public void StartGame()
    {
        camMover.speed = 1.25f;
        playerCon.gameon = true;
        scoreMan.gameon = true;
        inGamePanel.SetActive(true);
        menuPanel.SetActive(false);
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
    }

    public void CoinIncrement(int coinCount)
    {
        scoreMan.CoinIncrement(coinCount);
    }

    public void Retry()
    {
        SceneManager.LoadScene("GP");
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

    public void VolOn()
    {
        AudioListener.volume = 1f;
        HomeVolumeOff.SetActive(true);
        HomeVolumeOn.SetActive(false);
    }
    public void VolOff() 
    {
        AudioListener.volume = 0f;
        HomeVolumeOff.SetActive(false);
        HomeVolumeOn.SetActive(true);
    }

    public void PauseVolOn()
    {
        AudioListener.volume = 1f;
        PauseSoundOff.SetActive(true);
        PauseSoundOn.SetActive(false);
    }

    public void PauseVolOff()
    {
        AudioListener.volume = 0f;
        PauseSoundOff.SetActive(false);
        PauseSoundOn.SetActive(true);
    }
}

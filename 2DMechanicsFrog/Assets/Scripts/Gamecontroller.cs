using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Gamecontroller : MonoBehaviour {
    public ScoreManager scoreMan;
    public Player playerCon;
    [SerializeField] 
    GameObject menuPanel, inGamePanel, pausePanel,settingHomePannel,addstoContinuePannel, gameOverPanel , quitPannel;
    public move camMover;
    public Animator[] animators;

    public AudioSource HomeBackground;
    [SerializeField] private TextMeshProUGUI soundOn;
    [SerializeField] private TextMeshProUGUI soundOff;
    private bool muted;
    public void startOnButtonPress()
    {
        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
        }
        OnSave();
        UpdateTextSound();
    }

    public void OnLoad()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }
    public void OnSave()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }

    private void Start()
    {
        foreach(Animator bgAnim in animators)
        {
            bgAnim.enabled = false;
        }
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            OnLoad();
        }
        else
        {
            OnLoad();
        }
        UpdateTextSound();
        AudioListener.pause = muted;
        /*if (AudioListener.volume == 0)
        {
            HomeVolumeOffPrefab.SetActive(true);
            HomeVolumeOnPrefab.SetActive(false);
        }
        else
        {
            HomeVolumeOffPrefab.SetActive(true);
            HomeVolumeOnPrefab.SetActive(false);
        }*/
    }

    private void UpdateTextSound()
    {
        if (muted == false)
        {
            soundOn.enabled = true;
            soundOff.enabled = false;
        }
        else
        {
            soundOn.enabled = false;
            soundOff.enabled = true;
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
        
    }
    
    public void Home()
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

    public void QuitPannel()
    {
        quitPannel.SetActive(true);
    }

    public void yesAppQuit()
    {
        Debug.Log("application quit");
        Application.Quit();
    }
    public void noAppQuit()
    {
        quitPannel.SetActive(false);
    }

    public void HomeSetting()
    {
        settingHomePannel.SetActive(true);
    }
    public void HomeSettingClose()
    {
        settingHomePannel.SetActive(false);
    }

    public void ShowAddsPannel()
    {
        addstoContinuePannel.SetActive(true);
    }
    public void CloseAddsPannel()
    {
        addstoContinuePannel.SetActive(false);
    }

    //sounds
/*    public void VolOn()
    {
        AudioListener.volume = 1f;
        HomeVolumeOffPrefab.SetActive(true);
        HomeVolumeOnPrefab.SetActive(false);
    }
    public void VolOff()
    {
        AudioListener.volume = 0f;
        HomeVolumeOffPrefab.SetActive(false);
        HomeVolumeOnPrefab.SetActive(true);
    }

    public void PauseVolOn()
    {
        AudioListener.volume = 1f;
        HomeVolumeOffPrefab.SetActive(false);
        HomeVolumeOnPrefab.SetActive(true);
    }

    public void PauseVolOff()
    {
        AudioListener.volume = 0f;
        HomeVolumeOffPrefab.SetActive(true);
        HomeVolumeOnPrefab.SetActive(false);
    }*/


    //socialhandles
    public void Instagram()
    {
        Application.OpenURL("https://www.instagram.com/mightyhardstudios/");
    }

    public void Website()
    {
        Application.OpenURL("https://mitambisolutions.com/contactus");
    }

    public void PlayStore()
    {
        Application.OpenURL("https://play.google.com/store/apps/dev?id=6545217765197016792");
    }
}

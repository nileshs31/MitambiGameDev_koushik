using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject exitPannel, HudCanvasPannel, settingPannel,VolumeOffButton, VolumeOnButton, htpPanel, creditsPanel;

    public TextMeshProUGUI highScoreText;

    void Start()
    {

        highScoreText.text = "" + (int)PlayerPrefs.GetFloat("highscore", 0);

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

    public void OnYesNo(int choice)
    {
        if(choice == 1) { 
            //show ad then quit
            Application.Quit();
        } 
        
        exitPannel.SetActive(false);
        HudCanvasPannel.SetActive(true);
    }

    public void setting()
    {
        settingPannel.SetActive(true);
        HudCanvasPannel.SetActive(false);
      //  playbutton.SetActive(false);
    }

    public void ShowHTP()
    {
        htpPanel.SetActive(true);
    }


    public void CloseHTP()
    {
        htpPanel.SetActive(false);
    }

    public void ShowCredits()
    {
        creditsPanel.SetActive(true);
    }


    public void CloseCredits()
    {
        creditsPanel.SetActive(false);
    }

    public void closeSetting()
    {
        settingPannel.SetActive(false);
        HudCanvasPannel.SetActive(true);
        //playbutton.SetActive(true);
    }

    public void Play()
    {
        PlayerPrefs.SetInt("score", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        Time.timeScale = 1f;
    }

    public void quitButton()
    {
        exitPannel.SetActive(true);
        HudCanvasPannel.SetActive(false);
    }

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

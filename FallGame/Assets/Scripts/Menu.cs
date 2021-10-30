using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject exitPannel, HudCanvasPannel, settingPannel,VolumeOffButton, VolumeOnButton;

    void Start()
    {
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(SceneManager.GetActiveScene().buildIndex != 0)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                exitPannel.SetActive(true);
                HudCanvasPannel.SetActive(false);
            }
        }
          }
    public void OnYesNo(int choice)
    {
        if(choice == 1) { 
            Application.Quit();
            Debug.Log("Application Quit");
        } exitPannel.SetActive(false);
                HudCanvasPannel.SetActive(true);
    }

    public void setting()
    {
        settingPannel.SetActive(true);
        HudCanvasPannel.SetActive(false);
    }

    public void closeSetting()
    {
        settingPannel.SetActive(false);
        HudCanvasPannel.SetActive(true);
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

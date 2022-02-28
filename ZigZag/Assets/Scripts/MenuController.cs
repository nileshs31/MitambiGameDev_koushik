using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject exitPannel, HudCanvasPannel, settingPannel, VolumeOffButton, VolumeOnButton, playbutton , HTPPannel,CredPannel;

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
            if (SceneManager.GetActiveScene().buildIndex != 0)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                exitPannel.SetActive(true);
                HudCanvasPannel.SetActive(false);
            }
        }
       /* if(!EventSystem.current.IsPointerOverGameObject(0) && !EventSystem.current.IsPointerOverGameObject() && Input.GetMouseButtonDown(0))
        {
            Play();
        }*/
    }
    public void OnYesNo(int choice)
    {
        if (choice == 1)
        {
            Application.Quit();
            Debug.Log("Application Quit");
        }
        exitPannel.SetActive(false);
        HudCanvasPannel.SetActive(true);
    }

    public void setting()
    {
        settingPannel.SetActive(true);
        HudCanvasPannel.SetActive(false);
        playbutton.SetActive(false);
    }

    public void closeSetting()
    {
        settingPannel.SetActive(false);
        HudCanvasPannel.SetActive(true);
        playbutton.SetActive(true);
    }

    public void Play()
    {
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.SetInt("continue",0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }

    public void quitButton()
    {
        exitPannel.SetActive(true);
        HudCanvasPannel.SetActive(false);
    }

    public void ShowHtpAndCred(int n)
    {
        switch (n)
        {
            case 1: HTPPannel.SetActive(true);
                break;

            case 2: CredPannel.SetActive(true);
                break;
        }
    }

    public void CloseShowHtpAndCred(int n)
    {
        switch (n)
        {
            case 1:
                HTPPannel.SetActive(false);
                break;

            case 2:
                CredPannel.SetActive(false);
                break;
        }
    }

    public void Socials(int num)
    {

        switch (num)
        {
            case 1:
                Application.OpenURL("https://mitambisolutions.com/contactus");
                break;
            case 2:
                Application.OpenURL("https://www.instagram.com/mightyhardstudios");
                break;
            case 3:
                Application.OpenURL("https://play.google.com/store/apps/dev?id=6545217765197016792");
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    [SerializeField] GameObject settingHomePannel, quitPannel;
    public GameObject VolumeOffButton, VolumeOnButton ;
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

    public void StartGameplay()
    {
        SceneManager.LoadScene("GP");
    }

    public void QuitPannel()
    {
        quitPannel.SetActive(true);
    }

    public void YesAppQuit()
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    [SerializeField] GameObject settingHomePannel, quitPannel;
    [SerializeField] GameObject gameController;
    public void StarGameplay()
    {
        SceneManager.LoadScene("GP");
        GameObject.FindGameObjectWithTag("GameController").GetComponent<Gamecontroller>().StartGame();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject exitPannel;
    [SerializeField] GameObject HudCanvasPannel;
    [SerializeField] GameObject settingPannel;

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
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        Time.timeScale = 1f;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public static UIManager _instance;
    public GameObject gameover;
    public GameObject Points;
    public GameObject Mainmenu;
    public static UIManager instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.FindObjectOfType<UIManager>();
            }
            return _instance;
        }
    }
     
    public void GameOver()
    {
        gameover.SetActive(true);
    }

    public void MainMenu() {
        Mainmenu.SetActive(false);
    }
}

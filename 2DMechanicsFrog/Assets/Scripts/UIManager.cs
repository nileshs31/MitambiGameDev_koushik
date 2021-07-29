using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public static UIManager _instance;
    public GameObject gamebuttons;
    public GameObject gameover;
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
        gamebuttons.SetActive(false);
        gameover.SetActive(true);
    }


}

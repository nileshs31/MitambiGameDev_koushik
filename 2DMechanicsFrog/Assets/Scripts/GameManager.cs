using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }
    public bool gameOver = false;
    public void GameOver()
    {
        gameOver = true;
        UIManager.instance.GameOver();
    }

    public void Retry()
    {
        if(gameOver == true)
        {
            SceneManager.LoadScene("GP");
        }
    }

}

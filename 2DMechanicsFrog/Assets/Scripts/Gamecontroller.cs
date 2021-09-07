using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Gamecontroller : MonoBehaviour{
    public GameObject playbutton;
    public GameObject gamover;
    public void StartGame()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<move>().speed = 2;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().gameon = true;
        playbutton.SetActive(false);
    }

    public void GameOver()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<move>().speed = 0;
        gamover.SetActive(true);
    }
    public void Retry()
    {
        playbutton.SetActive(true);
        SceneManager.LoadScene("GP");
    }
}

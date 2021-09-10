using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Gamecontroller : MonoBehaviour{
    public GameObject menuPanel, gameOverPanel;
    public Player playerCon;
    public move camMover;
    public Animator[] animators;

    private void Start()
    {
        foreach(Animator bgAnim in animators)
        {
            bgAnim.enabled = false;
        }
    }
    public void StartGame()
    {
        camMover.speed = 2;
        playerCon.gameon = true;
        menuPanel.SetActive(false);
        foreach (Animator bgAnim in animators)
        {
            bgAnim.enabled = true;
        }
    }

    public void GameOver()
    {
        camMover.speed = 0;
        gameOverPanel.SetActive(true);
        foreach (Animator bgAnim in animators)
        {
            bgAnim.enabled = false;
        }
        playerCon.gameon = false;

    }
    public void Retry()
    {
        //menuPanel.SetActive(true);
        //gameOverPanel.SetActive(false);
        SceneManager.LoadScene("GP");
    }
}

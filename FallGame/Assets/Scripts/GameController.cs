using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
  [SerializeField] private GameObject gameOverPannel;
  public void GameOverPannel()
  {
    Time.timeScale = 0f;
    gameOverPannel.SetActive(true);
  }

  public void GameOver()
  {
    SceneManager.LoadScene("GAMEPLAY");
    Time.timeScale = 1f;
  }

  public void Play(){
    SceneManager.LoadScene("GAMEPLAY");
  }
}

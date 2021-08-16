using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool gampaused = false;
    public GameObject pauseMenubutton;
    // Start is called before the first frame update
    void Start()
    {
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gampaused)
            {
                Resume();
            }
            else
            {
                pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenubutton.SetActive(false);
        Time.timeScale = 1f;
        gampaused = false;
    }
    public void pause()
    {
        pauseMenubutton.SetActive(true);
        Time.timeScale = 0f;
        gampaused = true;
    }
}

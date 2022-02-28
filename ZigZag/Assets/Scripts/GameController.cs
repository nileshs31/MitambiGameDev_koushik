using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public bool gameon;
    bool promtToContinue;
    private int diamonds = 0;
    private float score = 0;
    private float highscore;
    public float timeLeftToDie = 1f;
    public float timeToDie = 5f;
    public float timer = 0;
    
    [SerializeField] TextMeshProUGUI diamondsText,scoreText,scoreOverText,highScoreText, popUpText;
    [SerializeField] GameObject adsToContinuePannel,adsToPlayPannel,gameOverPannel,volumeOff,volumeOn,pausePannel,hudCanvas;

    public Slider slidercount;
    public Tweener textPopup;
    public MemeController MemeController;

    private void Start()
    {
        diamonds = PlayerPrefs.GetInt("Diamond", 0);
        diamondsText.text = "" + diamonds;

        score = PlayerPrefs.GetInt("score", 0);
        scoreText.text = "" + score;

        highscore = PlayerPrefs.GetFloat("highscore", 0);
        highScoreText.text = "" + highscore;

        var vol = PlayerPrefs.GetInt("Volume", 1);
        AudioListener.volume = vol;
        if (AudioListener.volume == 0f)
        {
            volumeOff.SetActive(false);
            volumeOn.SetActive(true);
        }
        else
        {
            volumeOff.SetActive(true);
            volumeOn.SetActive(false);
        }
        MemeController.Soundobj = GameObject.FindGameObjectWithTag("Backgroundmusic").GetComponent<AudioSource>();

        if (PlayerPrefs.GetInt("continue", 0) == 0)
        {
            var x = MemeController.PlayGameStartMeme();
        }
        else
        {
            var x = MemeController.PlayAfterAdsMemes();
        }
    }

    private void Update()
    {
        score += 0.5f * Time.deltaTime;
        scoreText.text = "" + (int)score;
        highScoreText.text = "" + (int)highscore;
        scoreOverText.text = "" + (int)score;

        timer += Time.deltaTime;
        if (timer >= Random.Range(8f, 12f))
        {
            MemeController.PlayMidSounds();
            timer = 0;
        }

        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetFloat("highscore", highscore);
        }

        if (promtToContinue)
        {
            if (timeLeftToDie > 0)
            {
                slidercount.value = timeLeftToDie;
                timeLeftToDie -= Time.unscaledDeltaTime;
            }
            else
            {
                promtToContinue = false;
                GameOver();
            }
        }
    }

    public void VolOn()
    {
        volumeOff.SetActive(true);
        volumeOn.SetActive(false);
        AudioListener.volume = 1f;
        PlayerPrefs.SetInt("Volume", 1);
        Debug.Log("Volume On");
    }

    public void VolOff()
    {
        volumeOff.SetActive(false);
        volumeOn.SetActive(true);
        AudioListener.volume = 0f;
        PlayerPrefs.SetInt("Volume", 0);
        Debug.Log("Volume OFF");
    }

    public void Pause()
    {
        hudCanvas.SetActive(false);
        pausePannel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClosePause()
    {
        hudCanvas.SetActive(true);
        pausePannel.SetActive(false);
        Time.timeScale = 1;
    }

    public void ShowAdsPannel()
    {
        adsToContinuePannel.SetActive(true);
        timeLeftToDie = timeToDie;
        slidercount.maxValue = timeToDie;
        promtToContinue = true;
        Time.timeScale = 0f;

    }
    public void ContinueWithCoins()
    {
        if (diamonds >= 10)
        {
            diamonds -= 10;
            PlayerPrefs.SetInt("Diamond", diamonds);
            diamondsText.text = diamonds + "";
            Continue2();
        }
        else
        {
            popUpText.text = "Not Enough Coins";
            textPopup.Show(textPopup.CloseAfter);
            var x = MemeController.PlayNoMoneyMemes();
            StopAllCoroutines();
            promtToContinue = false;
            StartCoroutine(continuePromt(x));
        }
    }

    IEnumerator continuePromt(float waitTime)
    {
        yield return new WaitForSecondsRealtime(waitTime);
        promtToContinue = true;
    }


    public void Continue2()
    {
        PlayerPrefs.SetInt("score", (int)score);
        PlayerPrefs.SetInt("continue", 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.SetInt("continue", 0);
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Time.timeScale = 1f;
    }

    public void DiamondCount(int count)
    {
        diamonds += count;
        PlayerPrefs.SetInt("Diamond", diamonds);
        diamondsText.text = "" + diamonds;
    }

    public void GameOver()
    {
        var x = MemeController.PlayGameEndMemes();
        gameOverPannel.SetActive(true);
        Time.timeScale = 0f;
        adsToContinuePannel.SetActive(false);
        hudCanvas.SetActive(false);
    }

    //ADs

    public void OnFinishedAds()
    {
        promtToContinue = false;
        Time.timeScale = 0f;
        adsToContinuePannel.SetActive(false);
        gameOverPannel.SetActive(false);
        adsToPlayPannel.SetActive(true);
    }
    public void OnSkippedAds()
    {

        popUpText.text = "Please Watch the Whole Ad!";
        textPopup.Show(textPopup.CloseAfter);
    }
    public void OnFailedAds()
    {
        popUpText.text = "Ads Loading...";
        textPopup.Show(textPopup.CloseAfter);
    }
}

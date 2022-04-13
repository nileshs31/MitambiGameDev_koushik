using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEngine.EventSystems;

public class GameController : MonoBehaviour
{
    public MemeController MemeController;
    [SerializeField] private GameObject pausePannel, gameOverPannel, hudCanvasPannel, adsToContinuePannel, adsToPlayPannel, VolumeOffButton, VolumeOnButton;
    public Slider slidercount;

    public int charIndex;
    private int stars = 0;
    private float score = 0;
    private float highscore = 0;
    public float timeLeftToDie;
    public float timeToDie;
    public float timer = 0;
    public Tweener textPopup;
    public TextMeshProUGUI popUpText;
    public TextMeshProUGUI scoreStarText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI scoreOverText;

    [SerializeField] GameObject[] playerPrefabs;
    
    bool promtToContinue = false;
    public bool midgame = false;
        
    private void Start() 
    {
        
        charIndex = PlayerPrefs.GetInt("selectChar", 0);
        Instantiate(playerPrefabs[charIndex]);


        stars = PlayerPrefs.GetInt("Star", 0);
        scoreStarText.text = "" + stars;

        score = PlayerPrefs.GetInt("score", 0);
        scoreText.text = "" + score;

        highscore = PlayerPrefs.GetFloat("highscore", 0);
        highScoreText.text = "" + highscore;

        var vol = PlayerPrefs.GetInt("Volume", 1);
        AudioListener.volume = vol;
        if (AudioListener.volume == 0f)
        {
            VolumeOffButton.SetActive(false);
            VolumeOnButton.SetActive(true);
        }
        else
        {
            VolumeOffButton.SetActive(true);
            VolumeOnButton.SetActive(false);
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

    public void VolOn()
    {
        VolumeOffButton.SetActive(true);
        VolumeOnButton.SetActive(false);
        AudioListener.volume = 1f;
        PlayerPrefs.SetInt("Volume", 1);
    }

    public void VolOff()
    {
        VolumeOffButton.SetActive(false);
        VolumeOnButton.SetActive(true);
        AudioListener.volume = 0f;
        PlayerPrefs.SetInt("Volume", 0);
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

    public void ShowAddsPannel()
    {
        adsToContinuePannel.SetActive(true);
        timeToDie = 5;
        timeLeftToDie = timeToDie;
        slidercount.maxValue = timeToDie;
        promtToContinue = true;
        Time.timeScale = 0f;
    }

    public void PausePannel(int choice)
    {
        if (choice == 0)
        {
            Time.timeScale = 0f;
            pausePannel.SetActive(true);
        }
        else
        {
            pausePannel.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void continueWithCoins()
    {
        if (stars >= 10)
        {
            stars -= 10;
            PlayerPrefs.SetInt("Star", stars);
            scoreStarText.text = stars + "";
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

    //score
    public void StarsIncrement(int count)
    {
        stars += count;
        PlayerPrefs.SetInt("Star", stars);
        scoreStarText.text = "" + stars;
    }

    public void GameOver()
    {
        var x = MemeController.PlayGameEndMemes();
        gameOverPannel.SetActive(true);
        Time.timeScale = 0f;
        adsToContinuePannel.SetActive(false);
        hudCanvasPannel.SetActive(false);
    }
    public void HomeButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void Retry()
    {
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.SetInt("continue", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    //ads
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

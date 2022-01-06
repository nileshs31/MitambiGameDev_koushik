using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemeController : MonoBehaviour
{
    public GameObject[] happyMemes, noMoneyMemes, sadMemes, angryMemes, congratulationsMemes, startMemes, endMemes;
    public float[] happyMemesTime, noMoneyMemesTime, sadMemesTime, angryMemesTime, congratulationsMemesTime, startMemesTime, endMemesTime;
    AudioSource Soundobj;

    public void Start()
    {

    }
    public void playHappyMeme()
    {
        turnOffAllOthers();
        var x = Random.Range(0, happyMemes.Length - 1);

        Soundobj.volume = 0.05f;

        happyMemes[x].SetActive(true);

        StartCoroutine(turnoff(happyMemes[x],happyMemesTime[x]));

    }
    public void playNoMoneyMemes()
    {
        turnOffAllOthers();
        var x = Random.Range(0, noMoneyMemes.Length - 1);

        Soundobj.volume = 0.05f;

        noMoneyMemes[x].SetActive(true);

        StartCoroutine(turnoff(noMoneyMemes[x], noMoneyMemesTime[x]));

    }
    public void playSadMeme()
    {
        turnOffAllOthers();
        var x = Random.Range(0, sadMemes.Length - 1);

        Soundobj.volume = 0.05f;

        sadMemes[x].SetActive(true);

        StartCoroutine(turnoff(sadMemes[x], sadMemesTime[x]));
    }
    public void playAngryMeme()
    {
        turnOffAllOthers();
        var x = Random.Range(0, angryMemes.Length - 1);

        Soundobj.volume = 0.05f;

        angryMemes[x].SetActive(true);

        StartCoroutine(turnoff(angryMemes[x], angryMemesTime[x]));

    }
    public void playCongratulationsMeme()
    {
        turnOffAllOthers();
        var x = Random.Range(0, congratulationsMemes.Length - 1);

        Soundobj.volume = 0.05f;

        congratulationsMemes[x].SetActive(true);

        StartCoroutine(turnoff(congratulationsMemes[x], congratulationsMemesTime[x]));

    }
    public void playStartMeme()
    {
        turnOffAllOthers();
        var x = Random.Range(0, startMemes.Length - 1);

        Soundobj.volume = 0.05f;

        startMemes[x].SetActive(true);

        StartCoroutine(turnoff(startMemes[x], startMemesTime[x]));

    }
    public void playEndMeme()
    {
        turnOffAllOthers();
        var x = Random.Range(0, endMemes.Length - 1);

        Soundobj.volume = 0.05f;

        endMemes[x].SetActive(true);

        StartCoroutine(turnoff(endMemes[x], endMemesTime[x]));

    }

    void turnOffAllOthers()
    {
        StopAllCoroutines();

        foreach (GameObject go in happyMemes)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in sadMemes)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in angryMemes)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in congratulationsMemes)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in startMemes)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in endMemes)
        {
            go.SetActive(false);
        }

        Soundobj.volume = 1f;
    }

    IEnumerator turnoff(GameObject memeObj, float waitTime)
    {

        yield return new WaitForSecondsRealtime(waitTime);
        memeObj.SetActive(false);
        Soundobj.volume = 1f;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemeController : MonoBehaviour
{
    public GameObject[] gameStartMemes, gameStartAfterAdsMemes, gameEndMemes, noMoneyMemes;
    public float[] gameStartMemesTime, gameStartAfterAdsMemesTime, gameEndMemesTime, noMoneyMemesTime;
    public AudioSource Soundobj;
    int x = -1;

    public void Start()
    {
        var go = GameObject.FindGameObjectWithTag("Backgroundmusic");
        if(go !=null)
            Soundobj = go.GetComponent<AudioSource>();
    }
    public float PlayGameStartMeme()
    {
        turnOffAllOthers();
        x = RREx(0, gameStartMemes.Length, x);

        if (Soundobj !=null)
            Soundobj.volume = 0.05f;

        gameStartMemes[x].SetActive(true);

        StartCoroutine(turnoff(gameStartMemes[x], gameStartMemesTime[x]));

        return gameStartMemesTime[x];
    }

    public float PlayAfterAdsMemes()
    {
        turnOffAllOthers();
        x = RREx(0, gameStartAfterAdsMemes.Length, x);

        if (Soundobj != null)
            Soundobj.volume = 0.05f;

        gameStartAfterAdsMemes[x].SetActive(true);

        StartCoroutine(turnoff(gameStartAfterAdsMemes[x], gameStartAfterAdsMemesTime[x]));

        return gameStartAfterAdsMemesTime[x];
    }

    public float PlayGameEndMemes()
    {
        turnOffAllOthers();
        x = RREx(0, gameEndMemes.Length, x);

        if (Soundobj != null)
            Soundobj.volume = 0.05f;

        gameEndMemes[x].SetActive(true);

        StartCoroutine(turnoff(gameEndMemes[x], gameEndMemesTime[x]));

        return gameEndMemesTime[x];
    }
    
    public float PlayNoMoneyMemes()
    {
        turnOffAllOthers();
        x = RREx(0, noMoneyMemes.Length, x);

        if (Soundobj != null)
            Soundobj.volume = 0.05f;

        noMoneyMemes[x].SetActive(true);

        StartCoroutine(turnoff(noMoneyMemes[x], noMoneyMemesTime[x]));

        return noMoneyMemesTime[x];
    }

    void turnOffAllOthers()
    {
        StopAllCoroutines();

        foreach (GameObject go in gameStartMemes)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in gameStartAfterAdsMemes)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in gameEndMemes)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in noMoneyMemes)
        {
            go.SetActive(false);
        }

        if (Soundobj != null)
            Soundobj.volume = 1f;
    }

    IEnumerator turnoff(GameObject memeObj, float waitTime)
    {

        yield return new WaitForSecondsRealtime(waitTime);
        memeObj.GetComponent<Tweener>().CloseDisable();
        if (Soundobj != null)
            Soundobj.volume = 1f;

    }


    int RREx(int i, int j, int k)
    {         //Random Range Exclusion
        int num;
        do
        {
            num = Random.Range(i, j);
        } while (num == k);
        return num;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Events;

public class Ads : MonoBehaviour,IUnityAdsListener
{
    private string GAME_ID = "4528381";
    [SerializeField] private string BannerId = "Banner_Android";
    [SerializeField] private string InterstitialId = "Interstitial_Android";
    [SerializeField] private string RewardId = "Rewarded_Android";

    [Header("OnFinishedAds Callback")]
    public UnityEvent OnFinishedAds;
    [Header("OnSkippedAds Callback")]
    public UnityEvent OnSkippedAds;
    [Header("OnFailedAds Callback")]
    public UnityEvent OnFailedAds;

    private void Start()
    {
        Advertisement.Initialize(GAME_ID, true);
        StartCoroutine(ShowBannerAdd());
    }

    IEnumerator ShowBannerAdd()
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show(BannerId);
    }

    public void InterstitialRandomly()
    {
        int x = Random.Range(0, 3);
        if (x == 0)
        {
            ShowInterstitialAdd();
        }
    }


    public void ShowInterstitialAdd()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show(InterstitialId);
        }
        else
        {
            Debug.Log("Not ready to load");
        }
    }


    public void ShowRewardedVideo()
    {
        OnUnityAdsReady(RewardId);
        
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            Debug.Log("Ads Playing");
        }
        else if (showResult == ShowResult.Skipped)
        {
            Debug.Log("No reward");
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        { 
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                //Time.timeScale = 1f;
                OnFinished();
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                OnSkipped();
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                OnFailed();
                break;
        }
    }
    void OnFinished()
    {
        OnFinishedAds.Invoke();
    }
    void OnSkipped()
    {
        OnSkippedAds.Invoke();
    }

    void OnFailed()
    {
        OnFailedAds.Invoke();
    }

    public void OnUnityAdsReady(string placementId)
    {
        if (placementId == RewardId)
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show(RewardId, options);
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("Not start");
    }
}

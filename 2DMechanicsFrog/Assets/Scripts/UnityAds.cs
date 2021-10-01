using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class UnityAds : MonoBehaviour , IUnityAdsListener
{
    private string GAME_ID = "4381333";
  //  private bool testmode = true;
    [SerializeField] private string BannerId = "Banner_Android";
    [SerializeField] private string InterstitialId = "Interstitial_Android";
    [SerializeField] private string RewardId = "Rewarded_Android";

    private void Start()
    {
        Advertisement.Initialize(GAME_ID);
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
        OnUnityAdsReady("Rewarded_Android");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<Gamecontroller>().ContinueWithAd();
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

    public void OnUnityAdsReady(string placementId)
    {
        if (placementId == RewardId)
        {
            var options = new ShowOptions { resultCallback = };
            Advertisement.Show(RewardId,options);
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


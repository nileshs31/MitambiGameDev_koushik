using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class UnityAds : MonoBehaviour
{
    private string GAME_ID = "4381333";
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
        Advertisement.Show(InterstitialId);
    }

    public void ShowRewardedAdd()
    {
        Advertisement.Show(RewardId);
    }
}


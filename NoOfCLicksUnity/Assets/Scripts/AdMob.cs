using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using GoogleMobileAds.Api;

public class AdMob : MonoBehaviour
{
    public Text status;
    public Text coinsText;
    private int coin = 0;
    private int rewardCoins = 0; 
    string App_Id = "ca-app-pub-9144048783690789~4437741489";
    string Banner_Id = "ca-app-pub-3940256099942544/6300978111";
    string Interstitial_Id = "ca-app-pub-3940256099942544/1033173712";
    string Reward_Id = "ca-app-pub-3940256099942544/5224354917";

    private BannerView banner;
    private InterstitialAd interstitial;
    private RewardedAd rewarded;

    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(initStatus => { });
    }

    private void Update()
    {
        if(rewardCoins > 0)
        {
            coin += rewardCoins;
            coinsText.text = coin.ToString();
            rewardCoins = 0;
        }
    }

    public void RequestBanner()
    {
        this.banner = new BannerView(Banner_Id, AdSize.Banner, AdPosition.Bottom);

        this.banner.OnAdLoaded += this.HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.banner.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
        // Called when an ad is clicked.
        this.banner.OnAdOpening += this.HandleOnAdOpened;
        // Called when the user returned from the app after an ad click.
        this.banner.OnAdClosed += this.HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        //this.banner.OnAdLeavingApplication += this.HandleOnAdLeavingApplication;
    }

    public void ShowBannerAdd()
    {
        AdRequest request = new AdRequest.Builder().Build();
        this.banner.LoadAd(request);
    }

    public void RequestInterstitial()
    { 
        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(Interstitial_Id);

        // Called when an ad request has successfully loaded.
        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.interstitial.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        // this.interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;


        AdRequest request = new AdRequest.Builder().Build();
        this.interstitial.LoadAd(request);
    }

    public void showInterstitialAd()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
    }

    public void loadRewardAd()
    {
        this.rewarded = new RewardedAd(Reward_Id);

        // Called when an ad request has successfully loaded.
        this.rewarded.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        //this.rewarded.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewarded.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewarded.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewarded.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewarded.OnAdClosed += HandleRewardedAdClosed;

        AdRequest request = new AdRequest.Builder().Build();
        this.rewarded.LoadAd(request);
    }

    public void showRewardedAd()
    {
        if (this.rewarded.IsLoaded())
        {
            this.rewarded.Show();
        }
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        status.text = "Ad load";
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        status.text = "Ad fail to load";
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        
    }


    //reward event 
    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        status.text = "reward ad loaded";
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        status.text = "reward ad fail to load";
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
       
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
       
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        double amount = args.Amount;
        rewardCoins = (int)amount;
    }
}





 

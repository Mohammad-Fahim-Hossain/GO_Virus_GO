using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdsManuManager : MonoBehaviour
{
    public static AdsManuManager adsManuManagerInstance;

    //private string AppID = "ca-app-pub-3940256099942544~3347511713";

    private BannerView Bannerview;
    private string BannerId = "ca-app-pub-3940256099942544/6300978111";

    private InterstitialAd FullScreenAd;
    private string FullScreenAdID = "ca-app-pub-3940256099942544/8691691433";

    private RewardedAd rewardedAd;
    private string rewardADID = "ca-app-pub-3940256099942544/5224354917";

    private void Awake()
    {
        if (adsManuManagerInstance==null)
        {
            adsManuManagerInstance = this;
        }
        else
        {
            Destroy(adsManuManagerInstance);
        }
        
       
    }


    // Start is called before the first frame update
    void Start()
    {
        //MobileAds.Initialize(AppID);

        MobileAds.Initialize(initStatus => { });

        ReqRewardedAd();

        // Called when an ad request has successfully loaded.
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;


    }

   

    public void RequestBanner()
    {
        Bannerview = new BannerView(BannerId, AdSize.Banner, AdPosition.Bottom);
        AdRequest request = new AdRequest.Builder().Build();

        Bannerview.LoadAd(request);

        Bannerview.Show();

    }

    public void HideBanner()
    {
        Bannerview.Hide();
    }

    public void ReqFullScreenAd()
    {
        FullScreenAd = new InterstitialAd(FullScreenAdID);

        AdRequest request = new AdRequest.Builder().Build();

        FullScreenAd.LoadAd(request);
    }

    public void ShowFullScreenAd()
    {
        if (FullScreenAd.IsLoaded())
        {
            FullScreenAd.Show();
        }
        else
        {
            Debug.Log("Full Screen Ad not loaded");
        }

    }

    public void ReqRewardedAd()
    {
        rewardedAd = new RewardedAd(rewardADID);

        AdRequest request = new AdRequest.Builder().Build();

        rewardedAd.LoadAd(request);
    }

    public void RewardedADshow()
    {
        if (rewardedAd.IsLoaded())
        {
            rewardedAd.Show();
        }
        else
        {
            Debug.Log("Rewarded Ad not loaded");
        }
    }

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdClosed event received");
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
            "HandleRewardedAdRewarded event received for "
                        + amount.ToString() + " " + type);

        PlayerSpawner.PlayerSpawnerInstance.ContinueGame();
        ReqRewardedAd();
    }
}

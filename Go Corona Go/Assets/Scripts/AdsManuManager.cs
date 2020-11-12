using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdsManuManager : MonoBehaviour
{
    public static AdsManuManager adsManuManagerInstance;

    private string AppID = "ca-app-pub-3940256099942544~3347511713";

    private BannerView bannerview;
    private string BannerId = "ca-app-pub-3940256099942544/6300978111";

    private InterstitialAd FullScreenAd;
    private string FullScreenAdID = "ca-app-pub-3940256099942544/8691691433";

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
        MobileAds.Initialize(AppID);
    }

    public void RequestBanner()
    {
        bannerview = new BannerView(BannerId, AdSize.Banner, AdPosition.Bottom);
        AdRequest request = new AdRequest.Builder().Build();

        bannerview.LoadAd(request);

        bannerview.Show();

    }

    public void HideBanner()
    {
        bannerview.Hide();
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
   
}

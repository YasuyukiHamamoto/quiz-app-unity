using UnityEngine.Events;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using System;
using System.Collections.Generic;

public class AdMobMgr : MonoBehaviour
{
    private BannerView bannerView;

    // Use this for initialization
    void Start()
    {
        this.RequestBanner();
    }

    private void RequestBanner()
    {
#if UNITY_ANDROID
            string adUnitId = "ca-app-pub-4992130041033929/9970656880";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-4992130041033929/6498315738";
#else
            string adUnitId = "unexpected_platform";
#endif
        
        // Clean up interstitial before using it
        if (bannerView != null)
        {
            bannerView.Destroy();
        }
        

        // Create a Smart Banner at the top of the screen.
        this.bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder()
            //.AddTestDevice("b3704f8822a8857fe10d8221c4e86a06")
            .Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);
    }

    public void DestroyBannerAd()
    {
        if (bannerView != null)
        {
            bannerView.Destroy();
        }
    }


}

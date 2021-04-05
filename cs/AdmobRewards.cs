using UnityEngine.Events;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class AdmobRewards : MonoBehaviour
{
    private RewardedAd rewardedAd;
    bool isRewarded;
    bool isClosed;
    public UnityEvent OnDestroyOtherAd;

    // Start is called before the first frame update
    void Start()
    {
        RequestRewardAd();
    }

    private void Update()
    {
        if (isClosed)
        {
            QuizMgr.ExceptRandomList();
            QuizMgr.lifeCount = 0;
            QuizMgr.continueCount++;
            OnDestroyOtherAd.Invoke();
            SceneManager.LoadScene("Main");
            isClosed = false;
            isRewarded = false;
        }
    }

    void RequestRewardAd()
    {
        string adUnitId;
#if UNITY_ANDROID
            adUnitId = "ca-app-pub-4992130041033929/6031411873";
#elif UNITY_IPHONE
        adUnitId = "ca-app-pub-4992130041033929/3213676841";
#else
            adUnitId = "unexpected_platform";
#endif

        this.rewardedAd = new RewardedAd(adUnitId);

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

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder()
            //.AddTestDevice("b3704f8822a8857fe10d8221c4e86a06")
            .Build();

        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);
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

        
        if (isRewarded)
        {
            isClosed = true;
        }
        
        RequestRewardAd();
        
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        isRewarded = true;
    }

    public void UserChoseToWatchAd()
    {
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
    }



}

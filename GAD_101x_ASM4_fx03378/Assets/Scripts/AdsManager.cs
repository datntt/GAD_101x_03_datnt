using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdsManager : MonoBehaviour
{
    private InterstitialAd interstitial;

    // Start is called before the first frame update
    void Start()
    {
        string adUnityId = "ca-app-pub-9686830333250593~3322685226";
        // Initialize an InterstitialAd
        this.interstitial = new InterstitialAd(adUnityId);
        // Create an empty ad request
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request
        this.interstitial.LoadAd(request);
    }

    //  show ads
    public void GameOver()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
    }
}
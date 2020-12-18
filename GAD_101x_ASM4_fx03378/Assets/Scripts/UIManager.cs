using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;

    public GameObject gameoverPanel;
    public GameObject addManager;
    private AdsManager ads;

    private static int showAds = 0;

    private void Start()
    {
        ads = addManager.GetComponent<AdsManager>();
    }

    public void SetScoreText(string txt)
    {
        if(scoreText)
        {
            scoreText.text = txt;
        }
    }
    public void ShowGameoverPanel(bool isShow)
    {
        if (gameoverPanel && gameoverPanel.activeSelf != isShow )
        {
            showAds++;
            highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();
            gameoverPanel.SetActive(isShow);
            // replay 2 turn show ads
            if(showAds % 2 == 0)
            {
                ads.GameOver();
            }
            
        }
    }

    
}

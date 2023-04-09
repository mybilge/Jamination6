using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class NormalMainMenuController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI usernameText;
    [SerializeField] TextMeshProUGUI bestScoreText;

    private void Start() {
        if(PlayerPrefs.GetString("Username") != "")
        {
            usernameText.text = PlayerPrefs.GetString("Username");

            double mainGameTimerd = (double)PlayerPrefs.GetInt("BestScore");
            TimeSpan time = TimeSpan.FromSeconds(mainGameTimerd);
            string scoreText = time.ToString("mm':'ss");


            bestScoreText.text = "Best Score: " + scoreText;
            HighScores.AddNewHighScore(PlayerPrefs.GetString("Username"), PlayerPrefs.GetInt("BestScore"));
        }
    }

    private void OnEnable() {
        if (PlayerPrefs.GetString("Username") != "")
        {
            usernameText.text = PlayerPrefs.GetString("Username");

            double mainGameTimerd = (double)PlayerPrefs.GetInt("BestScore");
            TimeSpan time = TimeSpan.FromSeconds(mainGameTimerd);
            string scoreText = time.ToString("mm':'ss");


            bestScoreText.text = "Best Score: " + scoreText;
            //HighScores.AddNewHighScore(PlayerPrefs.GetString("Username"), PlayerPrefs.GetInt("BestScore"));
        }
    }
}

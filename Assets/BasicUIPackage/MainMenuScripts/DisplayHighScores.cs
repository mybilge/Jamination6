using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DisplayHighScores : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] highScoreUsernames;
    [SerializeField] TextMeshProUGUI[] highScoreIntScores;

    HighScores highScoresManager;

    bool canRefresh = true;

    private void Awake() {
        highScoresManager = GetComponent<HighScores>();

        for (int i = 0; i < highScoreUsernames.Length; i++)
        {
            highScoreUsernames[i].text = "Yükleniyor...";
            highScoreIntScores[i].text = "";
        }
    }

    public void RefreshHighScores() {
        StopCoroutine(RefreshHighScoresCoroutine());
        StartCoroutine(RefreshHighScoresCoroutine());
    }

    IEnumerator RefreshHighScoresCoroutine()
    {
        if(canRefresh)
        {
            canRefresh = false;
            highScoresManager.DownloadHighScores();
            yield return new WaitForSeconds(2f);
            canRefresh = true;
        }
        
        
    }

    public void OnHighScoresDownloaded(HighScoreStruct[] highScoreArray)
    {
        for (int i = 0; i < highScoreUsernames.Length; i++)
        {
            highScoreUsernames[i].text = "...";
            //highScoreIntScores[i].text = "...";

            if(highScoreArray.Length > i)
            {
                highScoreUsernames[i].text = highScoreArray[i].username;

                double mainGameTimerd = (double)highScoreArray[i].score;
                TimeSpan time = TimeSpan.FromSeconds(mainGameTimerd);
                string scoreText = time.ToString("mm':'ss");


                highScoreIntScores[i].text = scoreText;
            }
        }
    }
}
